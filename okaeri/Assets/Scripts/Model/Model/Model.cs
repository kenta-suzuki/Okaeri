using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Model
{
    //現在のステージid
    public int CurrentStageId { get; private set; }

    //セーブされているステージデータがあるかどうか
    public bool HaCurrentStageId
    {
        get
        {
            return CurrentStageId != 0;
        }
    }

    public List<int> StageIds { get; set; }
    public List<int> ItemIds { get; set; }
    public List<int> EventIds { get; set; }

    List<StageModel> stageModels;

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Initialize()
    {
        //データのシリアライズを行う
        GameModel.Instance.Master.StageMaster.Datas.ForEach(d => stageModels.Add(new StageModel(d.id)));
    }

    /// <summary>
    /// ステージデータを取得する処理
    /// </summary>
    public StageModel GetStageModel(int stageId)
    {
        return stageModels.First(m => m.mstStage.id == stageId);
    }

    /// <summary>
    /// ステージidのリストを追加
    /// </summary>
    public void AddStageId(int stageId)
    {
        if (StageIds.Contains(stageId)) return;
        StageIds.Add(stageId);
    }

    /// <summary>
    /// アイテムを追加する処理
    /// </summary>
    public void AddItemId(int itemId)
    {
        if (ItemIds.Contains(itemId)) return;
        ItemIds.Add(itemId);
    }

    /// <summary>
    /// アイテムを削除する処理
    /// </summary>
    public void RemoveItemId(int itemId)
    {
        if (ItemIds.Contains(itemId)) return;
        ItemIds.Remove(itemId);
    }

    /// <summary>
    /// イベントを追加する処理
    /// </summary>
    public void AddEventId(int eventId)
    {
        if (EventIds.Contains(eventId)) return;
        EventIds.Add(eventId);
    }

    /// <summary>
    /// 合成可能か
    /// </summary>
    public bool CanUpgradeItem(int upgradeItemId)
    {
        return true;
    }

    /// <summary>
    /// アイテムを合成
    /// </summary>
    public void UpgradeItem(int upgradeItemId)
    {
        
    }

    public bool CanReciveEvent(int eventId)
    {
        return false;
    }
}
