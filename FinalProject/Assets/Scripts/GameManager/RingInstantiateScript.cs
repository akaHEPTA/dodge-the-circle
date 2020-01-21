﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;

    public int level_0;
    public GameObject ringLevel_0_1;
    public GameObject ringLevel_0_2;
    public GameObject ringLevel_0_3;


    private GameObject currentInstance;
    public CameraBehaviour cameraScript;

    public Metronome metronomeScript;

    // Start is called before the first frame update
    void Start()
    {
        metronomeScript = this.GetComponent<Metronome>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject tempObject = PickFromList(0);

        if(metronomeScript.beat){
            instantiateFlag = true;
            metronomeScript.beat = false;
        }
        
        if(instantiateFlag){
            currentInstance = GameObject.Instantiate(tempObject,Vector3.zero,Quaternion.identity);
            currentInstance.transform.Rotate(Vector3.forward, Random.Range(-180,180));
            instantiateFlag = false;
        }
    }

    GameObject PickFromList(int level){
        switch(level){
            case 0:
                int aux = Random.Range(0, level_0);
                switch(aux){
                    case 0: 
                        return ringLevel_0_1; 
                    case 1: 
                        return ringLevel_0_2; 
                    case 2: 
                        return ringLevel_0_3;
                    default:
                        return ringLevel_0_1; 
                }
            default:
                return ringLevel_0_1;
        }
    }

    public void spawnRing() {
        instantiateFlag = true;
        cameraScript.beatTick = true;
    }


}