using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour {
    public GameObject catLivesText;
    public GameObject ownerHealthObj;

    public GameObject hpFrame;
    public Sprite altFrame;

    public GameObject notificationObj;
    private float _notifTimer = 0f;

    void Start() {
        _notifTimer = 0f;
        notificationObj.SetActive(false);
    }

    void Update() {
        if (_notifTimer > 0) {
            _notifTimer -= Time.deltaTime;
            if (_notifTimer <= 0) {
                EndNotification();
            }
        }
    }   

    public void RemoveHeartFromHUD(int count) {
        catLivesText.GetComponent<TMP_Text>().text = "x" + count;
    }

    public void UpdateOwnerHealth(float fill) {
        ownerHealthObj.GetComponent<Image>().fillAmount = fill;

        if (fill <= 0.33f)
            LowHPFrame();
    }

    public void LowHPFrame() {
        hpFrame.GetComponent<Image>().sprite = altFrame;
    }

    public void TriggerNotification(string msg) {
        _notifTimer = 2.5f;
        notificationObj.SetActive(true);
        notificationObj.GetComponentInChildren<TMP_Text>().text = msg;
    }

    public void EndNotification() {
        notificationObj.SetActive(false);
    }
}
