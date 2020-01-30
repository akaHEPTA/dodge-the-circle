using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            //Destroy(GameObject.Find("TimerVariable").GetComponent<TimerVariable>());
            SceneManager.LoadScene("0_StartScene");
        }
    }
}
