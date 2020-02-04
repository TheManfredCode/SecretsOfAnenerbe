using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camSpeed = 10f;

    private Func<Vector3> getCameraFollowPositionFunc;
    public void setup (Func<Vector3> getCameraFollowPositionFunc)
    {
        this.getCameraFollowPositionFunc = getCameraFollowPositionFunc;
    }

    public void setGetCameraPositionFunc (Func<Vector3> getCameraFollowPositionFunc)
    {
        this.getCameraFollowPositionFunc = getCameraFollowPositionFunc;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Application.targetFrameRate = 5;
        Vector3 cameraFollowPosition = getCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);

        if (distance > 0)
        {
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * camSpeed * Time.deltaTime;
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if(distanceAfterMoving > distance)
            {
                // Overshot the target
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }
}
