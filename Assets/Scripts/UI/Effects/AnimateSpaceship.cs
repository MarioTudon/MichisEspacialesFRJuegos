using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpaceship : MonoBehaviour
{
    void Start()
    {
        if(transform.position.x > 0)
        {
            LeanTween.moveLocal(gameObject, new Vector2(-Screen.currentResolution.width, Random.Range(-Screen.currentResolution.height, Screen.currentResolution.height)), 10).setOnComplete(DestroyShip);
        }
        else
        {
            LeanTween.moveLocal(gameObject, new Vector2(Screen.currentResolution.width, Random.Range(-Screen.currentResolution.height, Screen.currentResolution.height)), 10).setOnComplete(DestroyShip);
        }
    }

    private void DestroyShip()
    {
        Destroy(gameObject);
    }


}