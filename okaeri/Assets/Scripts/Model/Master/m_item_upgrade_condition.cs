using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_item_upgrade_condition : MasterBase
{
    public int material_item_id { get; private set; }
    public int upgrade_item_id { get; private set; }
}

public class ItemUpgradeConditionMasterTable : MasterTableBase<m_item_upgrade_condition>
{
    static readonly string FilePath = "m_item_upgrade_condition";
    public void Load() { Load(FilePath); }
}