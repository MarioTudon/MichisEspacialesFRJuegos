using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float enemyLife = 10;
    [SerializeField] private Color damageColor;
    private Color currentColor;

    private void Start()
    {
        currentColor = spriteRenderer.color;
    }
    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, currentColor, .3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "EnemyBullet(Clone)") return;

        Destroy(collision.gameObject);
        enemyLife--;
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        currentColor = Color.red;
        yield return new WaitForSeconds(.1f);
        currentColor = Color.white;
        CheckLife();
        yield return null;
    }

    void CheckLife()
    {
        if (enemyLife == 0)
        {
            Destroy(gameObject);
        }
    }
}
