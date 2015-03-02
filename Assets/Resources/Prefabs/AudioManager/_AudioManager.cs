﻿using UnityEngine;
using System.Collections;

public class _AudioManager : MonoBehaviour {
	public AudioClip circled;
	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}

	public void playCircled () {
		audioSource.clip = circled;
		audioSource.Play();
	}
}

public class AudioManager : qSingleton<_AudioManager> {
}