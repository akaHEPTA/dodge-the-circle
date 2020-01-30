using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text lastTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TimerVariable.survivedTime);

        lastTime.text = TimerVariable.survivedTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
