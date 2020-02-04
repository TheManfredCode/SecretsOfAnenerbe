using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmMode : MonoBehaviour
{
    public Transform startPoint;    //raycast start
    public Transform finishPoint;   //drawline finish
    public float viewDistance;      //distance of player detection

    public LayerMask whoToHit;      //what layer must not to be ignored by raycast
    public Enemy _enemy;            //body of object to manipulate of moving 
    public GameObject bulletPrefab; //bullet
    public Transform firePoint;     //fire point

    float shootTimeValue;           //timer value (time for aiming at player)   
    bool shootTimeRun = false;      //timer activity parameter (time for aiming at player) 
    float stayTimeValue;            //timer value (when to stop for aiming and waiting player)
    bool stayTimeRun = false;       //timer activity parameter (when to stop for aiming and waiting player) 
    float timeToFire = 0;
    public float fireRate = 4;      //fire rate parameter
    public bool ifRotate = true;    //rotating switcher
    float normalSpeed;

    private void Awake()
    {
        normalSpeed = _enemy.speed;
    }
    private void Update()
    {
        if (stayTimeRun == true)
        {
            stayTimeValue += Time.deltaTime;
            //Debug.Log("-------STAY TIME" + stayTimeValue);
        }
        if(shootTimeRun == true)
        {
            shootTimeValue += Time.deltaTime;
            //Debug.Log("-SHOOT TIME" + shootTimeValue);

        }
    }
    public void FixedUpdate()
    {
        Vector3 dst = new Vector3(viewDistance, 0, 0);
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position, startPoint.right, viewDistance , whoToHit);
        Debug.DrawLine(startPoint.position , finishPoint.position , Color.red);

        //alarm mode 
        if (hitInfo.collider != null)
        {
            //Debug.Log("ALAAARM!!!");
            stayTimeRun = true;
            shootTimeRun = true;
            _enemy.speed = 0f;
            _enemy.timerToRotate = false;
            if (shootTimeValue > 1f)
            {
                //Debug.Log("-----SHOOT------>>");
                if (Time.time >= timeToFire)
                {
                    shoot();
                    timeToFire = Time.time + 1 / fireRate;
                }
                stayTimeValue = 0;

            }
        }
        else
        {
            shootTimeRun = false;
            if (stayTimeValue > 4)
            {
                _enemy.speed = normalSpeed;
                _enemy.timerToRotate = ifRotate;
                stayTimeRun = false;
                stayTimeValue = 0f;
                shootTimeValue = 0;
            }

        }

    }
    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

}