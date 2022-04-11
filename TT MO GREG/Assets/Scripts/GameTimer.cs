using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    // [Code Ripped from Help Me Find My Doll! once again lol]

    // Public Variables
    public float timeLimit = 30f;
    public float timePercentElapsed;
    public float secElapsed;
    
    void Start() {
        secElapsed = 0.0f;
    }

    void Update() {
        CalcTimePassed();
    }

    // Calculates time percentage until time limit
    private void CalcTimePassed() {
        timePercentElapsed = (secElapsed / timeLimit) * 100;
        secElapsed += Time.deltaTime;
    }
}
