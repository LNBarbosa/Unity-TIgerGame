using UnityEngine;
using System.Collections;

public class SmashTrap: MonoBehaviour {
	private float jumpPower;
	private Rigidbody2D upSmash;

	void Start () {
		this.jumpPower = 600;
		this.upSmash = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collider)  {
		if (collider.gameObject.tag == "Smash") {
			this.upSmash.velocity = new Vector3(0,0,0);
			this.upSmash.AddForce(Vector2.up * this.jumpPower, ForceMode2D.Force);
		}
	}
}
