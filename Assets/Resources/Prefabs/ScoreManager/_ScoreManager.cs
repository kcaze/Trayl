﻿using UnityEngine;
using System.Collections;

public class _ScoreManager : MonoBehaviour {
	public float comboDuration;
	[System.NonSerialized]
	public int score;
	[System.NonSerialized]
	public int combo;
	[System.NonSerialized]
	public float comboMeter;
	[System.NonSerialized]
	public int coins;

	private void Awake() {
		score = 0;
		combo = 0;
		coins = 0;
	}

	public void IncrementCombo() {
		combo++;
		comboMeter = comboDuration;
	}

	public void IncrementCoins() {
		coins++;
	}

	public void AddScore(int score) {
		this.score += this.combo * score;
	}

	public void LoseCombo() {
		combo = 0;
		comboMeter = 0;
	}

	private void Update() {
		//Debug.Log(comboMeter + " " + combo);
		comboMeter -= Time.deltaTime;
		if (combo == 0) comboMeter = 0;
		if (comboMeter < 0) {
			LoseCombo();
		}
	}

}

public class ScoreManager : qSingleton<_ScoreManager> {
}