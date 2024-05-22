using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;
    AudioSource audioSource;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space))
        {
            flyUp();
        }
        else
        {
            flyStop();
        }
    }
    void flyUp()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (mainBoosterParticles.isStopped)
        {
            mainBoosterParticles.Play();
        }
    }
    void flyStop()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            flyRotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            flyRotateRight();
        }
        else
        {
            flyRotateStop();
        }
    }

    void flyRotateLeft()
    {
        if (rightBoosterParticles.isStopped)
        {
            rightBoosterParticles.Play();
        }
        ApplyRotation(rotationThrust);
    }

    void flyRotateRight()
    {
        if (leftBoosterParticles.isStopped)
        {
            leftBoosterParticles.Play();
        }
        ApplyRotation(-rotationThrust);
    }

    void flyRotateStop()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
    }

    void ApplyRotation(float rotationFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }

}
