using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitMode : MonoBehaviour
{
    public Transform whoTrackTo;
    public Transform startPoint;    //raycast start
    public Transform finishPoint;   //drawline finish
    public float viewDistance;      //distance of player detection
    public float stopToFireDistance;

    public LayerMask whoToHit;      //what layer must not to be ignored by raycast
    public Enemy _enemy;            //body of object to manipulate of moving
    float normSpeed;
    public GameObject bulletPrefab; //bullet
    public Transform firePoint;
    float timeToFire = 0;
    public float fireRate = 4;      //fire rate parameter

    private void Start()
    {
        float normSpeed = _enemy.speed;
    }
    public void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position, startPoint.right, viewDistance, whoToHit);
        RaycastHit2D stopToFire = Physics2D.Raycast(startPoint.position, startPoint.right, stopToFireDistance, whoToHit);
        Debug.DrawLine(startPoint.position, finishPoint.position, Color.red);

        if (whoTrackTo.position.x > gameObject.transform.position.x && _enemy.movingRight == false)
        {
            _enemy.flip();
            _enemy.movingRight = true;
        }
        else if (whoTrackTo.position.x < gameObject.transform.position.x && _enemy.movingRight == true)
        {
            _enemy.flip();
            _enemy.movingRight = false;
        }
        if (hitInfo.collider != null)
        {
            _enemy.timerToRotate = false;
            _enemy.timeToRotate = 0f;
            if (Time.time >= timeToFire)
            {
                shoot();
                timeToFire = Time.time + 1 / fireRate;
            }
        }
        if (stopToFire.collider != null)
        {
            _enemy.speed = 0;
        }
        else if (stopToFire.collider == null)
        {
            _enemy.speed = 3f;
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
