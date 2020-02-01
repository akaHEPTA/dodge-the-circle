using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool randomInitial;
    public float rotationSpeed;
    public int rotationDirection;
    // Start is called before the first frame update
    void Start()
    {
        if(randomInitial){
            this.transform.Rotate(Vector3.forward, Random.Range(-180,180));
        }

        rotationDirection = Random.Range(0,2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotationDirection == 0) {
            this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else {
            this.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }
}