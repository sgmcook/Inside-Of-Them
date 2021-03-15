using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    // Transform of the GameObject you want to shake
    Transform mTransform;
    // Desired duration of the shake effect
    float shakeDuration;
    // A measure of magnitude for the shake. Tweak based on your preference
    float shakeMagnitude;
    // A measure of how quickly the shake effect should evaporate
    float dampingSpeed;
    // Are shakes allowed?
    bool isShakingAllowed = false;
    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake() {
        if (mTransform == null) {
            mTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void Update() {
        if (isShakingAllowed) {
            if (shakeDuration > 0) {
                initialPosition = transform.localPosition;
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                shakeDuration -= Time.deltaTime * dampingSpeed;
            } else {
                shakeDuration = 0f;
                transform.localPosition = initialPosition;
                isShakingAllowed = false;
            }
        }
    }

    void OnEnable() {
        initialPosition = transform.localPosition;
    }

    public void TriggerShake(float inShakeDuration = 1, float inShakeMagnitude = 1, float inDampingSpeed = 1) {
        isShakingAllowed = true;
        shakeDuration = inShakeDuration;
        dampingSpeed = inDampingSpeed;
        shakeMagnitude = inShakeMagnitude;
    }

}
