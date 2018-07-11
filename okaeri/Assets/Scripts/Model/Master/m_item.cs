using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class m_item : MasterBase
{
    public string name { get; private set; }
    public string name_kana { get; private set; }
    public string description { get; private set; }
    public int is_key { get; private set; }
    public int se_id { get; private set; }

    public m_item_upgrade_condition UpgradeCondition { get; private set; }
}

public class ItemMasterTable : MasterTableBase<m_item>
{
    static readonly string FilePath = "m_item";
    public void Load() { Load(FilePath); }
}