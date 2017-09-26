using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaFu : KomaBase {
	// 移動可能なマス取得
	public List<KomaMove> GetMoves (KomaScript sc, bool reverse = false) {
		int reversenum = 1;
		if (reverse) {
			reversenum = -1;
		}
		List<KomaMove> moves = new List<KomaMove>();
		MasuManager manager = MasuManager.Instance;
		int[] xs = {0};
		int[] ys = {-1};
		int i = 0;
		foreach (int x in xs) {
			int y = ys [i];
			MasuInit masu = manager.GetMasu (sc.x + x, sc.y + y * reversenum);
			if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = x;
				move.y = y * reversenum;
				moves.Add (move);
			}
			i++;
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
			bool nifuFlag = false;
			for (int y = ymin; y <= ymax; y++) {
				MasuInit masu = manager.GetMasu (x, y);
				// 味方側
				if (!reverse && masu.komaName.Equals(KomaConst.komaFu)) {
					nifuFlag = true;
					break;
				// 敵側
				} else if (reverse && masu.komaName.Equals(KomaConst.komaFu2)) {
					nifuFlag = true;
					break;
				}
			}
			if (!nifuFlag) {
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
		}
		return moves;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
