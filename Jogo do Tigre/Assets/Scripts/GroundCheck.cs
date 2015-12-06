using UnityEngine;
using System.Collections;

/**
 * This class is necessary to verify if the player is grounded
 */
public class GroundCheck : MonoBehaviour {
    private Player player;	// Reference to Player

	void Start () {
        player = gameObject.GetComponentInParent<Player>();
	}

	// If its colliding with something, it means that the Player is touching the ground
	void OnTriggerEnter2D(Collider2D collider) {
        player.grounded = true;
	}

    void OnTriggerExit2D(Collider2D collider) {
        player.grounded = false;
    }

    void OnTriggerStay2D(Collider2D collider) {
        player.grounded = true;
    }
}
