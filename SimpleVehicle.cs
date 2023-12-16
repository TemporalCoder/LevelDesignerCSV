using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVehicle : MonoBehaviour
{
    static public float fVel = 0.0f; //current velocity
    public float maxVel = 1; //maximum velocity
    public float friction = 1.0f; //how much friction - slow down factor

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 100.0f * Time.deltaTime; //key sensitivity

        //keys input 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -speed, 0.0f); //rotate on y axis 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, speed, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (fVel < maxVel)
            {
                fVel += 30 * Time.deltaTime;  //30 how quick to accerlerate 
            }
        }

        //slow down vehicle
        if (fVel > 0.0f)
        {
            fVel -= friction * Time.deltaTime;
            if (fVel < 0.0f) { fVel = 0.0f; } //stop at zero - what about reverse?
        }

        Vector3 direction = transform.forward * (fVel * Time.deltaTime);//calculate forward amount

        //move our object forwards
        transform.Translate(direction, Space.World);

    }
}
