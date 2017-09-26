using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaFunction {
	// 通常駒を成駒へ
	public static string GetNarigomaByKoma(string name) {
		if (name.Equals (KomaConst.komaHi)) {
			return KomaConst.komaRy;
		} else if (name.Equals (KomaConst.komaKa)) {
			return KomaConst.komaUm;
		} else if (name.Equals (KomaConst.komaGi)) {
			return KomaConst.komaNg;
		} else if (name.Equals (KomaConst.komaKe)) {
			return KomaConst.komaNk;
		} else if (name.Equals (KomaConst.komaKy)) {
			return KomaConst.komaNy;
		} else if (name.Equals (KomaConst.komaFu)) {
			return KomaConst.komaTo;
		} else if (name.Equals (KomaConst.komaHi2)) {
			return KomaConst.komaRy2;
		} else if (name.Equals (KomaConst.komaKa2)) {
			return KomaConst.komaUm2;
		} else if (name.Equals (KomaConst.komaGi2)) {
			return KomaConst.komaNg2;
		} else if (name.Equals (KomaConst.komaKe2)) {
			return KomaConst.komaNk2;
		} else if (name.Equals (KomaConst.komaKy2)) {
			return KomaConst.komaNy2;
		} else if (name.Equals (KomaConst.komaFu2)) {
			return KomaConst.komaTo2;
		}
		return name;
	}
	// 成れるけどまだなってない駒判定
	public static bool isNotNarigoma(string name) {
		if (name.Equals(KomaConst.komaHi)
			|| name.Equals(KomaConst.komaKa)
			|| name.Equals(KomaConst.komaGi)
			|| name.Equals(KomaConst.komaKe)
			|| name.Equals(KomaConst.komaKy)
			|| name.Equals(KomaConst.komaFu)
			|| name.Equals(KomaConst.komaHi2)
			|| name.Equals(KomaConst.komaKa2)
			|| name.Equals(KomaConst.komaGi2)
			|| name.Equals(KomaConst.komaKe2)
			|| name.Equals(KomaConst.komaKy2)
			|| name.Equals(KomaConst.komaFu2)) {
			return true;
		}
		return false;
	}
	// 成り必須判定
	public static bool isRequireNarigoma(string name, int x , int y) {
		if (y == 1 && (name.Equals(KomaConst.komaFu) || name.Equals(KomaConst.komaKy))) {
			return true;
		} else if (y <= 2 && (name.Equals(KomaConst.komaKe))) {
			return true;
		} else if (y == 9 && (name.Equals(KomaConst.komaFu2) || name.Equals(KomaConst.komaKy2))) {
			return true;
		} else if (y >= 8 && (name.Equals(KomaConst.komaKe2))) {
			return true;
		}
		return false;
	}
	// 味方ゴマであればtrue
	public static bool isSelfKoma(string name) {
		string[] names = name.Split (new char[]{ '_' });
		if (int.Parse (names [1]) <= 14) {
			return true;
		}
		return false;
	}
	public static string GetKomaNameByObjName(string objName) {
		string[] names = objName.Split (new char[]{ '_' });
		return "koma_" + names [1];
	}
}
