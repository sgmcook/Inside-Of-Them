using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementManager : MonoBehaviour {

    RectTransform thisRectTransform;
    Vector3 moveOnScreen;
    Vector3 moveOffScreen;

    void Start() {
        thisRectTransform = GetComponent<RectTransform>();
        moveOffScreen = thisRectTransform.anchoredPosition;
        moveOnScreen = moveOffScreen + new Vector3(-128, 0, 0);
    }

    public void MoveUIElementOntoCanvas(bool moveIsTrue) {
        if (moveIsTrue) {
            thisRectTransform.anchoredPosition = Vector3.Lerp(moveOffScreen, moveOnScreen, 1);
        } else {
            thisRectTransform.anchoredPosition = Vector3.Lerp(moveOnScreen, moveOffScreen, 1);
        }
    }
}
