using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject resultPanel;
    public Text resultText;

    public FightingController[] fightingController;
    public OpponentAI[] opponentAI;

    private void Update()
    {
        foreach (OpponentAI opponentAI in opponentAI)
        {
            if (opponentAI.gameObject.activeSelf && opponentAI.currentHealth <= 0)
            {
                SetResult("You Win");
                return;
            }
        }

        foreach (FightingController fightingController in fightingController)
        {
            if (fightingController.gameObject.activeSelf && fightingController.currentHealth <= 0)
            {
                SetResult("You lost");
                return;
            }
        }
    }

    void SetResult(string result)
    {
        resultText.text = result;
        resultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
