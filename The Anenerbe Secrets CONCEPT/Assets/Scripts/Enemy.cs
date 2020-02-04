using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [HideInInspector]
    public bool movingRight = true;

    public Rigidbody2D rb;
    int currHealth = 200;
    public int maxHealth = 200;
    public int damage = 33;
    public float speed = 3f;
    public float timeToRotate;          //timer value (when change direction)
    public bool timerToRotate = true;   //timer activity (when change direction)
    public float patroolTime = 1f;      //time to change direction

    public RectTransform healthBar;
    public Text healthText;

    private void Start()
    {
        currHealth = maxHealth;
    }
    public void Update()
    {
        if (timerToRotate)
        {
            timeToRotate += Time.deltaTime;
        }

    }

    public void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        if (timeToRotate > patroolTime)
        {
            timeToRotate = 0;
            if (movingRight == true)
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;
            }
            else
            {

                movingRight = true;
            }
        }
    }

    public void takeDamage (int damage)
    {
        currHealth -= damage;
        setHealth(currHealth, maxHealth);

        if (currHealth <= 0 )
        {
            Destroy(gameObject);

        }
    }

    // Damage player if he collide with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player _player = collision.collider.GetComponent<Player>();
        if (_player != null)
        {
            _player.damagePlayer(damage);
        }
    }

    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        healthText.transform.Rotate(0f, 180f, 0f);
    }

    public void jump (float _jumpForce)
    {
        rb.AddForce(new Vector2(0f, _jumpForce));
    }

    // HealthBar
    public void setHealth (int _cur , int _max)
    {
        float _value = (float)_cur / _max;
        healthBar.localScale = new Vector3(_value, healthBar.localScale.y, healthBar.localScale.z);
        healthText.text = _cur + "/" + _max;
    }

}
