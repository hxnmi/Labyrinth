using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    int coin = 100;
    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        gameOverEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        gameOverEvent.OnInvoked.RemoveListener(PlayerWin);
    }

    public void GameOver()
    {
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!\nScore:";
        finishedCanvas.SetActive(true);
    }

    private int GetScore()
    {
        return coin * 10;
    }
}
