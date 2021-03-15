using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMine : MonoBehaviour {
    
    public GameObject reward;

    bool isColliding;    
    
    void OnTriggerEnter2D (Collider2D other) {
        if (isColliding) {return;}        

        if (other.tag.Contains("Player")) {
            GameObject rewardAnim = Instantiate(reward, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject.transform.gameObject);
            Destroy(rewardAnim, 2);
            other.gameObject.GetComponent<PcInventory>().AddMine();
            GetComponent<Collider>().enabled = false;
        }
    }
}
