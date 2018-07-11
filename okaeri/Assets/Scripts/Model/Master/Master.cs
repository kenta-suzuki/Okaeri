using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master
{
    //マスターのリスト
    public StageMasterTable StageMaster { get; private set; }
    public ItemMasterTable ItemMaster { get; private set; }
    public EventMasterTable EventMaster { get; private set; }
    public ItemIncentiveMasterTable ItemIncentiveMaster { get; private set; }
    public ItemUpgradeConditionMasterTable ItemUpgreadConditionMaster { get; private set; }
    public EventOccurrenceMasterTable EventOccurenceMaster { get; private set; }
    public EventRequirementMasterTable EventRequirementMaster { get; private set; }
    public BgmMasterTable BgmMaster { get; private set; }
    public SeMasterTable SeMaster { get; private set; }

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Initialize()
    {
        StageMaster = new StageMasterTable();
        ItemMaster = new ItemMasterTable();
        EventMaster = new EventMasterTable();
        ItemIncentiveMaster = new ItemIncentiveMasterTable();
        ItemUpgreadConditionMaster = new ItemUpgradeConditionMasterTable();
        EventOccurenceMaster = new EventOccurrenceMasterTable();
        EventRequirementMaster = new EventRequirementMasterTable();
        BgmMaster = new BgmMasterTable();
        SeMaster = new SeMasterTable();

        Load();
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
        StageMaster.Load();
        ItemMaster.Load();
        ItemIncentiveMaster.Load();
        ItemUpgreadConditionMaster.Load();
        EventMaster.Load();
        EventOccurenceMaster.Load();
        EventRequirementMaster.Load();
        BgmMaster.Load();
        SeMaster.Load();
    }
}