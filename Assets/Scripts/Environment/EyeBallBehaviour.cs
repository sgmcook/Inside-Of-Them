using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallBehaviour : MonoBehaviour {

    public float upperRandom;
    public float lowerRandom;
    public int rotationFrequency;
    public int rotationDelay;
    public float smooth;

    float newAngle;

    void Start() {
        InvokeRepeating("ReturnNewEyeAngle", rotationDelay, rotationFrequency);
    }

    void FixedUpdate() {
        Quaternion target = Quaternion.Euler(0, 0, newAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    void ReturnNewEyeAngle() {
        newAngle = UnityEngine.Random.Range(lowerRandom, upperRandom);
    }

}