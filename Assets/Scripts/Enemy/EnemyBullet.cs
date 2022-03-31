using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rB2D;
    [SerializeField] private float bulletVelocity;

    private void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rB2D.velocity = transform.right * bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
