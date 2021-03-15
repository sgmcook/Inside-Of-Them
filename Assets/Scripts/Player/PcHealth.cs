using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcHealth : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;

    public Text currentHealthText;
    public GameObject deathAnimation;

    void Start() {
        UpdateHealthText();
        //Load in max health from savegame
        //Load in the health from savegame
    }

    public void AddHealth(int healthAdded) {
        currentHealth = currentHealth + healthAdded;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        UpdateHealthText();
    }

    public void SubtractHealth(int healthSubtracted) {
        currentHealth = currentHealth - healthSubtracted;
        if (currentHealth < 0) currentHealth = 0;
        if (IsPlayerDead()) KillPlayer();

        UpdateHealthText();
    }

    public bool IsPlayerDead() {
        if (currentHealth < 1)
            return true;
        return false;
    }

    public void KillPlayer() {
        GameObject deathAnimationInstance = Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        Destroy(deathAnimationInstance, 2);
        Destroy(this.gameObject.transform.gameObject);
    }

    void UpdateHealthText() {
        currentHealthText.text = currentHealth.ToString();
    }

}
