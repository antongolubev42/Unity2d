using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PlayerMoveSound,PlayerShootSound,PowerShoot,PlayerDeathSound,EnemyDeathSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveSound=Resources.Load<AudioClip>("PlayerMove");
        PlayerShootSound=Resources.Load<AudioClip>("PlayerShoot");
        PowerShoot=Resources.Load<AudioClip>("PUshot");
        PlayerDeathSound=Resources.Load<AudioClip>("PlayerDeath");
        EnemyDeathSound=Resources.Load<AudioClip>("EnemyDeath");
        audioSource=GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "PlayerMove":
            audioSource.PlayOneShot(PlayerMoveSound);
            break;

            case "PlayerShoot":
            audioSource.PlayOneShot(PlayerShootSound);
            break;

            case "PUshot":
            audioSource.PlayOneShot(PowerShoot,0.1f);
            break;
            
            case "PlayerDeath":
            audioSource.PlayOneShot(PowerShoot,0.1f);
            break;
            
            case "EnemyDeath":
            audioSource.PlayOneShot(PowerShoot,0.1f);
            break;

        }
    }
}
