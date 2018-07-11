using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_se : MasterBase
{
    public string name { get; private set; }
}

public class SeMasterTable : MasterTableBase<m_se>
{
    static readonly string FilePath = "m_se";
    public void Load() { Load(FilePath); }
}
