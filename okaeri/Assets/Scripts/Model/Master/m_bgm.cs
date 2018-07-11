using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_bgm : MasterBase
{
    public string name { get; private set; }
}

public class BgmMasterTable : MasterTableBase<m_bgm>
{
    static readonly string FilePath = "m_bgm";
    public void Load() { Load(FilePath); }
}
