using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{

    public float speed = 8f;
    public float acceleration = 1f;
    public float destroyTime = 1f;
    public int damage = 50;
    public Rigidbody2D rb;

    private void Update()
    {
        Destroy(gameObject, destroyTime);
        speed += acceleration;
        rb.velocity = transform.right * speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyRocketman _rocketmanVisibleZone = collision.GetComponent<EnemyRocketman>();
        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        Player _player = collision.GetComponent<Player>();
        if (_player != null)
        {
            _player.damagePlayer(damage);
        }
        if (enemyBullet == null && _rocketmanVisibleZone == null)
        {
            Destroy(gameObject);
        }

    }

}


//transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 1f);
