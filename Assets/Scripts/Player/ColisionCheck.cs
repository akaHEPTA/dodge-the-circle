
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionCheck : MonoBehaviour
{
    public bool collisionFlag;
    public GameManagerVariables gameManagerScript;
    public Timer timer;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
        gameManagerScript.collisionFlag = collisionFlag;

        timer = GameObject.Find("Timer").GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.lives <= 0){
            TimerVariable.survivedTime = timer.getTime();
            SceneManager.LoadScene("2_EndScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collisionFlag = true;

        if (other.transform.tag == "RingAsset")
        {
            gameManagerScript.collisionFlag = true;
            gameManagerScript.lives--;
            gameManagerScript.ringsPassedCount = 0;
            score.multiplier = 1;
            GooglePlayManager.instance.submitScore();
        }
        else if (other.transform.tag == "ringPassed"){
            gameManagerScript.ringsPassedCount++;
            GooglePlayManager.instance.addScore();
        }        
    }
}
