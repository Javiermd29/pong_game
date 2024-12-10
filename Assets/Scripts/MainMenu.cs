using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject startGameButton;

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
