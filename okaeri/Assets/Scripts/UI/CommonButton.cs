using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

[RequireComponent(typeof(Button))]
public class CommonButton : MonoBehaviour 
{
	Text _buttonText;
	Text ButtonText
	{
		get
		{
			if (_buttonText == null)
			{
				_buttonText = GetComponentInChildren<Text>();
			}
			return _buttonText;
		}
	}
	public String Text{	set { ButtonText.text = value; } }

	Button _button;
	Button Button
	{
		get
		{
			if (_button == null)
			{
				_button = GetComponent<Button>();
			}

			return _button;
		}
	}
    public bool IsActive { get { return Button.interactable; } set { Button.interactable = value; } }

	Action _tapped = delegate {	};
	public Action Tapped { set { _tapped = value;} }

	void Start()
	{
		Initialize();
	}

	void Initialize()
	{
		Button.onClick.AsObservable().Subscribe(_ =>  _tapped());
	}

	public void Select()
	{
		Button.Select();
	}
}
