using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    Name nameScript;
    private void Start()
    {
        nameScript = GameObject.FindObjectOfType<Name>();
    }
    public void LoadNexLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        nameScript.GetPlayerName();
    }
}
