//==========================
// - FileName: UiType.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description:存储当前UI的信息，包括名字路径
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIType 
{
    /// <summary>
    /// UI名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// UI路径
    /// </summary>
    public string Path { get; private set; }

    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/')+1); 
        //取最后一个路径前的名称
    } 
}