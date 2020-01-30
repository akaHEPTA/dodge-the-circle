using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private void Update()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("1_GamePlay");
        }

        // for debug
        //if (Input.GetMouseButtonDown(0))
        //{
        //    SceneManager.LoadScene("PrototypeScene");
        //}
    }
}
