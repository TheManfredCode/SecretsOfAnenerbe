using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBich : MonoBehaviour
{
    
    void FixedUpdate()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 1f);
    }
}
