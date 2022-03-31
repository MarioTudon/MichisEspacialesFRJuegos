using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    private Vector3 currentVelocity;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {   
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
