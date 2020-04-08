using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// マス目のマークのテスト
    /// </summary>
    public class GridMarkTests
    {
        public const string TestSceneName = "GameScene";

        private Game m_Game = default;
        private GridMark m_GridMark = default;

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

            m_Game = GameObject.FindObjectOfType<Game>();
            Assume.That(m_Game, Is.Not.Null);
            m_Game.SetFirstMark(Mark.O);    // 初期値を O とする

            m_GridMark = GameObject.FindObjectOfType<GridMark>();
            Assume.That(m_GridMark, Is.Not.Null);

            // テクスチャは仮置きする
            var texture = Texture2D.whiteTexture;
            var dummySprite = Sprite.Create(
                texture: texture,
                rect: new Rect(0, 0, texture.width, texture.height),
                pivot: new Vector2(0.5f, 0.5f),
                pixelsPerUnit: 100.0f);
            m_GridMark.m_OsTexture = dummySprite;
            m_GridMark.m_XsTexture = dummySprite;

            Assume.That(m_GridMark.mark, Is.EqualTo(Mark.None));
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            yield return SceneManager.UnloadSceneAsync(TestSceneName);
        }


        [UnityTest]
        public IEnumerator 一度おいたマス目は二度とマークを変更できない()
        {
            // マークを変更する
            m_GridMark.OnClick();
            var mark = m_GridMark.mark;
            var whoTurn = m_Game.WhoTurn();

            yield return null;

            // もう一度マークを変更しようとしても、マークは変わらない
            Assert.DoesNotThrow(() =>
            {
                m_GridMark.OnClick();
            });
            Assert.That(m_GridMark.mark, Is.EqualTo(mark));

            // ターンも変わらない
            Assert.That(m_Game.WhoTurn(), Is.EqualTo(whoTurn));
        }
    }
}
