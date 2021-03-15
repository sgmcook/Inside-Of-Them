using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnteredEye : MonoBehaviour {

    public Button uiElement;

    CameraManager cameraManager;
    UIElementManager uiElementManager;
    bool isColliding = false;

    void Start() {
        cameraManager = GameObject.Find("Camera Manager").GetComponent<CameraManager>();
        uiElementManager = GameObject.Find("UI Eye Button").GetComponent<UIElementManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (isColliding) {return;}
        
        if (other.tag.Contains("Player")) {
            isColliding = true;
            // Move UI Element onto UI
            uiElementManager.MoveUIElementOntoCanvas(true);
            // Allow the player to move the camera to Human view once they're in the eye
            cameraManager.ChangeCamSwitchPermission(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(!isColliding) {return;}

        if (other.tag.Contains("Player")) {
            isColliding = false;
            // Move UI element off UI
            uiElementManager.MoveUIElementOntoCanvas(false);
            // The player can no longer change the camera once they leave the eye
            cameraManager.ChangeCamSwitchPermission(false);
            // Auto switch the camera back to germ-view once the player leaves the eye
            cameraManager.CameraSwitch();
        }
    }
}