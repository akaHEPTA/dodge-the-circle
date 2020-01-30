using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    private Camera cameraMain;
    private float cameraMoveCounter;
    public float cameraMoveThreshold;
    public float cameraMaxX;
    public float cameraMinX;
    public float cameraMaxY;
    public float cameraMinY;
    public float cameraMaxZ;
    public float cameraMinZ;
    public float cameraMoveSpeed;
    public bool cameraMoveInMotion;
    public Vector3 cameraMoveTarget;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = this.GetComponentInParent<Camera>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate() 
    {
        cameraMoveCounter++;
        CameraMove();
    }

    void CameraMove(){
        if(cameraMoveCounter > cameraMoveThreshold && !cameraMoveInMotion){
            cameraMoveInMotion = true;
            cameraMoveTarget = new Vector3(Random.Range(cameraMinX, cameraMaxX),Random.Range(cameraMinX, cameraMaxX),Random.Range(cameraMinZ,cameraMaxZ));
        }

        if(cameraMoveInMotion){

            float diff = Vector3.Distance(cameraMain.transform.position, cameraMoveTarget);
            cameraMain.transform.position += (cameraMoveTarget - cameraMain.transform.position).normalized * cameraMoveSpeed * Time.deltaTime;
            cameraMain.transform.LookAt(player.transform.position);

            if(Mathf.Abs(diff) < 2f){
                cameraMoveInMotion = false;
                cameraMoveCounter = 0;
            }
        }

    }

}
