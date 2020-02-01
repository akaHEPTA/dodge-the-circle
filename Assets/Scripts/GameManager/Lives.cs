using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text livesText;
    public GameManagerVariables gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
        gameManagerScript.lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives : " + gameManagerScript.lives;
    }
}
