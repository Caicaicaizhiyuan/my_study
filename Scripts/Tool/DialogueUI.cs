//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:实现UI的具体功能，包括显示对话文本、角色头像以及选项按钮，并与DialogueManager进行交互
//==========================

using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public GameObject panel;
    public TextMeshProUGUI dialogueText;
    public Image leftCharacter;
    public Image rightCharacter;
    public Transform optionContainer;
    public Button optionPrefab;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show() => panel.SetActive(true);
    public void Hide() => panel.SetActive(false);

    public void SetCharacter(Sprite sprite)
    {
        leftCharacter.sprite = sprite;
        leftCharacter.enabled = sprite != null;
    }

    public async UniTask TypeTextAsync(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            await UniTask.Delay((int)(DialogueManager.Instance.config.typeSpeed * 1000));
        }
    }

    public void ShowOptions(Option[] options, System.Action<Option> onSelect)
    {
        foreach (Transform t in optionContainer)
            Destroy(t.gameObject);

        foreach (var opt in options)
        {
            var btn = Instantiate(optionPrefab, optionContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = opt.text;
            btn.onClick.AddListener(() => onSelect(opt));
        }
    }
}