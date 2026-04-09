//==========================
// - FileName: StartScene.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:开始场景
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : SceneState
{
    /// <summary>
    /// 场景名字
    /// </summary>
    readonly string sceneName = "Start";
    PanleManager panleManager;
    public override void OnEnter()
    {
        panleManager = new PanleManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
           panleManager.Push(new StarPanle());
           // GameRoot.Instance.SetAction(panleManager.Push);
        }
    }
    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panleManager.PopAll();
    }
    /// <summary>
    /// 场景加载完毕后执行的方法
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panleManager.Push(new StarPanle());
        //GameRoot.Instance.SetAction(panleManager.Push);
        Debug.Log(sceneName + "资源加载完毕");
    }
}