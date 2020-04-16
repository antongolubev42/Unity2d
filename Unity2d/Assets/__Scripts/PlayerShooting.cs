using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject puBulletPrefab;
    [SerializeField] public float fireDelay =0.25f;
    
    private int bulletLayer;
    private float cooldownTimer=0f;

    private AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletLayer=gameObject.layer;

        AudioManager audioManager=GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        cooldownTimer-=Time.deltaTime;
        //if player is pressing the fire button and if cooldown delay is 0 then fire
        if(Input.GetButton("Fire1")&&cooldownTimer<=0) 
        {
            Debug.Log("pew");
            cooldownTimer=fireDelay;
            
            Vector3 offset=transform.rotation* new Vector3(0,0.8f,0); //used to spawn the bullet at the top of the ship
           
                GameObject bulletGO=(GameObject)Instantiate(bulletPrefab,transform.position+offset,transform.rotation);
                audioManager.Play("PlayerShoot");
                //sets the bullet layer to the same layer as the thing that fired it
                bulletGO.layer=bulletLayer;
        }
    }

    
}
