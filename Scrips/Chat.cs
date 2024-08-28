

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class Chat : NetworkBehaviour
{
   public static Chat Singleton;

   [SerializeField] TMPManager chatMessagePrefab;
   [SerializeField] CanvasGroup chatContent;
   [SerializeField] TMP_InputField chatInput;

   public string playerName;

   void Awake() 
   { Chat.Singleton = this; }

   void Update() 
   {
      if(Input.GetKeyDown(KeyCode.Return))
      {
         SendChatMessage(chatInput.text, playerName);
         chatInput.text = "";
      }
   }

   public void SendChatMessage(string _message, string _fromWho = null)
   { 
      if(string.IsNullOrWhiteSpace(_message)) return;

      string S = _fromWho + " > " +  _message;
      SendChatMessageServerRpc(S); 
   }
   
   void AddMessage(string msg)
   {
      TMPManager CM = Instantiate(chatMessagePrefab, chatContent.transform);
      CM.SetText(msg);
   }

   [ServerRpc(RequireOwnership = false)]
   void SendChatMessageServerRpc(string message)
   {
      ReceiveChatMessageClientRpc(message);
   }

   [ClientRpc]
   void ReceiveChatMessageClientRpc(string message)
   {
      Chat.Singleton.AddMessage(message);
   }
}



/*
 [SerializeField] 
   public InputField inputField;
   [SerializeField] 
   TextMeshProUGUI text;
        private void Start()
   {
      if (inputField != null)
      {
        OnSend();
      }
      Debug.Log("text");
      SubmittMessageRPC("Hello World");
   }

        private void Update()
        {
           if (Input.GetKeyDown(KeyCode.G))
           {
              OnSend();
           }
        }

        private void OnSend()
   {
      FixedString128Bytes message = new("Hello");
      SubmittMessageRPC(message);
   }
   [Rpc(SendTo.Server)]
   public void SubmittMessageRPC(FixedString128Bytes message)
   {
      UpdateMessageRPC(message+ "2");
      Debug.Log("Message Sent");
   }

   [Rpc(SendTo.Everyone)]
   public void UpdateMessageRPC(FixedString128Bytes message)
   {
      text.text = message.ToString();
      Debug.Log("Message Recived");
   }

 ------------
  [SerializeField] TextMeshProUGUI text;
 *  private void Start()
   {
      if (_inputField != null)
      {
         
      }
      Debug.Log("text");
      submittMessageRPC("Hello World");
   }

   private void OnSend()
   {
      FixedString128Bytes message = new("Hello");
      submittMessageRPC(message);
   }
   [Rpc(SendTo.Server)]
   void submittMessageRPC(FixedString128Bytes message)
   {
      
   }

   [Rpc(SendTo.Everyone)]
   public void UpdateMessageRPC(FixedString128Bytes message)
   {
      text.text = message.ToString()+"2";
      Debug.Log("Message Recived");
   }
 */
