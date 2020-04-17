using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{   
    [SerializeField] private float duration=4f;
    [SerializeField] private float shootDelay=0f;
    [SerializeField] private float rotate=360f;
    [SerializeField] private int puHealth; 

    [SerializeField] private float speed;

    //public bool poweredUp=false;

    //public bool powerUp=false;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {   
        //when player triggers a powerup
        if(other.CompareTag("Player"))
        {   
            StartCoroutine(Pickup(other));
        }

    }

    //increases fire rate, health, speed
    private IEnumerator Pickup(Collider2D player)
    {
        PlayerShooting shooting=player.GetComponent<PlayerShooting>();
        DamageHandler damage=player.GetComponent<DamageHandler>();
        PlayerMovement movement=player.GetComponent<PlayerMovement>();

        //increase fire rate and health
        shooting.fireDelay=shootDelay;
        damage.health+=puHealth;
        if(speed!=0)
        {
            movement.maxSpeed=speed;
        }
       
        //disable sprite renderer and collider so that the powerup can't interact with anything after its picked up, before it is destroyed
        GetComponent<SpriteRenderer>().enabled=false;
        GetComponent<Collider2D>().enabled=false;

        yield return new WaitForSeconds(2);
        
        Debug.Log("After delay");
        shooting.fireDelay=0.25f;
        movement.maxSpeed=10f;
 
        //destroy powerup
        Destroy(gameObject);
    }

}
