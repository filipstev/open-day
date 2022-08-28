using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    Name nameScript;
    [SerializeField]
    TMP_Text playerName;

    void Start()
    {
        
        nameScript = GameObject.FindObjectOfType<Name>();
        playerName.text = "Player: \n" + nameScript.playerName;
    }

 
}
