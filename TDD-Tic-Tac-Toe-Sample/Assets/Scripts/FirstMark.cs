/// <summary>
/// ゲーム開始時の最初のマーク
/// </summary>
public class FirstMark
{
    /// <summary>
    /// 最初のマークは書き換え可能
    /// </summary>
    /// <value></value>
    public Mark mark { get; set; }

    /// <summary>
    /// 誰が最初かを返却
    /// </summary>
    /// <returns></returns>
    public Mark Who()
    {
        return this.mark;
    }
}
