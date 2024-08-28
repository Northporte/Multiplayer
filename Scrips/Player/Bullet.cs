using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;


public class Bullet : NetworkBehaviour
{
    public NetworkObject a,b,c;
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemi"))
        {
            Destroy(other.gameObject);
            Destroy(a);
            Destroy(b);
            Destroy(c);
        }

        
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
