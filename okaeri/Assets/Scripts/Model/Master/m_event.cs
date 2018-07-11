using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class m_event : MasterBase
{
    public int event_type_id { get; private set; }
    public string message { get; private set; }
    public int param { get; private set; }
    public int se_id { get; private set; }
}

public class EventMasterTable : MasterTableBase<m_event>
{
    static readonly string FilePath = "m_event";
    public void Load() { Load(FilePath); }
}