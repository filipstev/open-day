using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Name : MonoBehaviour
{
    public string playerName;
    [SerializeField]
    TMP_InputField input;

    public static Name instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void GetPlayerName()
    {
        playerName = input.text;
        Debug.Log(playerName);
    }
}
