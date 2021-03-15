using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickUIEye : MonoBehaviour {

    Button uiButton;
    CameraManager cameraManager;

    void Start() {
        uiButton = this.GetComponent<Button>();
        uiButton.onClick.AddListener(OnUiElementClick);
        cameraManager = GameObject.Find("Camera Manager").GetComponent<CameraManager>();
    }

    void OnUiElementClick() {
        cameraManager.CameraSwitch();
    }

}
