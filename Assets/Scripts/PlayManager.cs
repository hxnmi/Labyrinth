using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject nextLevel;
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent WinSound;
    public UnityEvent GameOverSound;
    [SerializeField] private int coin;
    public UnityEvent<int> OnScoreUpdate;

    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        playerWinEvent.OnInvoked.AddListener(PlayerWin);
        OnStart.Invoke();
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        playerWinEvent.OnInvoked.RemoveListener(PlayerWin);
    }

    public void GameOver()
    {
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
        optionsPanel.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        GameOverSound.Invoke();
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!\nScore: " + GetScore();
        finishedCanvas.SetActive(true);
        optionsPanel.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(true);
        WinSound.Invoke();
    }

    public void AddCoin(int CoinData)
    {
        this.coin += CoinData;
        OnScoreUpdate.Invoke(GetScore());
    }
    private int GetScore()
    {
        return coin;
    }
}
