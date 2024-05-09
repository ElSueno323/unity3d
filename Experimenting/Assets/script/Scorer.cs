using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag != "Hit"){
            score++;
        }
        Debug.Log("You Hit "+ score + " times");
    }
}
