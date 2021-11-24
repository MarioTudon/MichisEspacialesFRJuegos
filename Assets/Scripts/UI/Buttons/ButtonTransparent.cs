using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransparent : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    void OnEnable()
    {
        canvasGroup.alpha = 0.4f;
    }

    public void ButtonDown()
    {
        canvasGroup.alpha = 0.8f;
    }
    
    public void ButtonUp()
    {
        canvasGroup.alpha = 0.4f;
    }
}
