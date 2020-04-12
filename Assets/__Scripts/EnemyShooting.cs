using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireDelay =0.50f;
    int bulletLayer;
    private float cooldownTimer=0f;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        bulletLayer=gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {   
        if(player==null)
        {
            //find the player
            GameObject playerGO= GameObject.FindWithTag("Player");

            //if player gameobject is not null then set the transform of the gameobject to the transform variable
            if(playerGO!=null)
            {
                player=playerGO.transform;
            }
        }

        cooldownTimer-=Time.deltaTime;
        //if there is a player if cooldown delay is 0  
        // and if the distance is less than 5
        if(cooldownTimer<=0 && player !=null && Vector3.Distance(transform.position,player.position)<5) 
        {
            Debug.Log("bad pew");
            cooldownTimer=fireDelay;

            //used to spawn the bullet at the top of the ship
            Vector3 offset=transform.rotation* new Vector3(0,0.8f,0); 

            GameObject bulletGO=(GameObject)Instantiate(bulletPrefab,transform.position+offset,transform.rotation);
            //sets the bullet layer to the same layer as the thing that fired it
            bulletGO.layer=bulletLayer;
        }
    }
}
