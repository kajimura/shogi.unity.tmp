using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaKy : KomaBase {

	public List<KomaMove> GetMoves (KomaScript sc, bool reverse = false) {
		int reversenum = 1;
		if (reverse) {
			reversenum = -1;
		}
		List<KomaMove> moves = new List<KomaMove> ();
		MasuManager manager = MasuManager.Instance;
		for (int i = 1; i <= 8; i++) {
			MasuInit masu = manager.GetMasu (sc.x, sc.y + -1 * i * reversenum);
			// 敵の駒に当たったとき
			if (masu.enemyFlag && sc.selfFlag || masu.selfFlag && sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = -1 * i * reversenum;
				moves.Add (move);
				break;
			// 味方の駒に当たってないとき
			} else if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = 0;
				move.y = -1 * i * reversenum;
				moves.Add (move);
			} else {
				break;
			}
		}
		return moves;
	}
	public List<KomaMove> GetMotigomaMoves (KomaScript sc, bool reverse = false) {
		List<KomaMove> moves = new List<KomaMove> ();
		MasuManager manager = MasuManager.Instance;
		int ymin = 1;
		int ymax = 9;
		if (reverse) {
			ymax = 8;
		} else {
			ymin = 2;
		}
		for (int x = 1; x <= 9; x++) {
			for (int y = ymin; y <= ymax; y++) {
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
