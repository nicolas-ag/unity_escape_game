using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hud : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text keys;
    [SerializeField]
    private Text actualKeys;
    [SerializeField]
    private Text time;
    [SerializeField]
    private Text bestTime;
    [SerializeField]
    private GameObject indicGoal;
    private string bestTimeName;


    private void Start()
    {
        bestTimeName = "bestTime" + PlayerPrefs.GetInt("level");
        keys.text = "/ "+GameObject.FindGameObjectsWithTag("Key").Length;
        bestTime.text = PlayerPrefs.GetString(bestTimeName, "00:00");
    }
    
	void FixedUpdate () {
        actualKeys.text = player.GetComponent<PickUpKeys>().GetNumberOfKey().ToString();
        int minutes = (int)(Time.timeSinceLevelLoad / 60f);
        int seconds = (int)(Time.timeSinceLevelLoad % 60f);
        time.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void SaveBestTime()
    {
        string[] actualTime = time.text.Split(':');
        string[] best = PlayerPrefs.GetString(bestTimeName, "100:00").Split(':');
        if(Int32.Parse(actualTime[0]) < Int32.Parse(best[0]) || (Int32.Parse(actualTime[0]) == Int32.Parse(best[0]) && Int32.Parse(actualTime[1]) < Int32.Parse(best[1])))
        {
            PlayerPrefs.SetString(bestTimeName, time.text);
            PlayerPrefs.SetInt("isBestTime", 1);
            bestTime.text = time.text;
        }
        else
        {
            PlayerPrefs.SetInt("isBestTime", 0);
            PlayerPrefs.SetString("actualTime", time.text);
        }
    }

    public void AfficheIndicGoal()
    {
        indicGoal.SetActive(true);
    }
}
