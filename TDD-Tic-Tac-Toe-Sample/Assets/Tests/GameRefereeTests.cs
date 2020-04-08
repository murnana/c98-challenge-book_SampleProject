using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class GameRefereeTests
    {
        private static Mark[][] 勝敗が決まるパターンMarks => new[]
        {
            // 横一列 - 1行目
            new[]
            {
                Mark.O, Mark.O, Mark.O,
                Mark.X, Mark.None, Mark.None,
                Mark.X, Mark.None, Mark.None
            },

            // 横一列 - 2行目
            new[]
            {
                Mark.X, Mark.None, Mark.None,
                Mark.O, Mark.O, Mark.O,
                Mark.X, Mark.None, Mark.None
            },

            // 横一列 - 3行目
            new[]
            {
                Mark.X, Mark.None, Mark.None,
                Mark.X, Mark.None, Mark.None,
                Mark.O, Mark.O, Mark.O
            },

            // 縦一列 - 1列目
            new[]
            {
                Mark.O, Mark.None, Mark.None,
                Mark.O, Mark.None, Mark.None,
                Mark.O, Mark.X, Mark.X
            },

            // 縦一列 - 2列目
            new[]
            {
                Mark.None, Mark.O, Mark.None,
                Mark.None, Mark.O, Mark.None,
                Mark.X, Mark.O, Mark.X
            },

            // 縦一列 - 3列目
            new[]
            {
                Mark.None, Mark.None, Mark.O,
                Mark.None, Mark.None, Mark.O,
                Mark.X, Mark.X, Mark.O
            },

            // 左上から右下
            new[]
            {
                Mark.O, Mark.None, Mark.None,
                Mark.None, Mark.O, Mark.None,
                Mark.X, Mark.X, Mark.O
            },

            // 右上から左下
            new[]
            {
                Mark.None, Mark.None, Mark.O,
                Mark.None, Mark.O, Mark.None,
                Mark.O, Mark.X, Mark.X
            }
        };

        private static IEnumerable<TestCaseData> 勝敗が決まるパターンTestCaseData
        {
            get
            {
                foreach (var pattern in 勝敗が決まるパターンMarks)
                {
                    yield return new TestCaseData(
                        pattern,
                        Mark.O
                    );

                    yield return new TestCaseData(
                        pattern.Select(value =>
                        {
                            if (value == Mark.O) return Mark.X;
                            if (value == Mark.X) return Mark.O;
                            return value;
                        }).ToArray(),
                        Mark.X
                    );
                }
            }
        }

        private static IEnumerable<TestCaseData> 勝敗が未定のパターンTestCaseData
        {
            get
            {
                var patterns = new[]
                {
                    new[]
                    {
                        Mark.None, Mark.None, Mark.None,
                        Mark.None, Mark.None, Mark.None,
                        Mark.None, Mark.None, Mark.None
                    },

                    new[]
                    {
                        Mark.O, Mark.None, Mark.None,
                        Mark.X, Mark.None, Mark.None,
                        Mark.None, Mark.None, Mark.None
                    },

                    new[]
                    {
                        Mark.O, Mark.O, Mark.None,
                        Mark.X, Mark.None, Mark.None,
                        Mark.X, Mark.None, Mark.None
                    }
                };

                foreach (var pattern in patterns)
                {
                    yield return new TestCaseData(
                        pattern
                    );

                    yield return new TestCaseData(
                        pattern.Select(value =>
                        {
                            if (value == Mark.O) return Mark.X;
                            if (value == Mark.X) return Mark.O;
                            return value;
                        }).ToArray()
                    );
                }
            }
        }

        private static Mark[][] 引き分けのパターンMarks => new[]
        {
            new[]
            {
                Mark.X, Mark.O, Mark.O,
                Mark.O, Mark.O, Mark.X,
                Mark.X, Mark.X, Mark.O
            }
        };

        private static IEnumerable<TestCaseData> 引き分けのパターンTestCaseData
        {
            get
            {
                foreach (var pattern in 引き分けのパターンMarks)
                {
                    yield return new TestCaseData(
                        pattern
                    );

                    yield return new TestCaseData(
                        pattern.Select(value =>
                        {
                            if (value == Mark.O) return Mark.X;
                            if (value == Mark.X) return Mark.O;
                            return value;
                        }).ToArray()
                    );
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(勝敗が決まるパターンTestCaseData))]
        public void 勝敗が決まるパターン(Mark[] marks, Mark result)
        {
            Assume.That(marks, Is.Not.Null
                .And.Length.EqualTo(9));
            Assume.That(result, Is.Not.EqualTo(Mark.None));

            var referee = new GameReferee();
            Assert.That(referee.WhoWin(marks), Is.EqualTo(result));
        }

        [Test]
        [TestCaseSource(nameof(勝敗が未定のパターンTestCaseData))]
        public void 勝敗が未定のパターン(Mark[] marks)
        {
            Assume.That(marks, Is.Not.Null
                .And.Length.EqualTo(9));

            var referee = new GameReferee();
            Assert.That(referee.WhoWin(marks), Is.EqualTo(Mark.None));
        }

        [Test]
        [TestCaseSource(nameof(引き分けのパターンTestCaseData))]
        public void 引き分けのパターン(Mark[] marks)
        {
            Assume.That(marks, Is.Not.Null
                .And.Length.EqualTo(9));

            var referee = new GameReferee();
            Assert.That(referee.WhoWin(marks), Is.EqualTo(Mark.None));
        }

        private static IEnumerable<TestCaseData> ゲーム終了判定TestCaseData
        {
            get
            {
                foreach (var marks in 勝敗が決まるパターンMarks)
                {
                    yield return new TestCaseData(marks);
                    yield return new TestCaseData(marks.Select(value =>
                    {
                        if (value == Mark.O) return Mark.X;
                        if (value == Mark.X) return Mark.O;
                        return value;
                    }).ToArray());
                }

                foreach (var marks in 引き分けのパターンMarks)
                {
                    yield return new TestCaseData(marks);
                    yield return new TestCaseData(marks.Select(value =>
                    {
                        if (value == Mark.O) return Mark.X;
                        if (value == Mark.X) return Mark.O;
                        return value;
                    }).ToArray());
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(ゲーム終了判定TestCaseData))]
        public void ゲーム終了判定(Mark[] marks)
        {
            Assume.That(marks, Is.Not.Null
                .And.Length.EqualTo(9));

            var referee = new GameReferee();
            Assert.That(referee.IsGameOver(marks), Is.True);
        }
    }
}