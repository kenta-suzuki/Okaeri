using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TitleCanvasController : MonoBehaviour
{
    [SerializeField]
    Button BtnTitle;
    [SerializeField]
    Button BtnDelete;

	// Use this for initialization
	void Start ()
    {
        //GameManagerがない場合は追加する処理を入れた方がいい
        GameModel.Instance.Initialize();
        BtnTitle.onClick.AddListener(() => OnTitleClick());
	}

    void OnTitleClick()
    {
        if(GameModel.Instance.Model.HaCurrentStageId)
        {
            var stage = GameModel.Instance.Model.GetStageModel(GameModel.Instance.Model.CurrentStageId);
            GameController.Instance.ChangeStage(stage.mstStage.name_kana);
        }
        else
        {
            var stage = GameModel.Instance.Master.StageMaster.Datas.First();
            GameController.Instance.ChangeStage(stage.name_kana);
        }
    }

    void OnClickDelete()
    {
        //シリアライズ化されたユーザーデータを削除
    }
}
