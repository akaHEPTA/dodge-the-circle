using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public GameManagerVariables gameManagerScript;
    public Metronome metronome;

    public int multiplier;
    public bool scoreFlag;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
        scoreFlag = false;
        gameManagerScript.score = 0;
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (metronome.beat)
        {
            scoreFlag = true;
        }

        if (gameManagerScript.ringsPassedCount >= 75) {
            multiplier = 10;
        }
        else if (gameManagerScript.ringsPassedCount >= 60) {
            multiplier = 8;
        }
        else if (gameManagerScript.ringsPassedCount >= 45) {
            multiplier = 6;
        }
        else if (gameManagerScript.ringsPassedCount >= 30) {
            multiplier = 4;
        }
        else if (gameManagerScript.ringsPassedCount >= 15) {
            multiplier = 2;
        }
        else {
            multiplier = 1;
        }

        if(scoreFlag)
        {
        gameManagerScript.score = gameManagerScript.score + (10 * multiplier);
        scoreFlag = false;
        }

        scoreText.text = "Score :" + gameManagerScript.score;
    }
}
