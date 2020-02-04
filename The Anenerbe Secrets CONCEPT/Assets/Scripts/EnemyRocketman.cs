using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketman : MonoBehaviour
{
    public Transform firePointt;   //start point for missile
    public GameObject rocketPref;  //the missile

    public int offset = 0;         //angle for shooting
    Vector3 playerPosition = new Vector3 (0, 0, 0);//this vector contain player position coordinates
    float timeToFire = 0;
    public float fireRate = 5;     //fire rate paramter

    private void Update()
    {
        
        //calculating rocketman weapon angle oriented to player
        Vector3 difference = playerPosition - transform.position;
        difference.Normalize();
        float angleZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angleZ + offset);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player _player = collision.GetComponent<Player>();
        if (_player != null)
        {
            //getting parameters for aiming
            playerPosition = collision.transform.position;

            //shooting
            //if (Time.time >= timeToFire)
            //{
            //    shoot();
            //    timeToFire = Time.time + 1 / fireRate;
            //}
        }
        
        
    }
    //shoot metod
    void shoot ()
    {
        Instantiate(rocketPref, firePointt.position, firePointt.rotation);
    }

}
