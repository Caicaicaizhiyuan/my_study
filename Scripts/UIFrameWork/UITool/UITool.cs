//==========================
// - FileName: UITool.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: UI的管理工具
// 包括获取某个子对象的操作
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool 
{   
    /// <summary>
    /// 当前的活动面板
    /// </summary>
    private GameObject activePanle;
    public UITool(GameObject panle)
    {
        activePanle = panle;
    }
    /// <summary>
    /// 给当前的活动面板获取或者添加一个组件
    /// </summary>
    /// <typeparam name="T">组件的类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>() where T : Component
    {
        if(activePanle.GetComponent<T>() == null)
        {
            activePanle.AddComponent<T>();
        }
        return activePanle.GetComponent<T>();
    }
    /// <summary>
    /// 根据名称找一个子对象
    /// </summary>
    /// <param name="name">子对象名称</param>
    /// <returns></returns>
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans= activePanle.GetComponentsInChildren<Transform>();
        //找到所有儿子
        foreach(var item in trans)
        {
            if(item.name == name)
            {
                return item.gameObject;
            }
        }
        Debug.LogError($"{activePanle.name}里找不到名称为" + name + "的prefab");
        return null;
    }
    /// <summary>
    /// 根据名称找子对象的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetOrAddCopmponentInChildren<T>(string name) where T : Component
    {
        GameObject son=FindChildGameObject(name);
        if (son != null)
        {
            if (son.GetComponent<T>() == null)
                son.AddComponent<T>();
            return son.GetComponent<T>();
        }
        return null;    
    }
    /// <summary>
    /// 克隆物品到节点下
    /// </summary>
    /// <param name="go"></param>
    /// <param name="fa"></param>
    /// <returns></returns>
    public GameObject CloneGameObject(GameObject go,Transform fa)
    {
        var clone= GameObject.Instantiate(go,fa);
        return clone;
    }
    public static Transform GetChild(GameObject fa,string name)
    {
        return fa.transform.Find(name);
    }
}