using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    
    [SerializeField] int numLives=4;
    private GameObject playerInstance;
    private PauseMenu pause;

    private float respawnTimer=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        PauseMenu pause=GetComponent<PauseMenu>();
    }

    void Spawn()
    {   
        numLives--;
        //spawn player at the position of the game object, facing straight up
        playerInstance=(GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInstance==null && numLives>0)
        {
            respawnTimer-=Time.deltaTime;

            
            if(respawnTimer<=0)
            {
                Spawn();
            }
        }

    }

    void OnGUI()
    {
        if(numLives>0 | playerInstance!=null)
        {
            GUI.Label(new Rect(0,0,100,50),"Lives: "+numLives);
            //pause.Pause();
            
        }

        else 
        {
            GUI.Label(new Rect(Screen.width/2 - 50 , Screen.height/2 - 25,100,50),"Game Over!");
        }
        
        

    }
}
