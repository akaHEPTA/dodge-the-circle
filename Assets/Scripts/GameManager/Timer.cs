using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public GameManagerVariables gameManagerScript;
    public float time = 0;
    public int min = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 60)
        {
            min++;
            time -= 60;
        }
        timeText.text = string.Format("{0:}:{1:N3}", min, time);
    }

    public float getTime()
    {
        return min * 60 + time;
    }

}
