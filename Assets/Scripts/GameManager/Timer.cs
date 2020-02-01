using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;

    private float time = 0;
    private int min = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
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

        timeText.text = string.Format("{0:}:{1:N2}", min, time);
    }

    public float getTime()
    {
        return min * 60 + time;
    }
}
