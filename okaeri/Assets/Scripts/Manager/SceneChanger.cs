using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    FadeController fade;
    string currentStageName = "Title";

    public event Action SceneLoaded = delegate { };

	public void ChangeStage(string stageName)
    {
        StartCoroutine(WaitForLoadScene(stageName));
    }

    /// <summary>
    /// シーンの切り替え
    /// </summary>
    IEnumerator WaitForLoadScene(string stageName)
    {
        Debug.Log("現在のシーン名 : " + currentStageName + " , 次のシーン名 : " + stageName);
        fade.Active = true;
        if (!string.IsNullOrEmpty(currentStageName))
        {
            SceneManager.UnloadSceneAsync(currentStageName);
        }

        yield return new WaitUntil(() => fade.IsFadeInFinish);
        SceneManager.LoadSceneAsync(stageName, LoadSceneMode.Additive);
        currentStageName = stageName;

        fade.SetTrigger();

        SceneLoaded();
        SceneLoaded = delegate { };
    }
}
