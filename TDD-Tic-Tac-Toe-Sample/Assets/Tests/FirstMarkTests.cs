using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// 最初のマークを選択するためのテストコード
    /// </summary>
    public class FirstMarkTests
    {
        [Test]
        public void FirstMarkは最初は誰がスタートするかを知っている(
            [Values(Mark.O, Mark.X)] Mark select
        )
        {
            var start = new FirstMark();

            // 最初のマークは書き換え可能
            start.mark = select;

            // Who() で先ほど入れたマークが返ってくる
            Assert.That(
                actual: start.Who(),
                expression: Is.EqualTo(select)
            );
        }
    }
}
