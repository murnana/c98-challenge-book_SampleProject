using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// ゲームの状態を管理するクラスのテスト
    /// </summary>
    public class GameManagerTests
    {
        [Test]
        public void GameManagerはゲームの状態を持ち_最初はゲームが始まっていない()
        {
            var manager = new GameManager();

            // 初期状態は「ゲーム待機」
            Assert.That(
                actual: manager.gameState,
                expression: Is.EqualTo(GameState.WaitGameStart)
            );
        }

        [Test]
        public void GameManagerはゲームの状態を持ち_ゲームが開始したら書き換え可能()
        {
            var manager = new GameManager();

            // ゲーム開始
            manager.GameStart();

            // ゲーム中の状態になる
            Assert.That(
                actual: manager.gameState,
                expression: Is.EqualTo(GameState.Gaming)
            );
        }
    }
}
