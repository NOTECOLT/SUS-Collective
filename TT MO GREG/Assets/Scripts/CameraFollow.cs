using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    // Public Variables
    public GameObject cameraFocus;
    public float verticalOffset = -3.1f;

    void start() {
        if (cameraFocus == null)
            Debug.LogError("No Focus Object assigned to this field!", this);
    }

    void FixedUpdate() {
        transform.position = new Vector3(cameraFocus.transform.position.x, cameraFocus.transform.position.y + verticalOffset, transform.position.z);
    }
}
