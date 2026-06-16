//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:对话系统的设置
//==========================

using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueConfig")]
public class DialogueConfigSO : ScriptableObject
{
    public float typeSpeed = 0.05f;
    public CharacterProfileSO[] characters;

    public CharacterProfileSO GetCharacterById(string id)
    {
        foreach (var c in characters)
        {
            if (c.characterId == id)
                return c;
        }
        return null;
    }
}