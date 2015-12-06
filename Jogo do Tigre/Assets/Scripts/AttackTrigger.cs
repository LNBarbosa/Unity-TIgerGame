using UnityEngine;
using System.Collections;

/** NEEDS A TRIGGER BOX COLLIDER TO USE THE FUNCTION "OnTriggerEnter2D".
 * This class verifies it the attack collides with an enemy.
 */

public class AttackTrigger : MonoBehaviour {
    private int damage; 	// Controls the damage that the player will perform.
    private Player player; 	// Store the Player variable controller

	/**
	 * FUNCTION WILL BE EXECUTED WHEN THE OBJECT IS CREATE
	 */
	void Start () {
		this.player = gameObject.GetComponent<Player>(); // GetComponets gets gameObject that contains the variable Player
        this.damage = 1;	// Receive the value that the attack will perform.
	}

	/**
	 * Function will be activated when the BoxCollider2D detects a collision
	 */
    void OnTriggerEnter2D(Collider2D collider) {
		// Verifies if the collider is activeted and if the objects that it collides is an enemy
        if (collider.isTrigger != true && collider.CompareTag("Enemy")) {
            collider.SendMessageUpwards("Damage", damage);		// Calls the function Damage from the Enemy and send damage as parameter.
			collider.SendMessageUpwards("Knockback", player);	// Calls the function Knockback from the Enemy and send player as parameter.
        }
    }
}
