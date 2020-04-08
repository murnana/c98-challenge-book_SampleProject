/// <summary>
/// ゲームの状態を管理するクラス
/// </summary>
public class GameManager
{
    /// <summary>
    /// 現在のゲームの状態
    /// </summary>
    /// <value></value>
    public GameState gameState { get; private set; }


    public GameManager()
    {
        this.gameState = GameState.WaitGameStart;
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    public void GameStart()
    {
        this.gameState = GameState.Gaming;
    }
}
