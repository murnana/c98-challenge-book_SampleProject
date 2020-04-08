using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// グリッドのマーク
/// </summary>
[RequireComponent(typeof(Image))]
public class GridMark : MonoBehaviour
{
    public Sprite m_OsTexture = null;
    public Sprite m_XsTexture = null;
    private Image m_Image = null;
    private Mark m_Mark = Mark.None;
    private Game m_Game = null;

    public Mark mark { get { return m_Mark; } }

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    private void Start()
    {
        m_Game = GetComponentInParent<Game>();

        this.ResetMark();
    }

    /// <summary>
    /// マークを初期状態にします
    /// </summary>
    public void ResetMark()
    {
        var texture = Texture2D.whiteTexture;
        m_Image.sprite = Sprite.Create(
            texture: texture,
            rect: new Rect(0, 0, texture.width, texture.height),
            pivot: new Vector2(0.5f, 0.5f),
            pixelsPerUnit: 100.0f);
        m_Mark = Mark.None;
    }

    /// <summary>
    /// グリッドが押されたら呼ばれます
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void OnClick()
    {
        // 既にマークが入っていたら、何もしない
        if (mark != Mark.None) return;

        var who = m_Game.WhoTurn();
        switch (who)
        {
            case Mark.O:
                m_Image.sprite = m_OsTexture;
                break;
            case Mark.X:
                m_Image.sprite = m_XsTexture;
                break;
            default:
                throw new NotImplementedException(who.ToString());
        }
        m_Mark = who;
        m_Game.GoNext();
    }
}
