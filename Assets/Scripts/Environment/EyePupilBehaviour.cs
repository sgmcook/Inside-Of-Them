using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePupilBehaviour : MonoBehaviour {

    public float upperPupilSizeMult;
    public float lowerPupilSizeMult;
    public float smooth;

    Vector3 beginningVector;
    float newPupilSizeMult = 1;

    void Start() {
        beginningVector = transform.localScale;
        InvokeRepeating("ReturnNewPupilSize", 2, 3);
    }

    void FixedUpdate() {
        Vector3 scaleIncrease = beginningVector * newPupilSizeMult;
        transform.localScale = Vector3.Lerp(transform.localScale, scaleIncrease, Time.deltaTime * smooth);
    }

    void ReturnNewPupilSize () {
        newPupilSizeMult = UnityEngine.Random.Range(upperPupilSizeMult, lowerPupilSizeMult);
    }
}
