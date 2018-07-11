using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController instance;
    public static GameController Instance { get { return instance; } }

    [SerializeField]
    DialogManager dialog;
    [SerializeField]
    SceneChanger sceneChanger;
    [SerializeField]
    NovelController novelController;
    [SerializeField]
    ItemMenuCanvasController itemMenu;

	void Start ()
    {
        instance = this;
	}

    /// <summary>
    /// ステージ移動
    /// </summary>
    public void ChangeStage(string stageName)
    {
        sceneChanger.ChangeStage(stageName);
    }

    /// <summary>
    /// ノベル再生
    /// </summary>
    public void StartNovel(int novelId)
    {
        novelController.Show(novelId);
    }

    /// <summary>
    /// アイテムうけとりダイアログ表示
    /// </summary>
    public void ShowItemReciveDialog(m_item mstItem)
    {
        dialog.ShowItemReciveDialog(mstItem);
    }


}
