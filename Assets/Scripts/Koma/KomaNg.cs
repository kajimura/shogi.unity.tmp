using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaNg : KomaBase {

	public List<KomaMove> GetMoves (KomaScript sc, bool reverse = false) {
		int reversenum = 1;
		if (reverse) {
			reversenum = -1;
		}
		List<KomaMove> moves = new List<KomaMove>();
		MasuManager manager = MasuManager.Instance;
		int[] xs = {0, -1, -1, 0, 1, 1};
		int[] ys = {1, 0, -1, -1, -1, 0};
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
}
