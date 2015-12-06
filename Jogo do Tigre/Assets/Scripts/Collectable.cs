using UnityEngine;
using System.Collections;

/**
 * When the object that contains this script collides with the Player, it will be destroyed and will add one more collectable at CollectableManager
 */
public class Collectable : MonoBehaviour {
    public CollectableManager collectableControl;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
			this.collectableControl.collectable++;
            Destroy(gameObject);
        }
    }
}
