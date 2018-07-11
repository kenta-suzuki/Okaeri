using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_requirement_event : MasterBase
{
    public int event_id { get; private set; }
    public int requirement_event_id { get; private set; }
    public int requirement_item_id { get; private set; }
}

public class EventRequirementMasterTable : MasterTableBase<m_requirement_event>
{
    static readonly string FilePath = "m_requirement_event";
    public void Load() { Load(FilePath); }
}