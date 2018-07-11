using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript.Gestures;

public class ItemButton : MonoBehaviour 
{
    [SerializeField]
    SpriteRenderer ItemSprite;
    [SerializeField]
    TapGesture tapGesture; //Tapに変更

    public event Action Pressed = delegate { };

	private void Start()
	{
        if(tapGesture == null)
        {
            Debug.LogError(gameObject.name + "にPressGestureがないぞ");
        }
	}

	private void OnEnable()
	{
        tapGesture.Tapped += OnPress;
	}

	private void OnDisable()
	{
        tapGesture.Tapped -= OnPress;
	}

    void OnPress(object sender, EventArgs e)
    {
        if (Pressed == null) return;
        Pressed();
    }
}
