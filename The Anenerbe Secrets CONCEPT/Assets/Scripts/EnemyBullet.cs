using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTime = 0.3f;
    public int damage = 10;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;


    }
    private void Update()
    {
        Destroy(gameObject, destroyTime);

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
