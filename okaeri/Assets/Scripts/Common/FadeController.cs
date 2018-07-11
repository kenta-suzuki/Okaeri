using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    Animator fadeAnimator;

    public bool Active{ set { gameObject.SetActive(value); } }

    public bool IsFadeInFinish { get; private set; }

	private void Start()
	{
        IsFadeInFinish = false;
	}

	public void SetTrigger()
    {
        fadeAnimator.SetTrigger("FadeOut");
    }

    public void OnFadeFinish()
    {
        Active = false;
    }

    public void OnFinishFadeIn()
    {
        IsFadeInFinish = true;
    }
}
