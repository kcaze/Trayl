﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : Level {
	public override void Setup() {
		lw = 30;
		lh = 26;
		BeginLevel();
		/*NewWave(120);
		AddEnemy(lw/2+4, lh/2, "Stander");
		AddMessage("Circle enemies to kill them.", 5.0f);
		NewWave(120);
		AddEnemy(lw/2-4, lh/2, "Stander");
		NewWave(120);
		AddEnemy(lw/2, lh/2-3, "Stander");
		NewWave(120);
		AddEnemy(lw/2, lh/2+3, "Stander");
		NewWave(120);
		AddMessage("Draw smaller loops to earn a higher score.", 5.0f);
		AddEnemy(lw/2+4, lh/2+3, "Stander");
		AddEnemy(lw/2+4, lh/2-3, "Stander");
		AddEnemy(lw/2-4, lh/2+3, "Stander");
		AddEnemy(lw/2-4, lh/2-3, "Stander");
		NewWave(120);
		AddEnemy(lw-2, lh-2, "Stander");
		AddEnemy(lw-2, 2, "Stander");
		AddEnemy(2, lh-2, "Stander");
		AddEnemy(2, 2, "Stander");
		NewWave(120);
		AddMessage("As you descend deeper into the ocean, deadlier foes await.", 5.0f);
		AddEnemy(lw/2, lh/2-5, "Chaser");
		AddEnemy(lw/2, lh/2+5, "Chaser");
		NewWave(120);
		for (int ii = 1; ii < lh; ii += 2) {
			AddEnemy(2, ii, "Chaser");
		}
		NewWave(120);
		for (int ii = 1; ii < lh; ii += 2) {
			AddEnemy(lw-2, ii, "Chaser");
		}
		NewWave(120);
		for (int ii = 1; ii < lw; ii += 4) {
			AddEnemy(ii, lh-2, "Chaser");
		}
		for (int ii = 3; ii < lw-2; ii += 4) {
			AddEnemy(ii, lh/2, "Stander");
		}*/
		EndLevel();
	}
}