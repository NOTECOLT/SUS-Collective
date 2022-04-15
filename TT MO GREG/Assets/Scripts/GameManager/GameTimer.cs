using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    // [Code Ripped from Help Me Find My Doll! once again lol]

    // Public Variables
    public float timeLimit = 30f;
    public float timePercentElapsed;
    public float secElapsed;

    public bool isEndless = false;

    // Private Variables
    private GameStateManager _gsm;
    
    void Start() {
        secElapsed = 0.0f;
        _gsm = GetComponent<GameStateManager>();
    }

    void Update() {
        if (!_gsm.gameOver)
            CalcTimePassed();
    }

    // Calculates time percentage until time limit
    private void CalcTimePassed() {
        if (!isEndless) {
            timePercentElapsed = (secElapsed / timeLimit) * 100;      
        }
        
        secElapsed += Time.deltaTime;

        if (timePercentElapsed >= 100) {
            _gsm.TriggerGameWin();
        }
    }

    public void SetTimeActive(bool active) {
        Time.timeScale = (active) ? 1.0f : 0;
    }
}
