using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{   
    [SerializeField] private float rotationSpeed=180f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
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

        if(player==null)
        {
            return; //try again in the next frame
        }

        Vector3 dir= player.position-transform.position; 
        dir.Normalize(); 

        //returns a radian that is the correct angle based on our x and y
        float zAngle=Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg- 90;

        Quaternion desiredRot = Quaternion.Euler(0,0,zAngle);

        transform.rotation=Quaternion.RotateTowards(transform.rotation, desiredRot,rotationSpeed*Time.deltaTime);
    }
}
