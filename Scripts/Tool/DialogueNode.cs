//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:定义文本对话节点的数据结构
//==========================
using System;

[Serializable]
public class DialogueNode
{
    public string id;
    public string speakerId;
    public string emotion;
    public string text;
    public Option[] options;
}

[Serializable]
public class Option
{
    public string text;
    public string nextId;
}
