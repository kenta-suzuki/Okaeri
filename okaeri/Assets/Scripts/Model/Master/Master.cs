using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master
{
    //マスターのリスト
    public List<m_stage> MstStage { get; private set; }
    public List<m_item> MstItem { get; private set; }
    public List<m_item_upgrade_condition> MstItemUpgradeCondition { get; private set; }
    public List<m_event> MstEvent { get; private set; }
    public List<m_event_requirement_item> MstEventRequirementItem { get; private set; }
    public List<m_event_requirement_event> MstEventRequirementEvent { get; private set; }

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Initialize()
    {

    }

    /// <summary>
    /// 各マスターのSetを呼び出す
    /// </summary>
    void SetData()
    {

    }

    /// <summary>
    /// CSVをロードする処理
    /// </summary>
    void Load()
    {

    }
}