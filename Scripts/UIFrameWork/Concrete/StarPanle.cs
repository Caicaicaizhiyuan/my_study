//==========================
// - FileName: StarPanle.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: 开始面板
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarPanle : BasePanel
{
    static readonly string path = "Prefabs/UI/Panle/Canvas2";
    public StarPanle() : base(new UIType(path))
    {

    }
    public override void OnEnter()
    {
        UITool.GetOrAddCopmponentInChildren<Button>("btn1").onClick.AddListener(() =>
        {
            Debug.Log("yzh真帅");
           PanleManager.Push(new  SettingPanel());
        });
        UITool.GetOrAddCopmponentInChildren<Button>("BtnGameStart").onClick.AddListener(() =>
        {
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });
    }
}