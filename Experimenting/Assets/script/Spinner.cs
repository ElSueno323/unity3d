using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    
    
    [SerializeField] private float xspeed = 0f;
    [SerializeField] private float yspeed = 200f;
    
    [SerializeField] private float zspeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xspeed , yspeed , zspeed);
    }
}
