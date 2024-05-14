using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    AudioSource audioSource;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody=GetComponent<Rigidbody>();
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
        if(Input.GetKey(KeyCode.Space)){
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else{
            audioSource.Stop();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust); 
        }

    }

    void ApplyRotation(float rotationFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }

}
