using System.Collections;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    //我在想全局是不是可以只用一个对话框就行了，所以写了这个
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject dialogPrefab;

    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = new DialogManager();
            }
            return _instance; }
    }
    public void ShowDialog(string text)
    {
        dialogText.text = text;
        dialogPrefab.SetActive(true);
    }
    public void HideDialog()
    {
        dialogPrefab.SetActive(false);
    }

}
