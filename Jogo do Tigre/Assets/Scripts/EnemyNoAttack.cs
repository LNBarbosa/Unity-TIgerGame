using UnityEngine;
using System.Collections;

/**
 * This is script is just an example how to make enemies moving and performing action when he is close to the Player.
 * He is moving with a horizontalSpeed, when he encounter with the Player, he will stop his movement.
 */
public class EnemyNoAttack : MonoBehaviour {
    private Rigidbody2D body;		// Reference to enemy's Rigidbody2D

    public float maxSpeed;			// maxSpeed that the enemy can reach in horizontalSpeed
    public float horizontalSpeed;	// horizontalSpeed is the force that will be use to move the enemy horizontally
    public float jumpPower;			// jumpPower is the vertical force that will be aplyed to the player to perform jumps
    
    private float timer;			// It is a timer that will be used to control actions

    public bool grounded;			// Verifies if the the Player is on the ground
	public bool alive;				// Verifies if the the Player is alive
	public int currentHealth;		// Controls the this.currentHealth of the Player
    public int maxHealth;			// It is the maximum health that the Player can have

    private Animator animation;		// Reference to enemy's Animator


	/**
	 * Inicialize control variables
	 */
    public void Start() {
        this.alive = true;
		this.timer = 1.5f;

        animation = gameObject.GetComponent<Animator>();
		this.body = gameObject.GetComponent<Rigidbody2D>();
    }

	/**
	 * 
	 */
    void Update() {
		// Animation control
		animation.SetFloat ("horizontalSpeed", this.horizontalSpeed);
        animation.SetBool("alive", alive);

		/**
		 * If the enemy is alive, he will move with a horizontalSpeed
		 * Else he will perform a die animation during timeCount, and then will be destroyed
		 */
		if (this.alive) {
			this.body.velocity = new Vector2 (this.maxSpeed * this.horizontalSpeed, body.velocity.y);
		} else {
			if (this.timer > 0) {
				this.timer -= Time.deltaTime;
			} else {
				Destroy (gameObject);
			}
		}

		// Flips the Enemy sprite
		if (this.horizontalSpeed < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			transform.localScale = new Vector3 (1, 1, 1);
		}
    }

	/**
	 * This function tries to fix the enemy movement to look more normal
	 */
    void FixedUpdate() {
		Vector3 easeVelocity = this.body.velocity;
        easeVelocity.x *= 0.75f;

		if (this.body.velocity.y < 0) {
            easeVelocity.y *= 1.08f;
        } else easeVelocity.y *= 1.005f;

		this.body.velocity = easeVelocity;

        if (this.currentHealth == 0) {
			this.alive = false;
        }
    }

	/**
	 * Deals the damage that was taken, also plays the actions Hit
	 */
    public void Damage(int damage) {
        this.currentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Hit");
    }

	/**
	 * This fuctions tries to move the enemy back when he is hit
	 */
    public void Knockback(Player player) {
        // Verifies which direction the enemy is facing to perform the knockback
		int aux = 1;
        if (player.direction == Player.Direction.LEFT) {
			aux = -1;
		}

		this.body.velocity = new Vector2(0, 0);
		this.body.AddForce(Vector2.up * this.jumpPower / 1.5f, ForceMode2D.Force);
		this.body.velocity = new Vector2(this.maxSpeed / 2 * aux, body.velocity.y);
    }
}
