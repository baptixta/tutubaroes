using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
        audioManager.PlaySound("Music");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
