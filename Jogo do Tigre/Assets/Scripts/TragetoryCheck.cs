using UnityEngine;
using System.Collections;

public class TragetoryCheck : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemyNoAttack enemy = collider.gameObject.GetComponent<EnemyNoAttack>();
            enemy.horizontalSpeed = -enemy.horizontalSpeed;
        }
    }
}
