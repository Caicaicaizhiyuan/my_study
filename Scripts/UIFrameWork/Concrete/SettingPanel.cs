//==========================
// - FileName: SettingPanel.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panle/SetingPanle";
    public SettingPanel() : base(new UIType(path))
    {

    }
    public override void OnEnter()
    {
        Debug.Log("yzh进入设置界面");
        UITool.GetOrAddCopmponentInChildren<Button>("BtnExit").onClick.AddListener(() =>
        {
            Debug.Log("销毁");
            PanleManager.Pop();
        });
    }

}