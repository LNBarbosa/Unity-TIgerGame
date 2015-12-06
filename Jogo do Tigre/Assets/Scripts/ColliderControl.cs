using UnityEngine;
using System.Collections;

/**
 * This class verifies if the EnemyNoAttack has collides with the Player.
 * If this happens, he will not move.
 */
public class ColliderControl : MonoBehaviour {
    public EnemyNoAttack enemy;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            enemy.horizontalSpeed = 0;
        }
    }
}
