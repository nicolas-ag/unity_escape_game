using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PickUpKeys : MonoBehaviour {

    [SerializeField]
    private GameObject goalZoneActive;
    [SerializeField]
    private GameObject goalZoneInactive;
    [SerializeField]
    private Canvas hud;

    private int numberOfKeysNeed;
    private int numberOfKey = 0;

    private void Awake()
    {
        goalZoneActive.SetActive(false);
    }

    private void Start()
    {
        numberOfKeysNeed = GameObject.FindGameObjectsWithTag("Key").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            numberOfKey++;
            other.gameObject.SetActive(false);
            if (numberOfKey == numberOfKeysNeed)
            {
                goalZoneInactive.SetActive(false);
                goalZoneActive.SetActive(true);
                hud.GetComponent<Hud>().AfficheIndicGoal();
                AudioSource.PlayClipAtPoint(goalZoneActive.GetComponent<AudioSource>().clip, other.transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(other.GetComponent<AudioSource>().clip, other.transform.position);
            }
        }

        if (other.gameObject.CompareTag("GoalZoneActive"))
        {
            hud.GetComponent<Hud>().SaveBestTime();
            SceneManager.LoadScene("Win");
        }
    }

    public int GetNumberOfKey()
    {
        return numberOfKey;
    }
}
