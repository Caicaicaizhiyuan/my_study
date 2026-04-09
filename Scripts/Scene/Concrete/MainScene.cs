//==========================
// - FileName: MainScene.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: Main场景
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScene : SceneState 
{
    /// <summary>
    /// 场景名字
    /// </summary>
    readonly string sceneName = "Main";
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
            panleManager.Push(new MainPanle());
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
        panleManager.Push(new MainPanle()); //加一个main的面板
        Debug.Log(sceneName + "资源加载完毕");
    }
}