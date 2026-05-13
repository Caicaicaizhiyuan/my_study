//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:用于定义一个全局的对话管理器，负责加载对话数据、控制对话流程以及与UI交互
//==========================
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public DialogueConfigSO config;
    public TextAsset jsonFile;

    private Dictionary<string, DialogueNode> _dialogueDict;
    private DialogueNode _currentNode;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        await LoadDialogueAsync();
    }

    private async UniTask LoadDialogueAsync()
    {
        var data = JsonUtility.FromJson<DialogueData>(jsonFile.text);
        _dialogueDict = data.dialogues.ToDictionary(x => x.id);

        await UniTask.CompletedTask;
    }

    public void StartDialogue(string startId)
    {
        if (!_dialogueDict.TryGetValue(startId, out _currentNode))
            return;

        DialogueUI.Instance.Show();
        PlayNode(_currentNode).Forget();
    }

    private async UniTaskVoid PlayNode(DialogueNode node)
    {
        var profile = config.GetCharacterById(node.speakerId);
        Sprite sprite = profile?.GetSprite(node.emotion);

        DialogueUI.Instance.SetCharacter(sprite);
        await DialogueUI.Instance.TypeTextAsync(node.text);

        if (node.options.Length == 0)
        {
            DialogueUI.Instance.Hide();
            return;
        }

        DialogueUI.Instance.ShowOptions(node.options, OnOptionSelected);
    }

    private void OnOptionSelected(Option option)
    {
        if (_dialogueDict.TryGetValue(option.nextId, out _currentNode))
        {
            PlayNode(_currentNode).Forget();
        }
        else
        {
            DialogueUI.Instance.Hide();
        }
    }
}