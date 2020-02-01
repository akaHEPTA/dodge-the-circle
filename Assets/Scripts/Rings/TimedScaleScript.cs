using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedScaleScript : MonoBehaviour
{
    public float scaleSpeed;
    public int maxSize;

    public Vector3 initialScale;
    public RingInstantiateScript ringInstantiateScript;
    public GameManagerVariables gameManagerVariables;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = initialScale;
        ringInstantiateScript = GameObject.FindWithTag("Game Manager").GetComponent<RingInstantiateScript>();
        gameManagerVariables = GameObject.FindWithTag("Game Manager").GetComponent<GameManagerVariables>();
        maxSize = (int)gameManagerVariables.ringMaxSize;
        scaleSpeed = gameManagerVariables.ringSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        scaleSpeed = ringInstantiateScript.ringSpeed;
        this.transform.localScale = this.transform.localScale + new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, 0);

        if(this.transform.localScale.x > 1){
            Destroy(gameObject);
        }
    }
}
