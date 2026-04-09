//==========================
// - FileName: GameRoot.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: 管理全局的一些东西
//==========================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class GameRoot : MonoBehaviour 
{
    public static GameRoot Instance { get; private set; }
    /// <summary>
    /// 场景管理器，切换都要从这里开始
    /// </summary>
    public SceneSystem SceneSystem { get; private set; } 
    /// <summary>
    /// 在UI框架外使用
    /// </summary>
    public UnityAction<BasePanel> Push { get; private set; }   
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        SceneSystem =new SceneSystem();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SceneSystem.SetScene(new StartScene());

    }
    /// <summary>
    /// 设置Push
    /// </summary>
    /// <param name="push"></param>
    public void SetAction(UnityAction<BasePanel> push)
    {
        Push = push;
    }
}