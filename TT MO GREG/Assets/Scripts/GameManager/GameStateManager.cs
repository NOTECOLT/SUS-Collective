using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
    // SINGLETON PATTERN
    private static GameStateManager _instance;
    public static GameStateManager Instance { get {return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Basically handles game over stuff with the lives and shit as well as when time is up

    // Public Variables
    public int totalLives = 9;
    public int currentLives;

    public Transform ownerTransform;
    public GameObject cameraObj;

    public bool gameOver = false;
    public bool catDie = false;

    public int ownerHealth = 5;
    public int currentOwnerHealth;
    
    // Private Variables
    private HUDManager _hud;

    void Start() {
        currentLives = totalLives;
        currentOwnerHealth = ownerHealth;
        gameOver = false;
        catDie = false;

        _hud = GetComponent<HUDManager>();
    }

    public void TriggerGameOver() {
        gameOver = true;
        if (currentOwnerHealth <= 0)
            cameraObj.GetComponent<CameraFollow>().SwitchFocus(ownerTransform);
    }
    public void TriggerGameWin() {
        SceneManager.LoadScene("GameWin", LoadSceneMode.Single);
    }

    public void RemoveCatLife() {
        currentLives -= 1;
        _hud.RemoveHeartFromHUD(currentLives);
    }

    public void RemoveOwnerHealth() {
        currentOwnerHealth -= 1;
        _hud.UpdateOwnerHealth((float)currentOwnerHealth / (float)ownerHealth);
    }
}
