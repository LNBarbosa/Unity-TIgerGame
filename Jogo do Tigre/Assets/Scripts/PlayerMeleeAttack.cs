using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour {
    private bool attacking;
    private float attackTimer;
    private float attackCount;

    public Collider2D attackTrigger;
    private Animator animation;

    void Start() {
        this.attacking = false;
        this.attackTimer = 0;
        this.attackCount = 0.3f;
    }

    void Update() {
		if (Input.GetKeyDown("j") && !this.attacking) {
			this.attacking = true;
			this.attackTimer = attackCount;
			this.attackTrigger.enabled = true;
        }

		if (this.attacking) {
			if (this.attackTimer > 0) {
				this.attackTimer -= Time.deltaTime;
			} else {
				this.attacking = false;
				this.attackTrigger.enabled = false;
            } 
        }
		this.animation.SetBool("Attack", this.attacking);
    }

    void Awake() {
		this.animation = gameObject.GetComponent<Animator>();
		this.attackTrigger.enabled = false;
    }
}
