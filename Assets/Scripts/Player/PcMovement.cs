using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PcMovement : MonoBehaviour {

    public float regainControlSpeed;

    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    Animator myAnim;
    Vector2 mousePosition;

    bool canMove = true;
    bool facingRight = true;
    bool isPicked = false;

    public float maxSpeed;

    void Start() {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();

        Camera myCam = Camera.main;
    }

    void Update() {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveSum = Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical);

        //If the player is trying to move, then we allow them to control momentum   
        if (canMove && moveSum > 0) {
            myRB.velocity = new Vector2(moveHorizontal * maxSpeed, moveVertical * maxSpeed);
            myAnim.SetFloat("MoveSpeedVertical", moveVertical);
            myAnim.SetFloat("MoveSpeedHorizontal", Mathf.Abs(moveHorizontal));
            CheckDirectionFaced(moveVertical, moveHorizontal);
        }

        if (moveSum < regainControlSpeed) {
            canMove = true;
        }

        //Just for testing
        if (isPicked) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    void CheckDirectionFaced(float moveVertical, float moveHorizontal) {
        if (moveHorizontal > 0 && !facingRight) {
            Flip();
        } else if (moveHorizontal < 0 && facingRight) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }

    // Checks for things interacting with the player
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall") {
            myAnim.SetTrigger("SquishDown");
            PcCanMoveSwitch(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Wall") {
            myAnim.ResetTrigger("SquishDown");
            PcCanMoveSwitch(true);
        }
    }

    public void PcCanMoveSwitch(bool canMoveChange) {
        canMove = canMoveChange;
    }

    void OnMouseDown() {
        isPicked = true;
    }

    void OnMouseUp() {
        isPicked = false;
    }
}
