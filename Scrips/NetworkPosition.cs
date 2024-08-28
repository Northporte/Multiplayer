using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class NetworkPosition : NetworkBehaviour
{
    public float offBound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > offBound)
        {
            Destroy(gameObject);
        }
    }
}
