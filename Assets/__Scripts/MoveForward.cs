using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{   
    [SerializeField] private float speed=10.0f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position; //returns float from -1.0 to 1.0
    
        Vector3 velocity= new Vector3(0,speed * Time.deltaTime,0);

        pos+=transform.rotation * velocity;

        transform.position=pos;
    }
}
