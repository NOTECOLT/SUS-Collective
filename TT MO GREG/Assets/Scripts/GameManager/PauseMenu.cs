using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    // Public Variables
    public GameObject pauseCanvas;
    public GameObject hudCanvas;

    // Private Variables
    public bool gameIsPaused = false;
    private GameTimer _gt;
    
    void Start() {
        gameIsPaused = false;

        if (pauseCanvas == null)
            Debug.LogError("No pause canvas assigned to this object!", this);

        _gt = GetComponent<GameTimer>();
    }
    
    void Update() {
        // Pause Menu Toggle
        if (Input.GetKeyUp(KeyCode.Escape)) {
            gameIsPaused = !gameIsPaused;
            _gt.SetTimeActive(!gameIsPaused);
            Debug.Log("timescale: " + Time.timeScale);
        }

        pauseCanvas.SetActive(gameIsPaused);
        hudCanvas.SetActive(!gameIsPaused);   
    }
}
