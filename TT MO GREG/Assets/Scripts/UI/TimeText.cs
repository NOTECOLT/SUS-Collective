using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour {
    // [Code ripped from Help Me Find My Doll! again lol]
    public GameTimer gt;
    private float _timeElapsed;
    [SerializeField] private int _totalMinutes = 480;

    [SerializeField] private int _increment = 15;

    private string _timeString = "";
    void Update() {   
        if (!gt.isEndless) {  
            _timeElapsed = gt.timePercentElapsed;     
            int minPassed = ((int)((_timeElapsed / 100) * _totalMinutes)) % 60;
            int hoursPassed = (int)(((_timeElapsed / 100) * _totalMinutes) / 60);

            string minString = (minPassed < 10) ? "0" + minPassed.ToString() : minPassed.ToString();

            if (minPassed % _increment == 0) {
                if (hoursPassed < 2)
                    _timeString = (10 + hoursPassed).ToString() + ":" + (minString) + " PM";
                else if (hoursPassed == 2)
                    _timeString = (12).ToString() + ":" + (minString) + " AM";
                else
                    _timeString = (1 + (hoursPassed - 3)).ToString() + ":" + (minString) + " AM";
            }
            GetComponent<TMP_Text>().text = _timeString;
            TotalGameTime.totalTimeString = _timeString;
        } else {
            _timeElapsed = gt.secElapsed;

            int minPassed = (int)_timeElapsed / 60;
            int secPassed = (int)_timeElapsed % 60;

            string secString = (secPassed < 10) ? "0" + secPassed.ToString() : secPassed.ToString();

            _timeString = minPassed.ToString() + ":" + secString.ToString();

            GetComponent<TMP_Text>().text = _timeString;
            TotalGameTime.totalTimeString = _timeString;
        }
    }
}

public class TotalGameTime {
    public static string totalTimeString { get; set; } = "0:00";
}
