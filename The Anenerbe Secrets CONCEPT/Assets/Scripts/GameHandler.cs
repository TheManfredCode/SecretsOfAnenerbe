using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public CameraMovement cameraFollow;
    public Transform playerTransform;
    public Transform sniperModeTransform;

    private bool playerCamBool;

    void Start()
    {
        playerCamBool = true;

        cameraFollow.setup(() => playerTransform.position);


    }
    private void Update()
    {
        cameraSwitch();
    }


    private void cameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerCamBool == true)
            {
                cameraFollow.setGetCameraPositionFunc(() => sniperModeTransform.position);
                playerCamBool = false;
            }
            else if (playerCamBool == false)
            {
                cameraFollow.setGetCameraPositionFunc(() => playerTransform.position);
                playerCamBool = true;
            }

        }
    }
}
