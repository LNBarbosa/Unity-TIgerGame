using UnityEngine;
using System.Collections;

/**
 * This class adds a vertical speed at the platform when it collides with the Player.
 */
public class FallingPlatforms : MonoBehaviour {
    private Transform platform;	// Reference to the game object Transform
    private bool falling;		// Verifies if the action is happening or not
    private  Vector3 position;	// Reference to the game object Position

    private float timer;		// Timer for the platforms fall

	void Start () {
		this.timer = 1;
		this.platform = gameObject.GetComponent<Transform>();
        this.falling = false;
		this.position = this.platform.position;
    }

	/**
	 * The timer is always counting, it will only reach 0 when the Player reaches the platform
	 */
	void Update () {
		this.timer++;

		if (this.timer == 0) {
			this.falling = true;
		}

		if (this.falling) {
			this.platform.position = new Vector2(this.platform.position.x, this.platform.position.y - 0.2f);
			if (this.platform.position.y < -10) {
				this.platform.position = this.position;
				this.falling = false;
            }
        }
	}

	/**
	 * When Player reaches the platform, the timer will be changed to make the count down to perform the falling action
	 * The player will receive the platform as its parent. It is necessary to make Player stay on the moving platform
	 */
    void OnCollisionEnter2D(Collision2D collider)  {
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponent<Player>();
			player.transform.parent = this.platform.transform;

			this.timer = -40;
        }
    }

	/**
	 * When the Player is not touching the platform anymore, he will not be its son anymore, because it doesnt to move with it anymore
	 */
	void OnCollisionExit2D(Collision2D collider) {
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponent<Player>();
            player.transform.parent = null;
        }
    }
}
