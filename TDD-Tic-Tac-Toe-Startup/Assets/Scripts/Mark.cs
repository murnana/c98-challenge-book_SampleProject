using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark : MonoBehaviour
{
    public Sprite m_OsTexture;
    public Sprite m_XsTexture;
    public Image m_Image;
    public int m_Mark;

    public void OnClick()
    {
        if(Game.s_WhoTurn == 1)
        {
            m_Image.sprite = m_OsTexture;
            m_Mark = 1;
            Game.s_WhoTurn = 0;
        }
        else
        {
            m_Image.sprite = m_XsTexture;
            m_Mark = 2;
            Game.s_WhoTurn = 1;
        }
    }
}
