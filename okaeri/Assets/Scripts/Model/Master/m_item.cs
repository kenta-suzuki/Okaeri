using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class m_item
{
    public int item_id { get; private set; }
    public int stage_id { get; private set; }
    public string item_name { get; private set; }
    public string item_name_kana { get; private set; }
    public int item_upgrade_condition_id { get; private set; }
    public string description { get; private set; }

    public m_item_upgrade_condition UpgradeCondition { get; private set; }

    public void Set()
    {
        UpgradeCondition = GameModel.Instance.Master.MstItemUpgradeCondition.First(m => m.upgrade_condition_id == item_upgrade_condition_id);
    }
}