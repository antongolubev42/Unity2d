using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        Debug.Log("Picked up");
    }

}
