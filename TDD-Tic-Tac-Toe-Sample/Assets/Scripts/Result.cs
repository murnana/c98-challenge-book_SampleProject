using System;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Text m_ResultText = default;
    [SerializeField] private WaitingGameStart m_GameStart = default;
    [SerializeField] private Game m_Game = default;

    public void ShowResult(in GameReferee referee, in Mark[] marks)
    {
        if (referee == null)
        {
            throw new ArgumentNullException(nameof(referee));
        }

        if (marks == null)
        {
            throw new ArgumentNullException(nameof(marks));
        }

        if (marks.Length != 9)
        {
            throw new ArgumentException($"{nameof(marks.Length)} == 9 but was {marks.Length}.", nameof(marks));
        }

        if (!referee.IsGameOver(marks))
        {
            throw new ArgumentException(
                "Game is not over.",
                nameof(marks)
            );
        }

        // 誰が勝ったのか
        var whoWin = referee.WhoWin(marks);

        switch (whoWin)
        {
            case Mark.O:
                m_ResultText.text = "O's Win!";
                break;
            case Mark.X:
                m_ResultText.text = "X's Win!";
                break;
            default:
                m_ResultText.text = "Draw";
                break;
        }

        // 結果をアクティベートする
        gameObject.SetActive(true);
    }

    /// <summary>
    /// ゲームを再スタートさせます
    /// </summary>
    public void OnRestartGame()
    {
        gameObject.SetActive(false);
        m_GameStart.ResetWaitingGame();
        m_Game.ResetGame();
    }
}