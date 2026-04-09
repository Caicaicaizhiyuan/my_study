//==========================
// - FileName: BasePanel.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:所有UI继承的基类
// 包含所有UI面板的状态信息
//==========================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class BasePanel 
{
    /// <summary>
    /// UI信息
    /// </summary>
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI工具管理器
    /// </summary>
    public UITool UITool { get; private set; }  
    /// <summary>
    /// 面板管理器
    /// </summary>
    public PanleManager PanleManager { get; private set; }
    /// <summary>
    /// UI管理器
    /// </summary>
    public UIManager UIManager { get; private set; }

    public BasePanel(UIType uitype) 
    {
        UIType = uitype;    
    }

    /// <summary>
    /// 初始化UITool
    /// </summary>
    /// <param name="tool"></param>
    public void Initialize(UITool tool)
    {
        UITool = tool;
    }

    public void Initialize(PanleManager panleManager)
    {
        PanleManager= panleManager; 
    }

    public void Initialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }
    /// <summary>
    /// 进入时候的方法,只会执行一次，onLoad
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// 暂停执行，点开别的UI，对原有UI的处理
    /// </summary>
    public virtual void OnPuase() 
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// 暂停结束后继续执行
    /// </summary>
    public virtual void OnResume() 
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }

    /// <summary>
    /// 退出时执行的方法
    /// </summary>
    public virtual void OnExit() 
    {
        UIManager.DestorySingleUI(UIType);
    }
    
    /// <summary>
    /// 显示一个面板，可以简化点出来（
    /// </summary>
    /// <param name="panel"></param>
    public void Push(BasePanel panel)=>PanleManager?.Push(panel);
    /// <summary>
    /// 关闭一个面板
    /// </summary>
    public void Pop()=>PanleManager?.Pop();

}