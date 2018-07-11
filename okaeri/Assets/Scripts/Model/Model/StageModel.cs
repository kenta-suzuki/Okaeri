using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageModel
{
    public m_stage mstStage { get; private set; }

    public StageModel(int stageId)
    {
        mstStage = new m_stage();
    }

    /// <summary>
    /// アイテムを持っているかどうか
    /// </summary>
    public bool HasItem(int itemId)
    {
        return GameModel.Instance.Model.ItemIds.Any(i => i == itemId);
    }

    /// <summary>
    /// イベントを行ったかどうか
    /// </summary>
    public bool HasEvent(int eventId)
    {
        return GameModel.Instance.Model.EventIds.Any(e => e == eventId);
    }
}
