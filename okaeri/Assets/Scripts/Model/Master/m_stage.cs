using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class m_stage
{
    public string name { get; private set; }
    public string name_kana { get; private set; }
    public string description { get; private set; }
    public int stage_id { get; private set; }

    public int left_stage_id { get; private set; }
    public int right_stage_id { get; private set; }
    public int up_stage_id { get; private set; }
    public int bottom_stage_id { get; private set; }

    public List<m_item> Items { get; private set; }
    public List<m_event> Events { get; private set; }

    public void Set()
    {
        Items = GameModel.Instance.Master.MstItem.Where(m => m.stage_id == stage_id).ToList();
        Events = GameModel.Instance.Master.MstEvent.Where(m => m.stage_id == stage_id).ToList();
    }
}
