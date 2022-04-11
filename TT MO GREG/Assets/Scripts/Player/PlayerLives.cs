using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLives : MonoBehaviour {
    // Public Variables
    public int totalLives = 9;
    public int currentLives;
    public bool isDead = false;
    public GameObject respawnPoint;
    public UnityEvent[] onDeathActions; // List containing UnityActions for what to do on each death (1 buff per death)
    
    void Start() {
        currentLives = totalLives;
        isDead = false;

        if (respawnPoint == null)
            Debug.LogError("No Respawn Point Object assigned to this field!", this);
    }

    
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyProjectile")) {
            if (currentLives > 0) {
                Respawn();
            }  
        }
    }

    private void Respawn() {
        currentLives -= 1;
        isDead = true;

        gameObject.SetActive(false);
        transform.position = respawnPoint.transform.position;

        onDeathActions[totalLives - currentLives - 1].Invoke();
        gameObject.SetActive(true);
        isDead = false;
    }
}
