using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Model
{
    //現在のステージid
    public int CurrentStageId { get; private set; }

    //セーブされているステージデータがあるかどうか
    public bool HaveCurrentStageId
    {
        get
        {
            return CurrentStageId != 0;
        }
    }

    public List<int> StageIds { get; set; }
    public List<int> ItemIds { get; set; }
    public List<int> EventIds { get; set; }

    /// <summary>
    /// ステージidのリストを追加
    /// </summary>
    public void AddStageId(int stageId)
    {
        if (StageIds.Contains(stageId)) return;
        StageIds.Add(stageId);
    }

    public void AddItemId(int itemId)
    {
        if (ItemIds.Contains(itemId)) return;
        ItemIds.Add(itemId);
    }

    public void RemoveItemId(int itemId)
    {
        if (ItemIds.Contains(itemId)) return;
        ItemIds.Remove(itemId);
    }

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
        var mstItem = GameModel.Instance.Master.MstItem.First(m => m.item_id == upgradeItemId);
        var conditionIds = CreateItemIds(mstItem.UpgradeCondition);

        int count = 0;
        foreach (var id in GameModel.Instance.Model.ItemIds)
        {
            if (conditionIds.Any(c => c == id)) count++;
        }

        return count == conditionIds.Count;
    }

    /// <summary>
    /// アイテムを合成
    /// </summary>
    public void UpgradeItem(int upgradeItemId)
    {
        var mstItem = GameModel.Instance.Master.MstItem.First(m => m.item_id == upgradeItemId);
        var conditionIds = CreateItemIds(mstItem.UpgradeCondition);
        AddItemId(upgradeItemId);
        conditionIds.ForEach(id => RemoveItemId(id));
    }

    List<int> CreateItemIds(m_item_upgrade_condition mstUpgradeCondition)
    {
        List<int> list = new List<int>();
        if (mstUpgradeCondition.requirement_item_id_1 != 0)
            list.Add(mstUpgradeCondition.requirement_item_id_1);
        if (mstUpgradeCondition.requirement_item_id_2 != 0)
            list.Add(mstUpgradeCondition.requirement_item_id_2);
        if (mstUpgradeCondition.requirement_item_id_3 != 0)
            list.Add(mstUpgradeCondition.requirement_item_id_3);
        if (mstUpgradeCondition.requirement_item_id_4 != 0)
            list.Add(mstUpgradeCondition.requirement_item_id_4);
        return list;
    }

    public bool CanReciveEvent(int eventId)
    {
        return false;
    }
}
