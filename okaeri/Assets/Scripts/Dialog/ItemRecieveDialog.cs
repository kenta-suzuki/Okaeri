using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRecieveDialog : DialogBase
{
    [SerializeField]
    Image imgItem;
    [SerializeField]
    Text txtTitle;
    [SerializeField]
    Text txtMessage;

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Initialize(m_item mstItem)
    {
        var itemSprite = Resources.Load<Sprite>(mstItem.item_name_kana);
        txtMessage.text = CreateMessage(mstItem.item_name, mstItem.item_name_kana);
    }

    /// <summary>
    /// メッセージ生成
    /// </summary>
    string CreateMessage(string itemName, string description)
    {
        return itemName + "を入手しました/n/n" + description;
    }

    /// <summary>
    /// ダイアログ作成
    /// </summary>
    public ItemRecieveDialog Create(Transform parent)
    {
        var obj = Instantiate(gameObject, parent, false);
        return obj.GetComponent<ItemRecieveDialog>();
    }
}
