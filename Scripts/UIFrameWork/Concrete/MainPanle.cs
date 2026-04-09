//==========================
// - FileName: MainPanle.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:
//==========================
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class MainPanle : BasePanel 
{
    static readonly string path = "Prefabs/UI/Panle/MainPanle";
    public MainPanle() : base( new UIType(path))
    {
    }
    public override void OnEnter()
    {
        Debug.Log("进入Main");
        UITool.GetOrAddCopmponentInChildren<Button>("BtnExit").onClick.AddListener(() =>
        {
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
            PanleManager.Pop();
        });
        UITool.GetOrAddCopmponentInChildren<Button>("BtnMail").onClick.AddListener(() =>
        {
            PanleManager.Push(new MailPlane());
        });
        /*
        UITool.GetOrAddCopmponentInChildren<Button>("BtnMsg").onClick.AddListener(() =>
        {
            /*
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
            PanleManager.Pop();
            
            //这里可以弹出一个任务面板
        });
        */
    }
}