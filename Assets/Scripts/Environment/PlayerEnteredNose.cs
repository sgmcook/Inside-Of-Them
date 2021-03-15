using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnteredNose : MonoBehaviour {

    SpriteRenderer maskedElement;
    bool isColliding = false;

    void Start() {
        maskedElement = this.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D() {
        if (isColliding) { return; }

        isColliding = true;
        StartCoroutine(SpriteFade(1, 1));
    }

    void OnTriggerExit2D() {
        if (!isColliding) { return; }

        isColliding = false;
        StartCoroutine(SpriteFade(0, 1));
    }

    private IEnumerator SpriteFade(float endValue, float duration) {
        float elapsedTime = 0;
        float startValue = maskedElement.color.a;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            maskedElement.color = new Color(maskedElement.color.r, maskedElement.color.g, maskedElement.color.b, newAlpha);
            yield return null;
        }
    }

}
