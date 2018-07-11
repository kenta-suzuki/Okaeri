using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_occurrence_event :MasterBase
{
    public int stage_id { get; private set; }
    public int event_id { get; private set; }
}

public class EventOccurrenceMasterTable : MasterTableBase<m_occurrence_event>
{
    static readonly string FilePath = "m_occurrence_event";
    public void Load() { Load(FilePath); }
}
