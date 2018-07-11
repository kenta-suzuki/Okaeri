using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    [SerializeField]
    GameObject Root;
    [SerializeField]
    Animator Animator;

    /// <summary>
    /// OnShowが呼ばれたタイミングで行うアクション
    /// </summary>
    public event Action Showed = delegate { };

    /// <summary>
    /// OnHideが呼ばれたタイミングで行うアクション
    /// </summary>
    public event Action Hided = delegate { };

    /// <summary>
    /// ダイアログが表示されているかどうか
    /// </summary>
    public bool IsShowing { get; private set; }

    /// <summary>
    /// ダイアログを表示する処理
    /// </summary>
    public void ShowDialog()
    {
        IsShowing = true;
        Root.SetActive(true);
    }

    /// <summary>
    /// ダイアログが表示されきった時の処理
    /// </summary>
    public void OnShow()
    {
        Showed();
    }

    /// <summary>
    /// ダイアログを非表示にする処理
    /// </summary>
    public void HideDialog()
    {
        Animator.SetTrigger("Hide");
    }

    /// <summary>
    /// ダイアログが非表示になった時の処理
    /// </summary>
    public void OnHide()
    {
        IsShowing = false;
        Root.SetActive(false);
        Hided();
    }
}
