using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPManager : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI messageText;

   public void SetText(string strng) {
      messageText.text = strng;
   }
}
