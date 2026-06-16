//==========================
// - FileName: DialogManager.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:该脚本用于显示一个全局对话框
//==========================
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [SerializeField] private GameObject dialogPrefab;
    private GameObject dialogInstance;
    private TextMeshProUGUI dialogText;
    private RectTransform dialogRect;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
    }

    private void Init()
    {
        dialogInstance = Instantiate(dialogPrefab, FindObjectOfType<Canvas>().transform);
        dialogRect = dialogInstance.GetComponent<RectTransform>();
        dialogText = dialogInstance.GetComponentInChildren<TextMeshProUGUI>();

        dialogInstance.SetActive(false);
    }

    /// <summary>
    /// 在世界坐标位置显示对话框
    /// </summary>
    public void ShowDialog(string text, Vector3 worldPosition)
    {
        dialogInstance.SetActive(true);
        dialogText.text = text;

        Camera cam = Camera.main;
        Vector2 screenPos = cam.WorldToScreenPoint(worldPosition);

        dialogRect.position = screenPos;
    }

    public void HideDialog()
    {
        dialogInstance.SetActive(false);
    }
}