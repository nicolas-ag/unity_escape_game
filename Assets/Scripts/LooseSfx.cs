using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseSfx : MonoBehaviour {

    [SerializeField]
    private List<AudioClip> audios;
    private AudioSource audio;

	// Use this for initialization
	void Awake () {
        audio = GetComponent<AudioSource>();
        audio.clip = audios[Random.Range(0, 6)];
        audio.Play();
	}
}
