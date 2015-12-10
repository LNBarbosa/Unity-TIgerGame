using UnityEngine;
using System.Collections;

public class PlayerRangeAttack : MonoBehaviour {
    public Transform firePoint;
    public GameObject bullet;
    public bool attacking;

    private float attackTimer;
    private float attackCount;

    private Player player;
    private Animator animation;
    private CollectableManager manager;

    void Start () {
        this.player = FindObjectOfType<Player>();
		this.manager = FindObjectOfType<CollectableManager>();
		this.animation = gameObject.GetComponent<Animator>();

        this.attacking = false;
        this.attackTimer = 0;
        this.attackCount = 0.2f;
    }
	
	void Update () {
	    if(Input.GetKeyDown("k")) {
			if (this.manager.bullet > 0) {
				this.manager.bullet--;
				this.attacking = true;
				this.attackTimer = attackCount;

				if (this.player.transform.localScale.x < 0 && this.bullet.transform.localScale.x > 0) {
					this.bullet.transform.localScale = -this.bullet.transform.localScale;
				} else if (this.player.transform.localScale.x > 0 && this.bullet.transform.localScale.x < 0) {
					this.bullet.transform.localScale = -this.bullet.transform.localScale;
                }
				Instantiate(this.bullet, this.firePoint.position, this.firePoint.rotation);
				Rigidbody2D body = this.bullet.GetComponent<Rigidbody2D>();
				body.velocity = (Vector2) (this.firePoint.position - this.player.transform.position);
            }
        }

		if (this.attacking) {
			if (this.attackTimer > 0) {
				this.attackTimer -= Time.deltaTime;
			} else {
				this.attacking = false;
			}
        }

		animation.SetBool("RangeAttack", this.attacking);
    }
}
