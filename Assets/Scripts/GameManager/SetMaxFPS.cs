using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxFPS : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
