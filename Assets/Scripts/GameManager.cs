using UnityEngine;
using System.Collections;
using TMPro; // 1. ADICIONE ESTA LINHA PARA O TEXTMESHPRO

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;
    
    public int currentLevel = 1;
    public int scoreToWin = 5; 
    
    public P2 enemyAI;


    public TextMeshProUGUI messageText; 

    private void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
        
        SetDifficulty();
    }

    public void OnScoreZoneReached(int id)
    {
        if(id == 1)
        {
            scorePlayer1++;
        } 
        if(id == 2)
        {
            scorePlayer2++;
        } 

        UpdateScores();
        CheckWinCondition();
    }

    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    } 

    private void CheckWinCondition()
    {
        if (scorePlayer1 >= scoreToWin)
        {
            if (currentLevel < 3)
            {
                currentLevel++;
                StartCoroutine(ShowMessageAndPause("Nível " + currentLevel + "!", 2.5f));
                
                ResetScores();
                SetDifficulty();
            }
            else
            {
                StartCoroutine(ShowMessageAndPause("VOCÊ VENCEU O JOGO!\nPARABÉNS!", 4f));
                currentLevel = 1;
                ResetScores();
                SetDifficulty();
            }
        }
        else if (scorePlayer2 >= scoreToWin)
        {
            StartCoroutine(ShowMessageAndPause("A IA Venceu!\nReiniciando Nível " + currentLevel, 2.5f));
            ResetScores();
        }
    }

    private void ResetScores()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateScores();
    }

    private void SetDifficulty()
    {
        if (enemyAI != null)
        {
            switch (currentLevel)
            {
                case 1:
                    enemyAI.speed = 3f;
                    break;
                case 2:
                    enemyAI.speed = 5f;
                    break;
                case 3:
                    enemyAI.speed = 7f;
                    break;
            }
        }
    }

    private IEnumerator ShowMessageAndPause(string message, float delay)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true); 
        }
        
        Time.timeScale = 0f; 
        
        yield return new WaitForSecondsRealtime(delay); 
        
        Time.timeScale = 1f; 
        
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); 
        }
    }
}