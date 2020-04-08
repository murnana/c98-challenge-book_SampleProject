using UnityEngine;

/// <summary>
/// ゲーム開始前を司るクラス
/// </summary>
public class WaitingGameStart : MonoBehaviour
{
    [SerializeField]
    private Game m_Game = default;

    private FirstMark m_FirstMark = new FirstMark();

    /// <summary>
    /// ゲームマネージャークラス
    /// </summary>
    /// <value></value>
    public GameManager gameManager { get; set; } = new GameManager();

    /// <summary>
    /// ゲーム開始時のマークを返却します
    /// </summary>
    /// <returns></returns>
    public Mark firstMark { get { return m_FirstMark.Who(); } }

    /// <summary>
    /// ゲーム開始時、「Game Start」ボタンから呼ばれます
    /// </summary>
    public void OnClickGameStart()
    {
        gameManager.GameStart();
        m_Game.SetFirstMark(m_FirstMark.Who());
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ゲームを最初からやり直します
    /// </summary>
    public void ResetWaitingGame()
    {
        m_FirstMark = new FirstMark();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 最初のマークを選択します
    /// HACK: onClickでは、enumを指定する事ができないので、intで代用する
    /// </summary>
    /// <param name="mark"></param>
    public void SelectMark(int mark)
    {
        if ((Mark)mark == Mark.None)
        {
            // Noneは入れちゃダメ！
            throw new System.ArgumentException($"Not use {Mark.None.ToString()}", nameof(mark));
        }
        m_FirstMark.mark = (Mark)mark;
    }
}
