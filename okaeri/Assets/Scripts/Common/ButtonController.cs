using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class ButtonController : MonoBehaviour 
{
    [SerializeField]
    Button BtnLight;
    [SerializeField]
    Button BtnMenu;

    public event Action MenuClicked = delegate { };
    public event Action LightClicked = delegate { };

	//ここでUniRxのリアクティブプロパティを使ってボタンの表示・非表示を行う

	private void Start()
	{
        BtnLight.onClick.AddListener(() => LightClicked());
        BtnMenu.onClick.AddListener(() => MenuClicked());
	}
}
