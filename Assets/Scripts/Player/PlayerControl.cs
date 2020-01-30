using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // this value can be changed
    public float rotateSpeed;

    private Rect left_side = new Rect(0, 0, Screen.width / 3, Screen.height);
    private Rect right_side = new Rect(Screen.width * 2 / 3, 0, Screen.width * 2 / 3, Screen.height);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (left_side.Contains(touch.position))
            {
                transform.Rotate(Vector3.forward * rotateSpeed);
            }

            if (right_side.Contains(touch.position))
            {
                transform.Rotate(Vector3.back * rotateSpeed);
            }

        }

        //// for debug
        //if (Input.GetMouseButton(0))
        //{
        //    transform.Rotate(Vector3.forward * rotateSpeed);
        //}

        //if (Input.GetMouseButton(1))
        //{
        //    transform.Rotate(Vector3.back * rotateSpeed);
        //}

    }

}

