//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:该脚本实现场景跳转的两方法都在这里
//==========================

using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public GameObject loadingPanel;
    public Slider loadingBar;
    public string targetSceneName;

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
    public void OnSkillButtonClick()
    {
        LoadScene(targetSceneName);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    //这个用于大场景加载，直接换scene
    IEnumerator LoadAsync(string sceneName)
    {
        loadingPanel.SetActive(true);

        // 1️⃣ 先卸载当前场景（除了我们保留的 SceneLoader）
        AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        yield return unloadOp;

        // 2️⃣ 加载新场景（默认是叠加，但我们只保留新场景的物体）
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single); 
        loadOp.allowSceneActivation = false;

        float timer = 0f;

        while (!loadOp.isDone)
        {
            timer += Time.deltaTime;
            loadingBar.value = Mathf.Clamp01(loadOp.progress / 0.9f);

            if (timer >= 1f)
            {
                loadOp.allowSceneActivation = true;
            }

            yield return null;
        }

        loadingPanel.SetActive(false);

        Destroy(gameObject);
    }

    //下面的这个方法不是跳转scene只是通过加载资源实现跳转start与exit配合使用
    IEnumerator Start()
    {
        //第一种加载AB的方式 LoadFromMemoryAsync
        //异步加载
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(targetSceneName));
        yield return request;
        AssetBundle ab = request.assetBundle;
        //同步方式
        //AssetBundle ab=  AssetBundle.LoadFromMemory(File.ReadAllBytes(targetSceneName));

        //使用里面的资源
        Object[] obj = ab.LoadAllAssets<GameObject>();//加载出来放入数组中
        // 创建出来
        foreach (Object o in obj)
        {
            Instantiate(o);
        }
        ab.Unload(false);
    }
    IEnumerator Exit()
    {
        // 1️⃣ 卸载当前场景
        yield return SceneManager.UnloadSceneAsync(
            SceneManager.GetActiveScene()
        );

        // 2️⃣ 卸载无用资源
        Resources.UnloadUnusedAssets();

        // 3️⃣ GC（可选）
        System.GC.Collect();
    }

}
