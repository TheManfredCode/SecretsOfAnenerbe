using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 70;
    bool timerRun = true;
    float timerValue = 0;
    public float obstacleOn = 3f;
    Renderer rend;
    Color c;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    private void Update()
    {
        if (timerRun == true)
        {
            timerValue += Time.deltaTime;
            //Debug.Log("-------STAY TIME" + stayTimeValue);
        }
    }

    public void FixedUpdate()
    {
        if (timerValue >= obstacleOn && timerValue < (obstacleOn * 2))
        {
            c.a = 0.5f;
            rend.material.color = c;
            Physics2D.IgnoreLayerCollision(8, 12, true);
        }
        else if (timerValue >= 0 && timerValue < obstacleOn)
        {
            c.a = 1f;
            rend.material.color = c;
            Physics2D.IgnoreLayerCollision(8, 12, false);
        }
        else
        {
            timerValue = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player _player = collision.collider.GetComponent<Player>();
        if (_player != null)
        {
            _player.damagePlayer(damage);
        }
    }


}
