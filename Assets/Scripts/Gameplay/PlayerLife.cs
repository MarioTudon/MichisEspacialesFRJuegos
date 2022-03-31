using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float life = 3;

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life == 0) Destroy(transform.parent.gameObject);
    }
}
