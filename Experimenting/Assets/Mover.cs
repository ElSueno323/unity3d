using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]  int acceleration = 25;
    void Start()
    {
        //transform.Translate(0,acceleration,0);   
    }

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        //float yValue = Input.GetAxis("Vertical");
        float zValue = Input.GetAxis("Vertical");
        transform.Translate(xValue * Time.deltaTime * acceleration,0,zValue * Time.deltaTime *acceleration);  
    }
}
