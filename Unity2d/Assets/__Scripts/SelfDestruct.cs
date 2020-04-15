using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timer=1.0f;

    void Update()
    {
        timer-=Time.deltaTime;

        if(timer<=0)
        {
            Destroy(gameObject);
        }
    }
        
} 