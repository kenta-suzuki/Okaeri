using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class m_stage : MasterBase
{
    public string name { get; private set; }
    public string name_kana { get; private set; }
    public string description { get; private set; }
    public int bgm_id { get; private set; }

}

public class StageMasterTable : MasterTableBase<m_stage>
{
    static readonly string FilePath = "m_stage";
    public void Load() { Load(FilePath); }
}
