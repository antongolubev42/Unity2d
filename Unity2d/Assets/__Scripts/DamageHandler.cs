using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{   
    [SerializeField] public int health =1;
    [SerializeField] private float invulTime=0f;
    private float invulPeriod=0f;
    private int correctLayer;
    private int killCount;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        correctLayer=gameObject.layer;
        spriteRenderer=GetComponent<SpriteRenderer>();
        
        //this will only get the rendered in the parent object
        /*if(spriteRenderer==null)
        {
            spriteRenderer= transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRenderer==null)
            {
                Destroy(gameObject);
                Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer");
            }
        }*/
    }
    private void OnTriggerEnter2D()
    {
        Debug.Log("Trigger");

        //when objects collide, they take 1 dmg
        health--;

        //invulnerability
        if(invulTime>0)
        {
            invulPeriod=invulTime;
            gameObject.layer=10;
        }
        
    }

    void Update()
    {   
        if(invulPeriod>0)
        {
            invulPeriod-=Time.deltaTime;
            if(invulPeriod<=0)
            {
                gameObject.layer=correctLayer;
                if (spriteRenderer!=null)
                {
                    spriteRenderer.enabled=true;
                }
            }
            else 
            {
                if(spriteRenderer!=null)
                {
                    spriteRenderer.enabled=!spriteRenderer.enabled;
                }
            }
        }

        if(health<=0)
        {
            Die();
        }

        CheckIfInvisible();
    }
    private void Die()
    {   
        //when enemy dies, add 10 score and play sound
        if(gameObject.layer==9 && gameObject.tag=="Enemy")
        {
            Debug.Log("Killed enemy");
            Scoreboard.scoreValue+=10;
            SoundManager.PlaySound("EnemyDeath");
        }

        if(gameObject.layer==8 && gameObject.tag=="Player")
        {
            SoundManager.PlaySound("PlayerDeath");
        }

        Destroy(gameObject);
    }

    //had a bug that was causing enemies to spawn without a sprite renderer so I added this function to elimate it
    //if gameoject doesnt have a sprite renderer then destroy it
    private void CheckIfInvisible()
    {
        if(spriteRenderer==null)
        {
            spriteRenderer= transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRenderer==null)
            {
                Destroy(gameObject);
                Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer");
            }
        }
    }

  
}
