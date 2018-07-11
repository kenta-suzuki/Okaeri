using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_item_incentive : MasterBase
{
    public int stage_id { get; private set; }
    public int item_id { get; private set; }
    public string incentive_message { get; private set; }
}

public class ItemIncentiveMasterTable : MasterTableBase<m_item_incentive>
{
    static readonly string FilePath = "m_item_incentive";
    public void Load() { Load(FilePath); }
}
