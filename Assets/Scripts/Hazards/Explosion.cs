using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour {

    // AVFX that play on explision being triggered
    public GameObject punishment;
    // Force which the explosion pushes the character away with
    public float maxForce;
    // A measure of magnitude for camera shake.
    public float shakeMagnitude;
    // Desired duration of the shake effect
    public float shakeDuration;
    // A measure of how quickly the shake effect should evaporate
    public float dampingSpeed;
    // Damage done by the explosion
    public int damageDone;

    //Private variables
    CameraShake cameraShake;

    void Start() {
        cameraShake =  GameObject.Find("Player Camera").GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject explosion = (GameObject)Instantiate(punishment, this.transform.position, Quaternion.identity);

        if (other.tag.Contains("Player")) {
            other.gameObject.GetComponent<PcMovement>().PcCanMoveSwitch(false);
            other.gameObject.GetComponent<PcHealth>().SubtractHealth(damageDone);
            cameraShake.TriggerShake(shakeDuration,shakeMagnitude,dampingSpeed);
        }

        float forceInX = RelativeXPosition(other) * maxForce;
        float forceInY = RelativeYPosition(other) * maxForce;
        other.attachedRigidbody.AddRelativeForce(new Vector2(forceInX, forceInY));

        Destroy(explosion, 2);
        Destroy(this.gameObject.transform.gameObject);
        
        GetComponent<Collider>().enabled = false;
    }

    float RelativeXPosition(Collider2D other) {
        float xOriginOfThis = this.transform.position.x;
        float xOriginOfObject = other.transform.position.x;
        return xOriginOfObject - xOriginOfThis;
    }

    float RelativeYPosition(Collider2D other) {
        float yOriginOfThis = this.transform.position.y;
        float yOriginOfObject = other.transform.position.y;
        return yOriginOfObject - yOriginOfThis;
    }

    public void RestartGame() {
        SceneManager.LoadScene("Main");
    }

}