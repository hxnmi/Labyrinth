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
    public UnityEvent OnStart = new UnityEvent();
    int coin = 100;
    public UnityEvent WinSound;
    public UnityEvent GameOverSound;
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
        GameOverSound.Invoke();
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!\nScore:";
        finishedCanvas.SetActive(true);
        optionsPanel.gameObject.SetActive(false);
        WinSound.Invoke();
    }

    private int GetScore()
    {
        return coin * 10;
    }
}
