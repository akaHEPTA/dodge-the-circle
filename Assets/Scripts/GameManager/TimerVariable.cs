using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVariable : MonoBehaviour
{
    public static float survivedTime;

    public static TimerVariable instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

}
