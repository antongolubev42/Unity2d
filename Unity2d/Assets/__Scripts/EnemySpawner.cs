using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;

    [SerializeField] private float spawnDistance=20f;
    private float nextEnemy=1f;

    // Update is called once per frame
    void Update()
    {
        nextEnemy-=Time.deltaTime;

        if(nextEnemy<=0f)
        {
            nextEnemy= spawnRate;
            //enemies spawn faster after every spawn
            spawnRate*=0.95f;     

            if(spawnRate<2)
            {
                spawnRate=2;
            }
                       
            //gives a random sphere
            Vector3 offset=Random.onUnitSphere;
            
            offset.z=0;

            //x and y normalised to a length of 1
            //multiplied by the distance that we want them to spawn
            offset=offset.normalized*spawnDistance;

            Instantiate(enemyPrefab,transform.position+offset,Quaternion.identity);
        }

    }
}
