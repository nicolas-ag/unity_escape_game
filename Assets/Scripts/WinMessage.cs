using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMessage : MonoBehaviour {
    [SerializeField]
    private Text winMessage;
    [SerializeField]
    private Text time;

	void Awake () {
		if(PlayerPrefs.GetInt("isBestTime", 0) == 1)
        {
            winMessage.text = "Bravo tu t'es echappe en un temps record !";
            time.text = PlayerPrefs.GetString("bestTime" + PlayerPrefs.GetInt("level"));
        }
        else {
            time.text = PlayerPrefs.GetString("actualTime");
        }
	}
}
