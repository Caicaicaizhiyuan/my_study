//==========================
// - FileName: PanleManager.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:面板的管理器，用栈来存
//==========================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PanleManager 
{
    /// <summary>
    /// 栈来存储UI
    /// </summary>
    private  Stack<BasePanel> stackPanel;
    /// <summary>
    /// 面板管理器
    /// </summary>
    private UIManager uiManager;
    private BasePanel panel;
    public PanleManager()
    {
        stackPanel = new Stack<BasePanel>();
        uiManager = new UIManager();
    }
    /// <summary>
    /// UI的入栈操作，此操作会显示一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel=stackPanel.Peek();
            panel.OnPuase();
        }
        GameObject panleGo = uiManager.GetSingleUI(nextPanel.UIType);
        nextPanel.Initialize(new UITool(panleGo));
        nextPanel.Initialize(this);  //这里添加的是自己的
        nextPanel.Initialize(uiManager);
        stackPanel.Push(nextPanel);
        nextPanel.OnEnter(); 
    }
    /// <summary>
    /// 弹出操作
    /// </summary>
    public BasePanel Peek()
    {
        if(stackPanel.Count > 0)
        {
            panel= stackPanel.Peek();
            panel.OnResume();
            return panel;
        }
        else
        {
            Debug.LogError("当前无在运行的UI，请注意检查是否入栈");
            return null;
        }
    
    }
    /// <summary>
    /// 删除操作
    /// </summary>
    public void Pop()
    {
        if(stackPanel.Count > 0 )
        {
            stackPanel.Pop().OnExit();
            if (stackPanel.Count > 0)
            {
                stackPanel.Peek().OnResume();
            }
        }
        else
        {
            Debug.LogError("当前无在运行的UI，请注意检查是否入栈");
        }
    }
    /// <summary>
    /// 销毁所有场景,执行所有面板的Onexit
    /// </summary>
    public void PopAll()
    {
        while(stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
    }

}