using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Animations;

public class Define 
{
    public enum CameraMode
    {
        QuaterView,
    }
}

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    GameObject _player;

    Vector3 triVec;
    Vector3 angVec;

    int hypo;

    void Awake() {
        hypo = -40;
    }

    void FixedUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            double rad = (int)_player.transform.eulerAngles.y * Math.PI / 180;

            triVec = new Vector3(
                hypo * (float)Math.Sin(rad),
                40,
                hypo * (float)Math.Cos(rad)
            );            
            transform.position = _player.transform.position + triVec;
            transform.LookAt(_player.transform.position);
            // transform.rotation = Quaternion.Euler(25, 0, 0);

            // if (Input.GetButton("Yaw"))
            //     transform.Rotate(0, Input.GetAxisRaw("Yaw") * (-1.0f) * Time.deltaTime, 0);
        }        
    }
}