using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnteredValve : MonoBehaviour {

    // Force which the explosion pushes the character away with
    public float maxForce;

    //Private variables
    PcMovement playerPcMovement;
    float forceInX;
    float forceInY;

    void OnTriggerEnter2D(Collider2D other) {
        // Take the players relative position when they enter the trigger
        // This way, if they stay in the trigger we'll be pushing them out with the same force
        if (other.tag.Contains("Player") && !other.tag.Contains("Type2")) {
            forceInX = RelativeXPosition(other) * maxForce;
            forceInY = RelativeYPosition(other) * maxForce;
            other.GetComponent<PcMovement>().PcCanMoveSwitch(false);
            other.GetComponent<Animator>().SetBool("Shocked",true);
            other.attachedRigidbody.AddRelativeForce(new Vector2(forceInX, forceInY));
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag.Contains("Player") && !other.tag.Contains("Type2")) {
            other.attachedRigidbody.AddRelativeForce(new Vector2(forceInX, forceInY), ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag.Contains("Player")) {
            other.GetComponent<Animator>().SetBool("Shocked",false);
        }
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

}