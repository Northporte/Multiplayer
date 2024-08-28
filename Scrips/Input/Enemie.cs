using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemie : MonoBehaviour
{
    public float speed;
    public float health;
    public bool hit;
    public GameObject[] prefabs;
    private float SpawnRange = 20;
    private float Spawnpos = 20;
    void Start()
    {
       
    }

    [Rpc(SendTo.Everyone)]
    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRange, SpawnRange),0, Spawnpos);
            int enimyIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[enimyIndex], spawnPos, prefabs[enimyIndex].transform.rotation);
        }
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        
    }
    
}
