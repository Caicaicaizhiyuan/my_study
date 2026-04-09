//==========================
// - FileName: ScemeSystem.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: 场景的管理系统
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneSystem 
{
    /// <summary>
    /// 场景的状态类
    /// </summary>
    SceneState sceneState;
    /// <summary>
    /// 设置当前场景并进行当前场景
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state)
    {
        /*
        if (sceneState != null)
            sceneState.OnExit();
        sceneState = state;
        if(sceneState != null)
            sceneState.OnEnter();
        */
        sceneState?.OnExit();
        sceneState=state;
        sceneState?.OnEnter();
    }

}