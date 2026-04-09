  //==========================
// - FileName: SceneState.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: 场景状态
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SceneState 
{
    /// <summary>
    /// 进入场景的操作
    /// </summary>
    public abstract void OnEnter();
    /// <summary>
    /// 退出场景的操作
    /// </summary>
    public abstract void OnExit();
}