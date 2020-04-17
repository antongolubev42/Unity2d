using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scoreboard : MonoBehaviour
{
    public static int scoreValue;
    private Scene scene;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score=GetComponent<Text>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        score.text=" Score: "+scoreValue;

        //switch scenes when score reaches a threshhold
        if(scene.name=="levelOne" && scoreValue==200)
        {
            SceneManager.LoadScene("levelTwo");
        }

        if(scene.name=="levelTwo" && scoreValue==350)
        {
            SceneManager.LoadScene("levelThree");
        }
    }
}
