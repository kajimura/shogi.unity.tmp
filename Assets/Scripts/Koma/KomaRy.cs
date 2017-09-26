using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaRy : KomaHi {

	public List<KomaMove> GetMoves (KomaScript sc, bool reverse = false) {
		int reversenum = 1;
		if (reverse) {
			reversenum = -1;
		}
		List<KomaMove> moves = new List<KomaMove> ();
		MasuManager manager = MasuManager.Instance;

		moves = base.GetMoves (sc, reverse);

		int[] xs = { 1, -1, -1, 1 };
		int[] ys = { 1, 1, -1, -1 };
		int j = 0;
		foreach (int x in xs) {
			int y = ys [j];
			MasuInit masu = manager.GetMasu (sc.x + x, sc.y + y * reversenum);
			if (masu.selfFlag != sc.selfFlag || masu.enemyFlag != sc.enemyFlag) {
				KomaMove move = new KomaMove ();
				move.x = x;
				move.y = y * reversenum;
				moves.Add (move);
			}
			j++;
		}
		return moves;
	}
}
