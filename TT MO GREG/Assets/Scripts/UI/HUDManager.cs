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
}
