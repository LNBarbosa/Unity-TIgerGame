using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public enum Direction {				// ENUM TYPE = FOR PLAYER'S DIRECTION
		RIGHT, LEFT
	};

    public Direction direction;			// Verifies which direction the Player is moving

    public float maxSpeed;				// Max horizontal speed that the player can reach 
    public float speed;					// Speed that the Player can move (For know is the same when walking and running)
    public float jumpPower;				// Vertical force that will be aplyed in the Player to make it jump

    private float timer;				// Time to perform an acation

    private float horizontalSpeed;		// This will be positive when moving right and negative to left

    public int currentHealth;			// Controls the current health of the player
    public int maxHealth;				// Controls the max health that the player can have

	private bool runControl;			// Verifies if the player is running
    public bool grounded;				// Verifies if the player is grounded
	public bool alive;					// Verifies if the player is alive

	private Transform transform;
    private Rigidbody2D body;			// Reference to player's Rigidbody2D
    private Animator animation;			// Reference to player's Animator

    public Transform startPosition;		// Stores the initial position of the player in a scene

	/**
	 * Inicialize the main varibles
	 */
    void Start () {
		this.runControl = false;
		this.alive = true;
		this.transform = gameObject.GetComponent<Transform>();
		this.body = gameObject.GetComponent<Rigidbody2D>();
		this.animation = gameObject.GetComponent<Animator>();

		this.currentHealth = this.maxHealth;

		this.timer = 1.5f;
    }


	void RotationControl() {
		print(this.transform.rotation.z );

		if (this.transform.rotation.z > 0.090f) {
			//this.transform.Rotate(0, 0, 1);
			int rotAux = 9;

			do {
				this.transform.rotation =  Quaternion.Euler(0,0,rotAux);
				rotAux--;
			} while(rotAux > 0);
		}

		if (this.transform.rotation.z < -0.090f) {
			//this.transform.Rotate(0, 0, -1);
			this.transform.rotation = Quaternion.Euler(0,0,-9);

			int rotAux = -9;
			
			do {
				this.transform.rotation =  Quaternion.Euler(0,0,rotAux);
				rotAux++;
			} while(rotAux < 0);
		}
	}
	/**
	 * 
	 */
    void Update() {
		this.animation.SetBool("Run", runControl);
		this.animation.SetBool("Grounded", grounded);
		this.animation.SetFloat("Speed", Mathf.Abs(body.velocity.x));
		this.animation.SetBool("Alive", alive);

		this.horizontalSpeed = Input.GetAxis("Horizontal");

		RotationControl ();
		
		if(this.alive) {
			if(Input.GetKeyDown(KeyCode.LeftShift)) {
				this.runControl = true;
			} if(Input.GetKeyUp(KeyCode.LeftShift)) {
				this.runControl = false;
			}

			if (Mathf.Abs(this.body.velocity.x) > this.maxSpeed) {
				this.body.velocity = new Vector2(this.maxSpeed * this.horizontalSpeed, this.body.velocity.y);
            } else {
				this.body.AddForce(Vector2.right * this.speed * this.horizontalSpeed);
            }

            if (Input.GetAxis("Horizontal") < -0.1f && this.direction != Direction.LEFT) {
				this.transform.localScale = new Vector3(-3.75f, 3.75f, 1);
				this.direction = Direction.LEFT;
				this.body.velocity = new Vector2(-this.speed/2.0f, this.body.velocity.y);
            }

			if (Input.GetAxis("Horizontal") > 0.1f && this.direction != Direction.RIGHT) {
				this.transform.localScale = new Vector3(3.75f, 3.75f, 1);
				this.direction = Direction.RIGHT;
				this.body.velocity = new Vector2(this.speed/2.0f, this.body.velocity.y);
            }

			if (Input.GetButtonDown("Jump") && this.grounded) {
				this.body.AddForce(Vector2.up * this.jumpPower, ForceMode2D.Force);
            }
        }
        
        else {
			if (this.timer > 0) {
				this.timer -= Time.deltaTime;
			} else {
				RestartGame();
			}
        }
    }

    void FixedUpdate() {
        Vector3 easeVelocity = body.velocity;
        easeVelocity.x *= 0;

        if (this.horizontalSpeed == 0 && grounded) {
			body.velocity = easeVelocity;
		}

        if (currentHealth == 0) {
            alive = false;
        }
    }

    public void Damage(int damage) {
        if (currentHealth - damage < 0) currentHealth = 0;
        else currentHealth -= damage;

        gameObject.GetComponent<Animation>().Play("Hit");
    }

    public void Knockback() {
        int aX = 1;
        bool aux = true;
        if (body.velocity.x > 0) aX = -1;
        if (body.velocity.y > 0) aux = false;

        body.velocity = new Vector2(0, 0);

        if(aux) body.AddForce(Vector2.up * jumpPower / 1.5f, ForceMode2D.Force);
        else body.AddForce(Vector2.down * jumpPower/1.5f, ForceMode2D.Force);
        body.velocity = new Vector2(maxSpeed/2 * aX, body.velocity.y);
    }

    void RestartGame() {
        alive = true;
        currentHealth = maxHealth;
		this.timer = 1.5f;
        transform.position = startPosition.position;
    }
}
