﻿using UnityEngine;
using System.Collections;

public class _GridManager : qObject {
	public Grid grid;
	private Player player;
	private LineRenderer line;
	private int npoints;
	private Vector3 prevPos;
	private float lineThreshold;

	private void Awake () {
		this.player = (Player) FindObjectOfType(typeof(Player));
		this.grid = gameObject.GetComponent<Grid>();
		this.npoints = 0;
		this.line  = GetComponent<LineRenderer>();
		this.prevPos = player.transform.position;
		this.lineThreshold = 0.3f;
	}
	
	private IEnumerator FillEmpty() {
		yield return new WaitForSeconds(0.15f); //TODO: avoid hardcoded values
		for (int ii = 0; ii < grid.gridSize; ii++) {
			if (grid.grid[ii] == TileEnum.normalCircled) {
				grid.grid[ii] = TileEnum.empty;
			}
		}
		yield return null;
	}

	private void Update () {
		int index = this.grid.WorldToGrid(player.transform.position);
		if (index == -1) {
			Debug.LogError("Player outside level bounds!");
			return;
		}
		HandleTrail(index);
		if ((player.transform.position-this.prevPos).magnitude > lineThreshold) {
			this.line.SetVertexCount(npoints+1);
			this.line.SetPosition(npoints, player.transform.position);
			npoints++;
			this.prevPos = player.transform.position;
		}
	}

	private void HandleTrail(int index) {
		if (this.grid.grid[index] == TileEnum.normal || this.grid.grid[index] == TileEnum.normalCircled) return;
		if (player.trail != TrailEnum.normal) return;
		this.grid.grid[index] = TileEnum.normal;

		int[] dx = {1, 0, -1, 0};
		int[] dy = {0, 1, 0, -1};
		bool enclosed = false;
		for (int ii = 0; ii < 4; ii++) {
			Tuple<int, int> coord = grid.Coord(index);
			coord.first += dx[ii];
			coord.second += dy[ii];
			if (grid.IsEnclosed(grid.Index(coord.first, coord.second), TileEnum.normal)) {
				grid.FloodFill1(grid.Index(coord.first, coord.second), TileEnum.normal);
				enclosed = true;
			}
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		if (enclosed) {
			AudioManager.instance.playCircled();
			float tileCount = 0;
			for (int ii = 0; ii < grid.gridSize; ii++) {
				if (grid.grid[ii] == TileEnum.normal) {
					grid.grid[ii] = TileEnum.normalCircled;
					tileCount++;
				}
			}
			StartCoroutine(FillEmpty());
			ScoreManager.instance.tileFraction = tileCount / grid.gridSize;
			int numKilled = 0;
			for (int ii = 0; ii < enemies.Length; ii++) {
				GameObject enemy = enemies[ii];
				if (!enemy.GetComponent<qObject>().isActive) continue;
				int enemyIndex = this.grid.WorldToGrid(enemy.transform.position);
				if (this.grid.grid[enemyIndex] == TileEnum.normalCircled) {
					enemy.SendMessage("qDie");
					numKilled++;
				}
			}
			ScoreManager.instance.combo += Mathf.Max(numKilled-1, 0);
			ScoreManager.instance.tileFraction = 0;
			this.line.SetVertexCount(0);
			npoints = 0;
		}

		// TODO: this is buggy
		/*for (int ii = 0; ii < enemies.Length; ii++) {
			GameObject enemy = enemies[ii];
			if (enemy == null) continue;
			int enemyIndex = this.grid.WorldToGrid(enemy.transform.position);
			//Debug.Log(enemyIndex);
			if (this.grid.grid[enemyIndex] == TileEnum.normal && !player.isInvulnerable) {
				player.SendMessage("qDie");
				LevelManager.instance.SendMessage("qDie");
				break;
			}
		}*/
	}
	
	private void ClearNormal() {
		for (int ii = 0; ii < grid.gridSize; ii++) {
			if (grid.grid[ii] == TileEnum.normal) {
				grid.grid[ii] = TileEnum.empty;
			}
		}
	}
}

public class GridManager : qSingleton<_GridManager> {
}