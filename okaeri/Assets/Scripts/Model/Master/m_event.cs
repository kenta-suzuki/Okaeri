using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class m_event
{
    public int event_id { get; private set; }
    public int stage_id { get; private set; }

    public string event_name { get; private set; }
    public int requirement_item_condition_id { get; private set; }
    public int requirement_event_condition_id { get; private set; }
    public int param { get; private set; }

    public List<m_event_requirement_item> RequirementItems { get; private set; }
    public List<m_event_requirement_event> RequirementEvents { get; private set; }

    public void Set()
    {
        RequirementItems = GameModel.Instance.Master.MstEventRequirementItem.Where(m => m.requirement_item_id == requirement_item_condition_id).ToList();
        RequirementEvents = GameModel.Instance.Master.MstEventRequirementEvent.Where(m => m.requirement_event_id == requirement_event_condition_id).ToList();
    }
}