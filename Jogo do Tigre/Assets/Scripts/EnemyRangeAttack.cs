using UnityEngine;
using System.Collections;

public class EnemyRangeAttack : MonoBehaviour {
	public enum SpriteRotation {
		UP = 270, RIGHT = 0, DOWN = 90, LEFT = 180
	};
	

	public SpriteRotation initialRotation;
	public Player target;
	public Transform firePoint;
	public GameObject bullet;

	private Camera currentCamera;
	private Vector2 direction_;
	private Vector2 targetPosition_;
	private Transform transform_;

	private float timer_;
	private bool attackControl_;

	private float angle_;
	
	void Start () {
		this.transform_ = gameObject.GetComponent<Transform> ();
		this.attackControl_ = true;
		this.timer_ = 15;

		if(!this.currentCamera) {
			this.currentCamera = Camera.main;
		}
	}
	
	void Update () {
		this.targetPosition_ = (Vector2) this.target.transform.position;
		this.direction_ = (this.targetPosition_ - (Vector2) this.transform_.position).normalized;
		
		this.angle_ = Mathf.Atan2 (this.direction_.y, this.direction_.x) * Mathf.Rad2Deg + (int) initialRotation;
		this.transform_.rotation = Quaternion.AngleAxis (this.angle_, Vector3.forward);

		this.timer_--;

		if (this.timer_ == 0) {
			this.attackControl_ = true;
		}

		if (this.attackControl_) {
			this.attackControl_ = false;
			this.timer_ = 15;
			Instantiate(this.bullet, this.firePoint.position, this.firePoint.rotation);
			Rigidbody2D body = this.bullet.GetComponent<Rigidbody2D>();
			body.velocity = new Vector2(-30, body.velocity.y);
		}
	}
}