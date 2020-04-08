using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class WhoTurnTests
    {
        [Test]
        public void コンストラクタ(
            [Values(Mark.O, Mark.X)] Mark firstMark
        )
        {
            Assert.DoesNotThrow(() =>
            {
                var whoTurn = new WhoTurn(firstMark: firstMark);
            });
        }

        [Test]
        public void コンストラクタは初期値がNoneのときは例外を投げる(
            [Values(Mark.None)] Mark firstMark
        )
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var whoTurn = new WhoTurn(firstMark: firstMark);
            });
        }

        private static IEnumerable<TestCaseData> WhoNextTurnSource
        {
            get
            {
                yield return new TestCaseData(
                    Mark.O,
                    Mark.X
                );

                yield return new TestCaseData(
                    Mark.X,
                    Mark.O
                );
            }
        }

        [Test]
        [TestCaseSource(nameof(WhoNextTurnSource))]
        public void 次のターンを回せる(
            Mark firstMark,
            Mark nextMark
        )
        {
            var whoTurn = new WhoTurn(firstMark: firstMark);
            Assume.That(whoTurn.Who(), Is.EqualTo(firstMark));
            Assume.That(whoTurn.Next(), Is.EqualTo(nextMark));

            Assert.DoesNotThrow(() =>
            {
                whoTurn.GoNext();
            });

            // 入れ替わっている
            Assert.That(whoTurn.Who(), Is.EqualTo(nextMark));
            Assert.That(whoTurn.Next(), Is.EqualTo(firstMark));
        }
    }
}
