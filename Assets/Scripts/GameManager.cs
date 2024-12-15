using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI leftPlayerScoreText;
    public TextMeshProUGUI rightPlayerScoreText;
    public TextMeshProUGUI winnerText;

    public GameObject winButtonCanvas;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;

    public int maxScore = 5;
    private bool gameOver = false;


    public void GoalScored(bool isRightPlayer)
    {

        if (gameOver) return;

        if (isRightPlayer)
        {
            rightPlayerScore++;
        }
        else
        {
            leftPlayerScore++;
        }

        UpdateScoreUI();

        if (rightPlayerScore >= maxScore)
        {
            EndGame("Player 2");
        }
        else if (leftPlayerScore >= maxScore)
        {
            EndGame("Player 1");
        }

    }

    void UpdateScoreUI()
    {
        leftPlayerScoreText.text = leftPlayerScore.ToString();
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }

    private void EndGame(string winner)
    {
        gameOver = true;

        winnerText.gameObject.SetActive(true);
        winButtonCanvas.SetActive(true);

        winnerText.text = $"{winner} ha ganado!";

        FindObjectOfType<Ball>().StopBall();
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(0);

    }

    public void MainMenu()
    {

        SceneManager.LoadScene(1);
    }


}
