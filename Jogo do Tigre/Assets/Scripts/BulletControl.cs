using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
    private float speed;		// Controls the speed that the bullet will move on the game
    private Player player;		// Reference the Player game object
    private int damage;			// It controls the damage that the bullet will take
    private Rigidbody2D body;	// Reference the Player's Rigidbody2D

	void Start () {
		this.speed = -20;
        this.body = GetComponent<Rigidbody2D>();
		this.player = FindObjectOfType<Player>();

		// Verifies which side the player is looking to create the object
		//if (this.player.transform.localScale.x < 0) {
		//	this.speed = -this.speed;
        //}

        this.damage = 1;
    }

	/**
	 * Each time the horizontal speed of the bullet is modified
	 */
    void Update () {
		//this.body.velocity = new Vector2(this.speed, this.body.velocity.y);
	}

	/**
	 * If the bullet collides with the Enemy, it will take the damage defined by this function
	 * If its collides with any object that doesnt has the tag NotSolid it will be destroyed
	 */
    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.CompareTag("NotSolid")) {
            Destroy(gameObject);
        }
    }
}
