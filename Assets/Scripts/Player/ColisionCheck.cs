using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionCheck : MonoBehaviour
{
    public bool collisionFlag;
    public GameManagerVariables gameManagerScript;
    public Timer timer;

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
        // gameManagerScript.collisionFlag = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collisionFlag = true;

        if (other.transform.tag == "RingAsset")
        {
            gameManagerScript.collisionFlag = true;
        }

        TimerVariable.survivedTime = timer.getTime();
        SceneManager.LoadScene("2_EndScene");
    }
}
