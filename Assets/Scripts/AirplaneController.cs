using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    Rigidbody rb;

    public float rollAmount; // 뒤집기
    public float pitchAmount; // 앞뒤
    public float yawAmount; // 좌우

    public float speed;
    public float lerpAmount;

    float pitchValue;
    float yawValue;
    float rollValue;
    Vector3 rotateValue;


    void KeyInput()
    {
        if (Input.GetButton("Pitch"))
            pitchValue = Input.GetAxisRaw("Pitch");
        else
            pitchValue = 0;

        if (Input.GetButton("Roll"))
            rollValue = Input.GetAxisRaw("Roll");
        else
            rollValue = 0;

        if (Input.GetButton("Yaw"))
            yawValue = Input.GetAxisRaw("Yaw");
        else
            yawValue = 0;

        // if (Input.GetButton("Forward"))

    }

    void MoveAirplane()
    {
        Vector3 lerpVector = new Vector3(
            pitchValue * pitchAmount,
            yawValue * yawAmount,
            rollValue * rollAmount
        );        

        rotateValue = Vector3.Lerp(
            rotateValue, 
            lerpVector, 
            lerpAmount * Time.deltaTime
        );
    
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateValue * Time.fixedDeltaTime));
        
        int flg = 0;
        if(Input.GetAxisRaw("Forward") == 1.0f
            || Input.GetAxisRaw("Pitch") == 1.0f
            || Input.GetAxisRaw("Pitch") == -1.0f)
            flg = 1;
        // Debug.Log(flg);
        rb.velocity =  flg * transform.forward * speed * Time.fixedDeltaTime;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        KeyInput();
        MoveAirplane();
    }

}
