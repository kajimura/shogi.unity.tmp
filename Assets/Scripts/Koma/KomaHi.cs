using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaHi : KomaBase {

	public List<KomaMove> GetMoves (KomaScript sc, bool reverse = false) {
		int reversenum = 1;
		if (reverse) {
			reversenum = -1;
		}
		Debug.Log ("gage x=" + sc.x + " y=" + sc.y);
		List<KomaMove> moves = new List<KomaMove> ();
		MasuManager manager = MasuManager.Instance;
		for (int i = 1; i <= 8; i++) {
			MasuInit masu = manager.GetMasu (sc.x, sc.y + i * reversenum);
			Debug.Log ("masu.enemyFlag=" + masu.enemyFlag);
			Debug.Log ("sc.selfFlag=" + sc.selfFlag);
			// 敵の駒に当たったとき
			if (masu.enemyFlag && sc.selfFlag || masu.selfFlag && sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = i * reversenum;
				moves.Add (move);
				break;
			// 味方の駒に当たってないとき
			} else if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = i * reversenum;
				moves.Add (move);
			} else {
				break;
			}
		}
		for (int i = 1; i <= 8; i++) {
			MasuInit masu = manager.GetMasu (sc.x + -1 * i, sc.y);
			// 敵の駒に当たったとき
			if (masu.enemyFlag && sc.selfFlag || masu.selfFlag && sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = -1 * i;
				move.y = 0;
				moves.Add (move);
				break;
			// 味方の駒に当たってないとき
			} else if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = -1 * i;
				move.y = 0;
				moves.Add (move);
			} else {
				break;
			}
		}
		for (int i = 1; i <= 8; i++) {
			MasuInit masu = manager.GetMasu (sc.x, sc.y + -1 * i * reversenum);
			// 敵の駒に当たったとき
			if (masu.enemyFlag && sc.selfFlag || masu.selfFlag && sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = -1 * i * reversenum;
				moves.Add (move);
				break;
			} else if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = -1 * i * reversenum;
				moves.Add (move);
			} else {
				break;
			}
		}
		for (int i = 1; i <= 8; i++) {
			MasuInit masu = manager.GetMasu (sc.x + i, sc.y);
			// 敵の駒に当たったとき
			if (masu.enemyFlag && sc.selfFlag || masu.selfFlag && sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = i;
				move.y = 0;
				moves.Add (move);
				break;
			} else if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = i;
				move.y = 0;
				moves.Add (move);
			} else {
				break;
			}
		}
		return moves;
	}
	public List<KomaMove> GetMotigomaMoves (KomaScript sc) {
		List<KomaMove> moves = new List<KomaMove> ();
		MasuManager manager = MasuManager.Instance;
		for (int x = 1; x <= 9; x++) {
			for (int y = 1; y <= 9; y++) {
				MasuInit masu = manager.GetMasu (x, y);
				// 敵味方の駒がいないとき
				if (!masu.exists) {
					KomaMove move = new KomaMove ();
					move.x = x;
					move.y = y;
					moves.Add (move);
				} else {
					continue;
				}
			}
		}
		return moves;
	}
	
}
