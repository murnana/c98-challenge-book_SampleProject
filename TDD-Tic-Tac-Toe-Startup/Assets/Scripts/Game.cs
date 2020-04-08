using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static int s_WhoTurn = 0;
    public Mark[] m_Marks;
    public GameObject m_Result;
    public Text m_ResultText;

    public void Update()
    {
        // 横1行目
        if (m_Marks[0].m_Mark == m_Marks[1].m_Mark
         && m_Marks[0].m_Mark == m_Marks[2].m_Mark
         && m_Marks[0].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[0].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 横2行目
        if (m_Marks[3].m_Mark == m_Marks[4].m_Mark
         && m_Marks[3].m_Mark == m_Marks[5].m_Mark
         && m_Marks[3].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[3].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 横3行目
        if (m_Marks[6].m_Mark == m_Marks[7].m_Mark
         && m_Marks[6].m_Mark == m_Marks[8].m_Mark
         && m_Marks[6].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[6].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 縦1列目
        if (m_Marks[0].m_Mark == m_Marks[3].m_Mark
         && m_Marks[0].m_Mark == m_Marks[6].m_Mark
         && m_Marks[0].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[0].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 縦2列目
        if (m_Marks[1].m_Mark == m_Marks[4].m_Mark
         && m_Marks[1].m_Mark == m_Marks[7].m_Mark
         && m_Marks[1].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[1].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 縦3列目
        if (m_Marks[2].m_Mark == m_Marks[5].m_Mark
         && m_Marks[2].m_Mark == m_Marks[8].m_Mark
         && m_Marks[2].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[2].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }


        // 左上から右下
        if (m_Marks[0].m_Mark == m_Marks[4].m_Mark
         && m_Marks[0].m_Mark == m_Marks[8].m_Mark
         && m_Marks[0].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[0].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }

        // 右上から左下
        if (m_Marks[2].m_Mark == m_Marks[4].m_Mark
         && m_Marks[2].m_Mark == m_Marks[6].m_Mark
         && m_Marks[2].m_Mark != 0)
        {
            m_Result.SetActive(true);
            if (m_Marks[2].m_Mark == 1)
            {
                m_ResultText.text = "O's Win!";
            }
            else
            {
                m_ResultText.text = "X's Win!";
            }
        }
    }
}
