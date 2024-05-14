using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;

    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;
    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                Debug.Log("Finish");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        if (!isTransitioning)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(successSound);
            GetComponent<Movement>().enabled = false;
            Invoke("nextLevel", levelLoadDelay);
            isTransitioning = true;
        }
    }

    void StartCrashSequence()
    {
        if (!isTransitioning)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(crashSound);
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);
            isTransitioning = true;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void nextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
