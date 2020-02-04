using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDely = 2f;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    //public IEnumerator respawnPlayer()
    //{
    //    Debug.Log("RESPAWNING");
    //    yield return new WaitForSeconds (spawnDely);

    //    Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    //    Debug.Log("Welcome to HELL");
    //}
    public static void killPlayer(Player player)
    {
        Destroy(player.gameObject);
        Debug.Log("DEATH!!!!!");
        //gm.StartCoroutine(gm.respawnPlayer());
    }
}
