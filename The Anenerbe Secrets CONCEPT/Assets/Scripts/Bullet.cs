using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 80f;
    public int uhhDamage = 51;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;

		
	}
    private void Update()
    {
        Destroy(gameObject, 0.4f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);

        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyRocketman _rocketmanVisibleZone = collision.GetComponent<EnemyRocketman>();

        if (enemy != null)
        {
            enemy.takeDamage(uhhDamage);
            //if (_rocketmanVisibleZone == null)
            //{
            //    Destroy(gameObject);
            //}
        }
        
    }

}
