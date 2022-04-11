using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class OwnerMovement : MonoBehaviour {
    // Private Variables
    private float _totalDistance;
    
    // Public Variables
    public float moveSpeed = 1.0f;
    public PathCreator pc;
    void Start() {
        
    }

    void Update() {
        _totalDistance += moveSpeed * Time.deltaTime;
        transform.position = pc.path.GetPointAtDistance(_totalDistance);
    }
}
