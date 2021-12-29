using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rB2D;
    [SerializeField] private Vector2 bulletVelocity = Vector2.zero;
    [HideInInspector] public float direction;
    [SerializeField] private bool frontalBullet;

    private void Awake()
    {
        if (!frontalBullet) return;
        bulletVelocity *= direction;

        Vector3 newScale = transform.localScale;
        newScale.x = direction;
        transform.localScale = newScale;
    }

    void Update()
    {
        rB2D.velocity = bulletVelocity;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
