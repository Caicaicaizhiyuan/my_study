//==========================
// - FileName: UIManager.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:控制UI的创建与销毁
// 存储所有UI信息
//==========================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class UIManager
{
    /// <summary>
    /// 存储所有UI信息的字典，每一个UI都会对应一个GameObject
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    public  UIManager()
    {
        dicUI= new Dictionary<UIType, GameObject>();   
        

    }
    /// <summary>
    /// 获取UI，没有则创建
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas"); //这里的父类是运行时的名称，在页面上
        if (!parent)
        {
            Debug.LogError("ui未添加Canvas，请仔细检查有无对象" + type.Path);
            return null;
        }
        if (dicUI.ContainsKey(type)) return dicUI[type];
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        ui.name = type.Name;
        dicUI[type] = ui;
        return ui;
    }
    /// <summary>
    /// 销毁一个UI对象
    /// </summary>
    /// <param name="type"></param>
    public void DestorySingleUI(UIType type)
    {
        if(dicUI.ContainsKey(type))
        {

            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
        else
        {
            return ;
        }
    }
}