using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * マス管理
 * MasuManager manager = MasuManager.Instance;
 * manager.SetMasu(x, y);
 */
public class MasuManager : MonoBehaviour {
	private static MasuManager mInstance;
	// 9x9マスの駒の管理
	Dictionary<string, MasuInit> komas = new Dictionary<string, MasuInit>();
	private MasuManager () {
	}
	public static MasuManager Instance {
		get {
			if (mInstance == null) {
				GameObject go = new GameObject("KomaManager");
				mInstance = go.AddComponent<MasuManager>();
			}
			return mInstance;
		}
	}
	public void Init() {
		for (int x = 1; x <= 9; x++) {
			for (int y = 1; y <= 9; y++) {
				MasuInit masu = new MasuInit ();
				masu.Init (x, y);
				komas [x + "-" + y] = masu;
			}
		}
	}
	void Start () {
	}
	void Update () {
	}
	// マスを空に
	public void EmptyMasu(int x, int y) {
		if (x > 9 || y > 9 || x < 1 || y < 1) {
			return;
		}
		MasuInit masu = new MasuInit ();
		masu.Init (x, y);
		komas [x + "-" + y] = masu;
	}
	public void InitHirate() {
		Init ();
		SetMasu (5, 9, KomaConst.komaOu);
		SetMasu (2, 8, KomaConst.komaHi);
		SetMasu (8, 8, KomaConst.komaKa);
		SetMasu (6, 9, KomaConst.komaKi);
		SetMasu (4, 9, KomaConst.komaKi);
		SetMasu (7, 9, KomaConst.komaGi);
		SetMasu (3, 9, KomaConst.komaGi);
		SetMasu (8, 9, KomaConst.komaKe);
		SetMasu (2, 9, KomaConst.komaKe);
		SetMasu (9, 9, KomaConst.komaKy);
		SetMasu (1, 9, KomaConst.komaKy);
		for (int i = 1; i <= 9; i++) {
			SetMasu (i, 7, KomaConst.komaFu);
		}
		SetMasu (5, 1, KomaConst.komaGy2);
		SetMasu (8, 2, KomaConst.komaHi2);
		SetMasu (2, 2, KomaConst.komaKa2);
		SetMasu (6, 1, KomaConst.komaKi2);
		SetMasu (4, 1, KomaConst.komaKi2);
		SetMasu (7, 1, KomaConst.komaGi2);
		SetMasu (3, 1, KomaConst.komaGi2);
		SetMasu (8, 1, KomaConst.komaKe2);
		SetMasu (2, 1, KomaConst.komaKe2);
		SetMasu (9, 1, KomaConst.komaKy2);
		SetMasu (1, 1, KomaConst.komaKy2);
		for (int i = 1; i <= 9; i++) {
			SetMasu (i, 3, KomaConst.komaFu2);
		}
	}
	public void SetMasu(int x, int y, string name) {
		if (x > 9 || y > 9 || x < 1 || y < 1) {
			return;
		}
		string[] names = name.Split(new char[]{'_'});
		MasuInit masu = new MasuInit ();
		masu.x = x;
		masu.y = y;
		masu.komaName = name;
		masu.exists = true;
		if (int.Parse(names[1]) >= 15) {
			masu.selfFlag = false;
			masu.enemyFlag = true;
		} else {
			masu.selfFlag = true;
			masu.enemyFlag = false;
		}
		komas [x + "-" + y] = masu;
	}
	public void UpdMasuObjNameByXAndY(string objName, int x, int y) {
		if (x > 9 || y > 9 || x < 1 || y < 1) {
			return;
		}
		MasuInit masu = GetMasu (x, y);
		masu.objName = objName;
		komas [x + "-" + y] = masu;
	}
	public MasuInit GetMasu(int x, int y) {
		if (x > 9 || y > 9 || x < 1 || y < 1) {
			MasuInit masu = new MasuInit ();
			masu.Init (0, 0);
			return masu;
		}
		return komas [x + "-" + y];
	}
	/**
	 * P1-KY-KE-GI-KI-OU-KI-GI-KE-KY
		P2 * -HI *  *  *  *  * -KA * 
		P3-FU-FU-FU-FU-FU-FU-FU-FU-FU
		P4 *  *  *  *  *  *  *  *  * 
		P5 *  *  *  *  *  *  *  *  * 
		P6 *  *  *  *  *  *  *  *  * 
		P7+FU+FU+FU+FU+FU+FU+FU+FU+FU
		P8 * +KA *  *  *  *  * +HI * 
		P9+KY+KE+GI+KI+OU+KI+GI+KE+KY
	*/
	public string GetMasuStr() {
		string line = "";
		for (int y = 1; y <= 9; y++) {
			line += "P" + y;
			for (int x = 9; x >= 1; x--) {
				MasuInit masu = komas [x + "-" + y];
				if (masu.selfFlag) {
					line += "+";
				} else if (masu.enemyFlag) {
					line += "-";
				} else {
					line += " ";
				}
				if (masu.komaName != "") {
					line += KomaConst.GetKomaName (masu.komaName).Substring(0, 2).ToUpper() + "";
				} else {
					line += "* ";
				}
			}
			line += "\n";
		}
		return line;
	}
	public string GetMasuDetail() {
		string line = "";
		for (int y = 1; y <= 9; y++) {
			for (int x = 1; x <= 9; x++) {
				MasuInit masu = komas [x + "-" + y];
				line += "(" + x + "-" + y + ")";
				line += "selfFlag:" + masu.selfFlag + "\n";
				line += "enemyFlag:" + masu.enemyFlag + "\n";
				line += "exists:" + masu.exists + "\n";
				line += "komaName:" + masu.komaName + "\n";
				line += "objName:" + masu.objName + "\n";
			}
		}
		return line;
	}
	// lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL
	// lnsgksnl/1r5b1/pppp1ppp/9/9/9/PPPPP1PPP/1B7/LNSGKGSNL
	// lnsgkgP+nl/1r5b1/pppppp1pp/9/9/9/PPPPPP1PP/1B5R1/LNSGKGSNL
	public string GetSfen() {
		string line = "";
		int emptyCnt = 0;
		for (int y = 1; y <= 9; y++) {
			for (int x = 9; x >= 1; x--) {
				MasuInit masu = komas [x + "-" + y];
				if (masu.exists && emptyCnt > 0) {
					line += emptyCnt;
					emptyCnt = 0;
				}
				if (masu.komaName.Equals (KomaConst.komaFu)) {
					line += "P";
				} else if (masu.komaName.Equals (KomaConst.komaKy)) {
					line += "L";
				} else if (masu.komaName.Equals (KomaConst.komaKe)) {
					line += "N";
				} else if (masu.komaName.Equals (KomaConst.komaGi)) {
					line += "S";
				} else if (masu.komaName.Equals (KomaConst.komaKi)) {
					line += "G";
				} else if (masu.komaName.Equals (KomaConst.komaKa)) {
					line += "B";
				} else if (masu.komaName.Equals (KomaConst.komaHi)) {
					line += "R";
				} else if (masu.komaName.Equals (KomaConst.komaOu) || masu.komaName.Equals (KomaConst.komaGy)) {
					line += "K";
				} else if (masu.komaName.Equals (KomaConst.komaFu2)) {
					line += "p";
				} else if (masu.komaName.Equals (KomaConst.komaKy2)) {
					line += "l";
				} else if (masu.komaName.Equals (KomaConst.komaKe2)) {
					line += "n";
				} else if (masu.komaName.Equals (KomaConst.komaGi2)) {
					line += "s";
				} else if (masu.komaName.Equals (KomaConst.komaKi2)) {
					line += "g";
				} else if (masu.komaName.Equals (KomaConst.komaKa2)) {
					line += "b";
				} else if (masu.komaName.Equals (KomaConst.komaHi2)) {
					line += "r";
				} else if (masu.komaName.Equals (KomaConst.komaOu2) || masu.komaName.Equals (KomaConst.komaGy2)) {
					line += "k";
				} else if (masu.komaName.Equals (KomaConst.komaTo)) {
					line += "P+";
				} else if (masu.komaName.Equals (KomaConst.komaNy)) {
					line += "L+";
				} else if (masu.komaName.Equals (KomaConst.komaNk)) {
					line += "N+";
				} else if (masu.komaName.Equals (KomaConst.komaNg)) {
					line += "S+";
				} else if (masu.komaName.Equals (KomaConst.komaUm)) {
					line += "B+";
				} else if (masu.komaName.Equals (KomaConst.komaRy)) {
					line += "R+";
				} else if (masu.komaName.Equals (KomaConst.komaTo2)) {
					line += "p+";
				} else if (masu.komaName.Equals (KomaConst.komaNy2)) {
					line += "l+";
				} else if (masu.komaName.Equals (KomaConst.komaNk2)) {
					line += "n+";
				} else if (masu.komaName.Equals (KomaConst.komaNg2)) {
					line += "s+";
				} else if (masu.komaName.Equals (KomaConst.komaUm2)) {
					line += "b+";
				} else if (masu.komaName.Equals (KomaConst.komaRy2)) {
					line += "r+";
				} else if (!masu.exists) {
					emptyCnt++;
				}
			}
			if (emptyCnt > 0) {
				line += emptyCnt;
				emptyCnt = 0;
			}
			if (y < 9) {
				line += "/";
			}
		}
		MotigomaManager manager = MotigomaManager.Instance;
		string motigoma = manager.GetSfen ();
		return "sfen " + line + " w " + motigoma + " 1";
	}

}