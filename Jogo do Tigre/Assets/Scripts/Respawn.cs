using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform startingPos;

    private Player player;
    private Transform currentRespawn;
    private Rigidbody2D body;
    
    void Start() {
        player = gameObject.GetComponent<Player>();
        currentRespawn = startingPos;
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (transform.position.y < -10) {
            RespawnPlayer();
        }
    }

    public void NewSpawnPoint(Transform newSpawn) {
        currentRespawn = newSpawn;
    }

    public void RespawnPlayer() {
        player.Damage(1);
        transform.position = currentRespawn.position;
        body.velocity = Vector2.zero;
    }
}
