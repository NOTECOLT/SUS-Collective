using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    // Public Variables
    public Transform cameraFocus;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void start() {
        if (cameraFocus == null)
            Debug.LogError("No Focus Object assigned to this field!", this);
    }

    void FixedUpdate() {
        Vector3 camPos = cameraFocus.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, camPos, smoothSpeed);

        transform.position = smoothed;
    }

    public void SwitchFocus(Transform newFocus) {
        cameraFocus = newFocus;
    }
}