using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    private bool cameraZoomIn;
    private bool cameraZoomOut;
    public int cameraZoomThreshold;
    private int cameraZoomCounter;
    public bool beatTick;

    private Camera cameraMain;
    public float cameraMinFOV;
    public float cameraMaxFOV;
    public float cameraZoomSpeed;

    private float cameraTiltCounter;
    public float cameraTiltThreshold;
    public float cameraTiltMaxX;
    public float cameraTiltMinX;
    public float cameraTiltMaxY;
    public float cameraTiltMinY;
    public float cameraTiltSpeed;
    private bool cameraTiltInMotion;
    private Vector3 cameraTiltTarget;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = this.GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        CameraZoomAndTilt();
        
    }

    void FixedUpdate() 
    {
        cameraZoomCounter++;
        cameraTiltCounter++;
    }

    void CameraZoomAndTilt(){
        if(cameraTiltCounter > cameraTiltThreshold && !cameraTiltInMotion){
            cameraTiltInMotion = true;
            cameraTiltTarget = new Vector3(Random.Range(cameraTiltMinX, cameraTiltMaxX),Random.Range(cameraTiltMinX, cameraTiltMaxX),0);
        }

        if(cameraTiltInMotion){

            float diff = Quaternion.Angle(cameraMain.transform.rotation, Quaternion.Euler(cameraTiltTarget));
            cameraMain.transform.rotation = Quaternion.RotateTowards(cameraMain.transform.rotation, Quaternion.Euler(cameraTiltTarget),cameraTiltSpeed);

            if(Mathf.Abs(diff) < 2f){
                cameraTiltInMotion = false;
                cameraTiltCounter = 0;
            }
        }

    }

}
