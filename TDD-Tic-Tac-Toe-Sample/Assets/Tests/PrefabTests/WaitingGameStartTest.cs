using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    /// <summary>
    /// ゲーム開始前のPrefabテスト
    /// </summary>
    public class WaitingGameStartTest
    {
        public const string TestSceneName = "WaitingGameStartTestScene";
        public const string TestPrefabName = "Waiting GameStart";

        /// <summary>
        /// テスト関数の開始前に実行します
        /// </summary>
        /// <returns></returns>
        [UnitySetUp]
        public IEnumerator UnitySetUp()
        {
            yield return SceneManager.LoadSceneAsync(TestSceneName, LoadSceneMode.Additive);
            var scene = SceneManager.GetSceneByName(TestSceneName);
            SceneManager.SetActiveScene(scene);
        }

        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            yield return SceneManager.UnloadSceneAsync(TestSceneName);
        }

        /// <summary>
        /// テストシーンに遷移できてるか
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator CheckTestScene()
        {
            var scene = SceneManager.GetActiveScene();

            // ちゃんと読み込めたか
            Assert.That(scene.isLoaded, Is.True, "Scene is Loaded.");

            // シーン名も正しいか
            Assert.That(scene.name, Is.EqualTo(TestSceneName), $"Active Scene is '{TestSceneName}'");

            // テスト対象のPrefabを持ってこれるか
            var gameObject = GameObject.Find(TestPrefabName);
            Assert.That(gameObject, Is.Not.Null, $"Can find '{TestPrefabName}'");
            Assert.That(gameObject.name, Does.Contain(TestPrefabName), $"Can find '{TestPrefabName}'");

            yield return null;
        }

        [UnityTest]
        [Ignore("GameStateを持つ意味がない")]
        public IEnumerator GameStartでステートが変化する()
        {
            // WaitingGameStartコンポーネントを探す
            var waitingGameStart = GameObject.FindObjectOfType<WaitingGameStart>();
            Assume.That(waitingGameStart, Is.Not.Null, $"FindObjectOfType<{typeof(WaitingGameStart).ToString()}>");

            // GameManagerを持っている(初期値がnullなので渡す)
            waitingGameStart.gameManager = new GameManager();
            Assume.That(waitingGameStart.gameManager, Is.Not.Null, $"{typeof(WaitingGameStart).ToString()} have {typeof(GameManager).ToString()}");

            // GameManagerはGamingステートではないことを確認する
            Assume.That(waitingGameStart.gameManager.gameState, Is.Not.EqualTo(GameState.Gaming), $"GameManager is not start of Gaming.");

            // Game Start ButtonのButtonイベントを探す
            var gameStartButtonObjectName = "Game Start Button";
            var gameStartButtonObject = GameObject.Find(gameStartButtonObjectName);
            Assume.That(gameStartButtonObject, Is.Not.Null, $"Find({gameStartButtonObjectName})");
            var button = gameStartButtonObject.GetComponentInChildren<Button>();
            Assume.That(button, Is.Not.Null, $"{nameof(gameStartButtonObject)}.GetComponentInChildren<{typeof(Button).ToString()}>()");

            // Buttonを実行する
            var pointer = new PointerEventData(EventSystem.current);
            pointer.button = PointerEventData.InputButton.Left;
            button.OnPointerClick(pointer);

            // GameManagerのstateが変化しているのを確認する
            Assert.That(waitingGameStart.gameManager.gameState, Is.EqualTo(GameState.Gaming));

            yield return null;
        }

        [UnityTest]
        public IEnumerator GameStart前にOXを選択できる(
            [Values(Mark.O, Mark.X)] Mark selectMark
        )
        {
            // WaitingGameStartコンポーネントを探す
            var waitingGameStart = GameObject.FindObjectOfType<WaitingGameStart>();
            Assume.That(waitingGameStart, Is.Not.Null, $"FindObjectOfType<{typeof(WaitingGameStart).ToString()}>");

            // Mark O|X ButtonのButtonイベントを探す
            var selectButtonName = $"Mark {selectMark.ToString()} Button";
            var selectButton = GameObject.Find(selectButtonName);
            Assume.That(selectButton, Is.Not.Null, $"Find({selectButtonName})");
            var button = selectButton.GetComponentInChildren<Button>();
            Assume.That(button, Is.Not.Null, $"{nameof(selectButtonName)}.GetComponentInChildren<{typeof(Button).ToString()}>()");

            // Buttonを実行する
            var pointer = new PointerEventData(EventSystem.current);
            pointer.button = PointerEventData.InputButton.Left;
            button.OnPointerClick(pointer);

            // 誰が最初かがわかるようになっている
            Assert.That(waitingGameStart.firstMark, Is.EqualTo(selectMark));

            yield return null;
        }
    }
}
