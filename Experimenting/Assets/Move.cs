using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  float acceleration = 0.01f;
    [SerializeField]  float saut = 0.01f;
    [SerializeField]  float decalage = 0.001f;
    void Start()
    {
        transform.Translate(0,acceleration,0);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(saut,decalage,acceleration);  
    }
}
