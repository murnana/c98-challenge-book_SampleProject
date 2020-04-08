using System;
using System.Linq;

public class GameReferee
{
    /// <summary>
    ///     誰が勝ったのかを判定します
    /// </summary>
    /// <param name="marks">判定したいmarkの配列</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">引数がnullのとき</exception>
    /// <exception cref="ArgumentException">marksの長さが9ではなかった</exception>
    public Mark WhoWin(Mark[] marks)
    {
        // marksはnullであってはならない
        if (marks == null) throw new ArgumentNullException(nameof(marks));

        // marksの長さは9でなければならない
        if (marks.Length != 9)
            throw new ArgumentException(
                $"{nameof(marks.Length)} = 9 but was {marks.Length}",
                nameof(marks)
            );

        // 横1行目
        if (marks[0] == marks[1]
            && marks[0] == marks[2]
            && marks[0] != Mark.None)
            return marks[0];

        // 横2行目
        if (marks[3] == marks[4]
            && marks[3] == marks[5]
            && marks[3] != Mark.None)
            return marks[3];

        // 横3行目
        if (marks[6] == marks[7]
            && marks[6] == marks[8]
            && marks[6] != Mark.None)
            return marks[6];

        // 縦1列目
        if (marks[0] == marks[3]
            && marks[0] == marks[6]
            && marks[0] != Mark.None)
            return marks[0];

        // 縦2列目
        if (marks[1] == marks[4]
            && marks[1] == marks[7]
            && marks[1] != Mark.None)
            return marks[1];

        // 縦3列目
        if (marks[2] == marks[5]
            && marks[2] == marks[8]
            && marks[2] != Mark.None)
            return marks[2];


        // 左上から右下
        if (marks[0] == marks[4]
            && marks[0] == marks[8]
            && marks[0] != Mark.None)
            return marks[0];

        // 右上から左下
        if (marks[2] == marks[4]
            && marks[2] == marks[6]
            && marks[2] != Mark.None)
            return marks[2];

        return Mark.None;
    }

    /// <summary>
    /// ゲーム終了の状態なのか
    /// </summary>
    /// <param name="marks">マス目のマーク配列</param>
    /// <returns>終了時にtrueを返却します。終了していなければfalseを返却しまsじゅ</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public bool IsGameOver(Mark[] marks)
    {
        // marksはnullであってはならない
        if (marks == null) throw new ArgumentNullException(nameof(marks));

        // marksの長さは9でなければならない
        if (marks.Length != 9)
            throw new ArgumentException(
                $"{nameof(marks.Length)} = 9 but was {marks.Length}",
                nameof(marks)
            );

        // 勝敗を決したのか
        if (WhoWin(marks) != Mark.None) return true;

        // Noneが埋まったのか
        return (marks.All(value => value != Mark.None));
    }
}