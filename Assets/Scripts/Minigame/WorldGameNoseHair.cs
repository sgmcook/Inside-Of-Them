using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGameNoseHair : MonoBehaviour {

    HingeJoint2D thisHinge;

    void Start() {
        thisHinge = this.GetComponent<HingeJoint2D>();
    }

    void Update() {
        double angleAtTimeT = this.transform.eulerAngles.z;
        print(thisHinge.limits.min);
        print(thisHinge.limits.max);
    }

}
