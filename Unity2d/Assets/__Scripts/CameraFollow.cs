using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform myTarget;
    public GameObject player;

    void Start()
    {
        //find the player
        player=GameObject.FindWithTag("Player");
        myTarget=player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(myTarget!=null )
        {   
            Vector3 targetPos= myTarget.position;
            targetPos.z=transform.position.z;
            transform.position=targetPos;
        }

        if(myTarget==null)
        {
            player=GameObject.FindWithTag("Player");
            myTarget=player.transform;
        }
    }
}
