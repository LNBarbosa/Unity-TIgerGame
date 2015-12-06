using UnityEngine;
using System.Collections;

/**
 * Saves the position that the player was when he reaches this pointl
 */
public class Checkpoint : MonoBehaviour {
	// Saves that new NewSpawnPoint at the Respawn Object.
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            Respawn respawnScript = collider.gameObject.GetComponent<Respawn>();
            respawnScript.NewSpawnPoint(transform);

            gameObject.SetActive(false);
        }
    }
}
