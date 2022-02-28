using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplierX;
    [SerializeField] private float parallaxMultiplierY;

    private Transform cameraTransform;
    private Vector3 previousCameraPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPos = cameraTransform.position;
    }

    void Update()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPos.x) * parallaxMultiplierX;
        float deltaY = (cameraTransform.position.y - previousCameraPos.y) * parallaxMultiplierY;
        transform.Translate(new Vector3(deltaX, deltaY, 0));
        previousCameraPos = cameraTransform.position;
    }
}
