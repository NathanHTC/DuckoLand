using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Target to follow (your player character)
    public float smoothing = 5f;        // Smoothing speed
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // Offset from the target
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset; // Desired position based on player location and offset
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); // Smoothly move the camera
    }
}
