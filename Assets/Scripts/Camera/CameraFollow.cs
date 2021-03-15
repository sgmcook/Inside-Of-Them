using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;

    Vector3 offset;

    void Start() {
        offset = this.transform.position - target.position;
    }

    void Update() {
        Vector3 targetCamPosition = target.position + offset;
        transform.position = Vector3.Lerp(targetCamPosition, transform.position, smoothing * Time.deltaTime);
    }

}
