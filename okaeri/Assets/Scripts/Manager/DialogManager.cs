using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    Button btnHideDialog;
    [SerializeField]
    ItemRecieveDialog itemRecieveDialog;

    DialogBase currentDialog;

    //ダイアログが表示されているかどうか
    public bool IsShowing { get { return currentDialog.IsShowing; }}

	private void Start()
	{
        btnHideDialog.onClick.AddListener(() => OnClickHide());
	}

    /// <summary>
    /// 画面をタップした時の処理
    /// </summary>
    void OnClickHide()
    {
        //if (!currentDialog.IsShowing) return;
        //currentDialog.HideDialog();
        itemRecieveDialog.HideDialog();
    }

    /// <summary>
    /// アイテム受けとりダイアログ表示
    /// </summary>
	public void ShowItemReciveDialog(m_item mstItem)
    {
        itemRecieveDialog.Initialize(mstItem);
        itemRecieveDialog.ShowDialog();
        currentDialog = itemRecieveDialog;
    }
}
