using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    private Player player;

	void Start () {
        player = FindObjectOfType<Player>();
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            player.Damage(1);

            player.Knockback();
        }
    }
}
