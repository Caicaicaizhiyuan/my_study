//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:对话系统数据类型
//==========================

using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/CharacterProfile")]
public class CharacterProfileSO : ScriptableObject
{
    public string characterId;
    public string displayName;
    public Sprite defaultSprite;
    public Sprite happySprite;
    public Sprite sadSprite;

    public Sprite GetSprite(string state)
    {
        switch (state)
        {
            case "happy": return happySprite;
            case "sad": return sadSprite;
            default: return defaultSprite;
        }
    }
}