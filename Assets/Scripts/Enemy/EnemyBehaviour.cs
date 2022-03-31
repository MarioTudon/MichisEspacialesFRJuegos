using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float movTransitionDuration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float fireRate;
    private float nextFire;
    private bool canFire;
    Vector3 velocity;

    private void OnBecameVisible()
    {
        canFire = true;
    }

    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            Destroy(this); return;
        }

        SearchPlayer();
        FollowPlayer();
        RotateToPlayer();
    }

    void SearchPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10, playerLayer);

        if (hit.collider && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerTransform.position.x + 5, playerTransform.position.y + 6, transform.position.z), ref velocity, movTransitionDuration);
    }

    void RotateToPlayer()
    {
        Vector3 difference = playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    void Shoot()
    {
        if (!canFire) return;
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
