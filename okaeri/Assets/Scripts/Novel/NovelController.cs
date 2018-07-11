using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelController : MonoBehaviour 
{
    [SerializeField]
    GameObject novelCanvas;

    public void Show(int novelId)
    {
        novelCanvas.SetActive(true);
    }
}
