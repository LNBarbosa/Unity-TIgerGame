using UnityEngine;
using System.Collections;

/**
 * If the player collides with the BoxCollider2D that contains its script, he will ignore further collisions.
 * This class is used to make Player cross platforms when he is performing jump actions.
 */
public class CrossPlatform : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			Physics2D.IgnoreLayerCollision(transform.gameObject.layer, collider.gameObject.layer, true);
        }
    }

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			Physics2D.IgnoreLayerCollision(transform.gameObject.layer, collider.gameObject.layer, false);
        }
    }
}
