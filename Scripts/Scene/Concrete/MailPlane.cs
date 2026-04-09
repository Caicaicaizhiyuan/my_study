//==========================
// - FileName: NewBehaviourScript.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:
//==========================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;


public class MailPlane : BasePanel
{
    static readonly string path = "Prefabs/UI/Panle/Mail";
    private List<Mail> MailGoList= new List<Mail>();
    private GameObject m_Mail;
    private GameObject m_Content;
    private Text m_ShowText;
    public MailPlane():base(new UIType(path))
    {
    }
    public override void OnEnter()
    {
        Debug.Log("Ω¯»ÎMail");
        UITool.GetOrAddCopmponentInChildren<Button>("Exit").onClick.AddListener(() =>
        {
            PanleManager.Pop();
        });
        m_Mail = GameObject.Find("Mail/ScrollView/Viewport/Content/MailClone");
        m_Content = GameObject.Find("Mail/ScrollView/Viewport/Content");
        m_ShowText = UITool.GetOrAddCopmponentInChildren<Text>("ShowText").transform.GetComponent<Text>();
        int mailNum = MailGoList.Count;
        for(int i = mailNum; i < 10; i++)
        {
            var go = UITool.CloneGameObject(m_Mail, m_Content.transform);
            go.SetActive(true);
            var mail=new Mail(go);
            mail.Init(i, m_ShowText);
            MailGoList.Add(mail);
        }

    }
    

}