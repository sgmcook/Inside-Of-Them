using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour { 
    
    public int damageDone;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag.Contains("Player")) {
            other.gameObject.GetComponent<PcHealth>().SubtractHealth(damageDone);
        }
    }

    public void restartGame() {
        SceneManager.LoadScene("Main");
    }

}
