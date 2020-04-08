using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameReferee m_Referee = new GameReferee();
    public GridMark[] m_Marks = default;
    public Result m_Result = default;

    private WhoTurn m_WhoTurn;

    public void ResetGame()
    {
        foreach (var gridMark in m_Marks)
        {
            gridMark.ResetMark();
        }

        m_Referee = new GameReferee();
    }

    /// <summary>
    ///     ターンの最初のマークをセットします
    /// </summary>
    /// <param name="firstMark"></param>
    public void SetFirstMark(Mark firstMark)
    {
        m_WhoTurn = new WhoTurn(firstMark);
    }

    /// <summary>
    ///     今誰のターンなのか
    /// </summary>
    /// <returns></returns>
    public Mark WhoTurn()
    {
        return m_WhoTurn.Who();
    }

    public void GoNext()
    {
        m_WhoTurn.GoNext();
    }

    private void Update()
    {
        var marks = m_Marks.Select(value => value.mark).ToArray();
        var isGameOver = m_Referee.IsGameOver(marks);

        if (isGameOver)
        {
            m_Result.ShowResult(m_Referee, marks);
        }
    }
}