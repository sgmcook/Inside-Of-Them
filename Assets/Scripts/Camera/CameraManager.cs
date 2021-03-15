using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera playerCamera;
    public Camera humanCamera;
    bool camSwitchAllowed = false;
    bool primaryCamActive = true;

    public void CameraSwitch() {
        if (camSwitchAllowed) {
            primaryCamActive = !primaryCamActive;
            playerCamera.gameObject.SetActive(primaryCamActive);
            humanCamera.gameObject.SetActive(!primaryCamActive);
        } else {
            primaryCamActive = true;
            playerCamera.gameObject.SetActive(primaryCamActive);
            humanCamera.gameObject.SetActive(!primaryCamActive);
        }
    }

    public void ChangeCamSwitchPermission(bool permission) {
        camSwitchAllowed = permission;
    }
}
