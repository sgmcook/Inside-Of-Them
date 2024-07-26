using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGameNoseHair : MonoBehaviour {

    HingeJoint2D thisHinge;
    PolygonCollider2D thisCollider;
    float originAngle;
    float minAngle;
    float maxAngle;

    void Start() {
        thisCollider = this.GetComponent<PolygonCollider2D>();
        thisHinge = this.GetComponent<HingeJoint2D>();

        print("Starting Angle: " + (originAngle = this.transform.eulerAngles.z));
        print("Min Angle: " + (minAngle = thisHinge.limits.min));
        print("Max Angle: " + (maxAngle = thisHinge.limits.max));
    }

    void FixedUpdate() {
        float angleAtTimeT = thisHinge.jointAngle;
        print("Min: " + minAngle + " angleAtT: " + Mathf.Round(angleAtTimeT) + " Max: " + maxAngle);

        if (angleAtTimeT > maxAngle + 1 || angleAtTimeT < minAngle - 1) {
            thisCollider.isTrigger = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, ReturnNewEyeAngle(), Time.deltaTime);
        } else {
            thisCollider.isTrigger = false;
        }
    }

    Quaternion ReturnNewEyeAngle() {
        Quaternion target = Quaternion.Euler(0,0,0);
        return target;
    }

}
