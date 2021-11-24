using UnityEngine;

public class InstatiateStick : MonoBehaviour
{
    [SerializeField] private GameObject joystick;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToViewportPoint(Input.mousePosition).x <= 0.5f)
        {
            joystick.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Instantiate(joystick, transform);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(joystick);
        }
    }
}
