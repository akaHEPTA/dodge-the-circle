﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;

    public List<GameObject> arrayLevel_0;
    public List<GameObject> arrayLevel_1;
    public List<GameObject> arrayLevel_2;
    public GameObject ringTest;

    private GameObject currentInstance;

    public Metronome metronomeScript;

    // Start is called before the first frame update
    void Start()
    {
        metronomeScript = this.GetComponent<Metronome>();
        arrayLevel_0 = PopulateInstantiateList(0);
        arrayLevel_1 = PopulateInstantiateList(1);
        arrayLevel_2 = PopulateInstantiateList(2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(metronomeScript.beat){
            instantiateFlag = true;
            metronomeScript.beat = false;
        }
        
        if(instantiateFlag){
            //Level selector
            GameObject tempObject = PickFromLevel(0);
            
            //instantiating tempObject
            currentInstance = GameObject.Instantiate(tempObject,Vector3.zero,Quaternion.identity);
            // Rotate on create
            // currentInstance.GetComponent<RotationScript>().rotationSpeed = 0;
            // currentInstance.GetComponent<RotationScript>().randomInitial = false;
            
            instantiateFlag = false;
        }
    }

    GameObject PickFromLevel(int level){
        switch(level){
            case 0:
                {
                    //Picker Logic
                    return arrayLevel_0[Random.Range(0,arrayLevel_0.Count)];
                }
            default:
                return ringTest;
        }
    }

    public void spawnRing() {
        instantiateFlag = true;
    }

    public List<GameObject> PopulateInstantiateList(int inputLevel){
        
        List<GameObject> returnArray = new List<GameObject>();
        
        foreach(GameObject gameObject in Resources.LoadAll("Level"+inputLevel))
        {
        returnArray.Add(gameObject);
        }

        return returnArray;
    }


}