using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcInventory : MonoBehaviour {

    public string outOfMinesWarning;
    public Text mineCountUiText;
    public int maxMines;

    public int mineCount = 0;

    void Start() {
        mineCountUiText.text = mineCount.ToString();
    }

    public void AddMine() {
        if (CanAddNewMine())
            mineCount++;
        mineCountUiText.text = mineCount.ToString();
    }

    public bool CanAddNewMine() {
        if (mineCount > maxMines - 1) {
            return false;
        }
        return true;
    }

    public void placeMine() {

    }

}
