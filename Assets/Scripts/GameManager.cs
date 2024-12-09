using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI leftPlayerScoreText;
    public TextMeshProUGUI rightPlayerScoreText;
    public TextMeshProUGUI winnerText;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;

    private int maxScore = 5;
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
        winnerText.text = $"{winner} ha ganado!";

        FindObjectOfType<Ball>().StopBall();


    }

}
