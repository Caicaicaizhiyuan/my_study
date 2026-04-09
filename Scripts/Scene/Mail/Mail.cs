//==========================
// - FileName: Mail.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mail
{
    private Text m_Title; 
    public int ID;
    private Button m_Button;
    private Text m_Mail;
    public Mail( GameObject go)
    {
        m_Title = UITool.GetChild(go, "Text").transform.GetComponent<Text>();
        m_Button=go.GetComponent<Button>();
    }
    public void Init(int idx,Text ShowText)
    {
        m_Title.text = "Mail第" +idx + "个";
        ID = idx;
        m_Button.onClick.AddListener(() =>{
            ShowText.text = "点击了第"+idx+"个邮件";
        });
    }
}