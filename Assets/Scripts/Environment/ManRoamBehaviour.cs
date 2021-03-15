using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManRoamBehaviour : MonoBehaviour {

    public float lowerRandom;
    public float upperRandom;
    public float movementFrequency;
    public float movementDelay;

    Rigidbody2D myRb;
    float newMovementX;
    float newMovementY;

    // Start is called before the first frame update
    void Start() {
        myRb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ReturnNewMovement", movementDelay, movementFrequency);
    }

    void ReturnNewMovement() {
        newMovementX = UnityEngine.Random.Range(lowerRandom, upperRandom);
        newMovementY = UnityEngine.Random.Range(lowerRandom, upperRandom);
        myRb.velocity = new Vector2(1 * newMovementX, 1 * newMovementY);

    }

}
