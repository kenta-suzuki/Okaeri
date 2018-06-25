using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CommonButton))]
public class ItemButton : MonoBehaviour
{
    [SerializeField]
    CommonButton BtnItem;
    [SerializeField]
    bool EnableLight;

    m_item mstItem;

    /// <summary>
    /// m_iteに基づく情報の設定
    /// </summary>
    public void Initialize(m_item mst)
    {
        mstItem = mst;
        BtnItem.Tapped = () => OnClick();
    }

    /// <summary>
    /// 表示・非表示の切り替え
    /// </summary>
    public void Enable(bool isUseLight)
    {
        BtnItem.gameObject.SetActive(isUseLight);
    }

    /// <summary>
    /// アイテムタップ時の処理
    /// </summary>
    void OnClick()
    {
        AddItem();
        ShowReciveDialog();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 受け取りダイアログ表示
    /// </summary>
    void ShowReciveDialog()
    {
        //受け取りダイアログ表示
    }

    /// <summary>
    /// アイテムを追加
    /// </summary>
    void AddItem()
    {
        GameModel.Instance.Model.AddItemId(mstItem.item_id);
    }
}
