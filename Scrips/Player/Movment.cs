using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;
using Unity.VisualScripting;
using UnityEngine.UI;


[SerializeField]
public class Movment : NetworkBehaviour

{

    public CharacterController controller;

   


    [SerializeField] public NetworkVariable<Vector3> playerVelocity;

    [SerializeField]
    private float speed;
    
    
    [SerializeField]
    public NetworkObject Bullets;
    public NetworkObject player;

    public GameObject obj;
    [SerializeField]
    public float bulletspeed;
    
    public float timebetweenshots;
    private bool fireContinuous;
    public float lasttimeFired;
  
    
    void Update()
    {
        
        if (IsServer) {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                   
            if (move != Vector3.zero && IsLocalPlayer) {
                gameObject.transform.forward = move;
            }
           
                  
                   
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (fireContinuous) {
                float lastShot = Time.time - lasttimeFired;
                
                if (lastShot >= timebetweenshots) {
                    lasttimeFired = Time.time;
                }
            }

            var transform1 = transform;
            NetworkObject bullet = Instantiate(Bullets, transform1.position, transform1.rotation);
          
            Bullets =obj.GetComponent<NetworkObject>();
            controller.Move(playerVelocity.Value * Time.deltaTime * bulletspeed);
            Debug.Log("work");

        }

      
        
    }

    
    

    [Rpc(SendTo.Everyone)]
    private void RPC(Vector3 data)
    {
        playerVelocity.Value = data;
                                                                        
    }

    private void OnFire()
    {
        
    }
  

   
}


/*
  controller.Move(playerVelocity* Time.deltaTime * playerSpeed);private CharacterController controller;
                                                                
                                                                    [SerializeField]
                                                                    NetworkVariable<Vector3> playerVelocity,playerVelocity2 = new NetworkVariable<Vector3>();
                                                                
                                                                    [SerializeField]
                                                                    private float playerSpeed = 2.0f;
                                                                
                                                                    [SerializeField]
                                                                    public float constSpeed;
                                                                    
                                                                    [SerializeField]
                                                                    public NetworkRigidbody rb;
                                                                
                                                                    public GameObject Bullets;
                                                                    [SerializeField]
                                                                    public float bullet;
                                                                  
                                                                
                                                                    public float timebetweenshots;
                                                                    private bool fireContinuous;
                                                                    public float lasttimeFired;
                                                                  
                                                                  
                                                                 
                                                                   
                                                                
                                                                    void Update()
                                                                    {
                                                                        
                                                                        if (IsServer) {
                                                                           Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                                                                                   
                                                                                   if (move != Vector3.zero && IsLocalPlayer) {
                                                                                       gameObject.transform.forward = move;
                                                                                   }
                                                                                   controller.Move(playerVelocity.Value  * Time.deltaTime * playerSpeed); 
                                                                                   
                                                                        }
                                                                        if (Input.GetKeyDown(KeyCode.Space)) {
                                                                            if (fireContinuous) {
                                                                                float lastShot = Time.time - lasttimeFired;
                                                                                
                                                                                if (lastShot >= timebetweenshots) {
                                                                                    Space();
                                                                                }
                                                                            }
                                                                            GameObject bullets = Instantiate(Bullets,transform.position,transform.rotation);
                                                                            lasttimeFired = Time.time;
                                                                
                                                                        }
                                                                
                                                                        rb = Bullets.GetComponent<NetworkRigidbody>();
                                                                        
                                                                        transform.Translate(Vector3.forward * Time.deltaTime * bullet);
                                                                        
                                                                    }
                                                                
                                                                    void player2(Vector3 data2)
                                                                    { 
                                                                    }
                                                                    
                                                                
                                                                    [Rpc(SendTo.Everyone)]
                                                                    private void RPC(Vector3 data)
                                                                    {
                                                                        playerVelocity.Value = data;
                                                                        
                                                                    }
        return default;
 ----
 [SerializeField]
    private float gravityValue = -9.81f;
      playerVelocity.y += gravityValue * Time.deltaTime;
 ----------
 *  if (Input.GetButtonDown("Jump") && isOnGround )
        {
            playerVelocity.y += Mathf.Sqrt(jump * -3.0f * gravityValue);
        }
          if (Input.GetKeyDown(KeyCode.Space) && isOnGround )
        {
            rb.for(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
        }
        
        
 */

