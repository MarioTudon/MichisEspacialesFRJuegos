using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1,  33), transform.position.y, transform.position.z);
    }
}
