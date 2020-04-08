using System;

public class WhoTurn
{
    private Mark m_NowMark;

    public WhoTurn(Mark firstMark)
    {
        if (firstMark == Mark.None)
        {
            throw new ArgumentException(
                message: firstMark.ToString(),
                paramName: nameof(firstMark)
            );
        }

        m_NowMark = firstMark;
    }

    /// <summary>
    /// 今誰のターンなのか
    /// </summary>
    /// <returns></returns>
    public Mark Who()
    {
        return m_NowMark;
    }

    /// <summary>
    /// 次は誰のターンなのか
    /// </summary>
    /// <returns></returns>
    public Mark Next()
    {
        switch (m_NowMark)
        {
            case Mark.O:
                return Mark.X;

            case Mark.X:
                return Mark.O;

            default:
                throw new InvalidOperationException($"{nameof(m_NowMark)} = {m_NowMark.ToString()}");
        }
    }

    /// <summary>
    /// 次、誰のターンなのか
    /// </summary>
    public void GoNext()
    {
        m_NowMark = Next();
    }
}
