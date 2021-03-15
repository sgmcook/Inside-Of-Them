using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnteredBloodFlow : MonoBehaviour {

    public float relativeForceX;
    public float relativeForceY;
    float forceInX;
    float forceInY;

    Transform forceApplier;

    void Start() {
        double angleOfObject = FindAngleOfAsset();
        float magntitude = FindMagnititudeOfForce();
        forceInX = ForceAtAngleX(angleOfObject, magntitude);
        forceInY = ForceAtAngleY(angleOfObject, magntitude);
    }

    void OnTriggerStart2D(Collider2D other) {
        other.attachedRigidbody.AddForce(new Vector2(forceInX, forceInY));
    }

    void OnTriggerStay2D(Collider2D other) {
        other.attachedRigidbody.AddForce(new Vector2(forceInX, forceInY));
    }

    void OnTriggerExit2D(Collider2D other) {
        other.attachedRigidbody.AddForce(new Vector2(0, 0));
    }

    double FindAngleOfAsset() {
        double foundAngleOfObject = ConvertToRadians(this.transform.eulerAngles.z);
        return foundAngleOfObject;
    }

    public double ConvertToRadians(double angle) {
        return (Math.PI / 180) * angle;
    }

    float FindMagnititudeOfForce() {
        double foundMagnititude = Math.Sqrt((relativeForceY * relativeForceY) + (relativeForceX + relativeForceX));
        return (float)foundMagnititude;
    }

    float ForceAtAngleY(double angleOfObject, float magntitude) {
        float foundForceInY = magntitude * (float)Math.Cos(Math.PI - angleOfObject);
        return foundForceInY;
    }

    float ForceAtAngleX(double angleOfObject, float magntitude) {
        float foundForceInX = magntitude * (float)Math.Sin(angleOfObject);
        return foundForceInX;
    }
}
