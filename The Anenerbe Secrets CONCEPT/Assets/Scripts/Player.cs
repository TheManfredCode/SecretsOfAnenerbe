using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 200;
        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void init()
        {
            currentHealth = maxHealth;
        }
    }

    public PlayerStats playerStats = new PlayerStats();
    public int fallValue = -30;

    public void Start()
    {
        playerStats.init();
    }
    public void Update()
    {
        if (transform.position.y <= fallValue)
        {
            damagePlayer(playerStats.maxHealth);
        }
    }

    public void damagePlayer (int damage)
    {
        playerStats.currentHealth -= damage;
        Debug.Log("HIT!!!!!!!!!!!!");
        Debug.Log(playerStats.currentHealth);
        if(playerStats.currentHealth <=0 )
        {
            GameMaster.killPlayer(this);
        }
    }

}
