﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float maxSpeed=5.0f;

    [SerializeField] private float rotSpeed=180f;

    private float shipBoundaryRadius=0.5f;

    private bool canDash=true;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashRot=360f;
    [SerializeField] private float timeBtwDashes;
    private float preDashSpeed;
    private float preDashRot;
    private bool isMoving=false;

    // Update is called once per frame
    void Update()
    {   
        Move();
    }
    
    private void Move()
    {
        //rotate ship

        //get rotation quaternion
        Quaternion rot=transform.rotation;

        //get the z euler angle
        float z = rot.eulerAngles.z;

        //change z axis based on input
        z-=Input.GetAxis("Horizontal") * rotSpeed *Time.deltaTime;
     
        /*if(Input.GetAxis("Horizontal")!=0)
        {
           isMoving=true;
        }

        if(isMoving)
        {
            SoundManager.PlaySound("PlayerMove");
        }*/

        //recreate quaternion
        rot=Quaternion.Euler(0,0,z);

        //feed the values into rotation
        transform.rotation=rot;


        //move ship up and down
        Vector3 pos=transform.position; //returns float from -1.0 to 1.0
    
        Vector3 velocity= new Vector3(0,Input.GetAxis("Vertical")* maxSpeed * Time.deltaTime,0);

        pos+=rot * velocity;


        //restrict player to boundaries

       /* //vertical
        if(pos.y+shipBoundaryRadius>Camera.main.orthographicSize)
        {
            pos.y=Camera.main.orthographicSize-shipBoundaryRadius; 
        }
        

        if(pos.y-shipBoundaryRadius< -Camera.main.orthographicSize)
        {
            pos.y=-Camera.main.orthographicSize+shipBoundaryRadius;
        }

        //calculate orthographic width based on screen ratio
        float screenRatio=(float)Screen.width/(float)Screen.height;
        float widthOrtho= Camera.main.orthographicSize*screenRatio;

        //now do horizontal bounds
        if(pos.x+shipBoundaryRadius>widthOrtho)
        {
            pos.x=widthOrtho-shipBoundaryRadius; 
        }
        

        if(pos.x-shipBoundaryRadius< -widthOrtho)
        {
            pos.x= -widthOrtho+shipBoundaryRadius;
        }*/


        //update position
        transform.position=pos;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashMove();
        }   
    }
    
    private void DashMove()
    {   
        preDashSpeed=maxSpeed;
        preDashRot=rotSpeed;

        if(canDash)
        {
            StartCoroutine(Dash());
        }
    }

    //increases your speed and rotation speed for a few seconds
    IEnumerator Dash()
    {
        canDash=false;
        maxSpeed=dashSpeed;
        rotSpeed=dashRot;
        yield return new WaitForSeconds(dashingTime);
        maxSpeed=preDashSpeed;
        rotSpeed=preDashRot;
        yield return new WaitForSeconds(timeBtwDashes);
        canDash=true;
    }
   
}
