using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 持ち駒管理
 * MotigomaManager manager = MotigomaManager.Instance;
 * manager.fu = 1;
 */
public class MotigomaManager : MonoBehaviour {
	private static MotigomaManager mInstance;
	public int fu = 0;
	public int ky = 0;
	public int ke = 0;
	public int gi = 0;
	public int ki = 0;
	public int ka = 0;
	public int hi = 0;
	public int ou = 0;
	public int fu2 = 0;
	public int ky2 = 0;
	public int ke2 = 0;
	public int gi2 = 0;
	public int ki2 = 0;
	public int ka2 = 0;
	public int hi2 = 0;
	public int ou2 = 0;
	private MotigomaManager () {
	}
	public static MotigomaManager Instance {
		get {
			if (mInstance == null) {
				GameObject go = new GameObject("MotigomaManager");
				mInstance = go.AddComponent<MotigomaManager>();
			}
			return mInstance;
		}
	}
	public void Plus(string name) {
		if (name.Equals (KomaConst.komaOu) || name.Equals (KomaConst.komaGy)) {
			ou++;
		} else if (name.Equals (KomaConst.komaHi)) {
			hi++;
		} else if (name.Equals (KomaConst.komaKa)) {
			ka++;
		} else if (name.Equals (KomaConst.komaKi)) {
			ki++;
		} else if (name.Equals (KomaConst.komaGi)) {
			gi++;
		} else if (name.Equals (KomaConst.komaKe)) {
			ke++;
		} else if (name.Equals (KomaConst.komaKy)) {
			ky++;
		} else if (name.Equals (KomaConst.komaFu)) {
			fu++;
		} else if (name.Equals (KomaConst.komaRy)) {
			hi++;
		} else if (name.Equals (KomaConst.komaUm)) {
			ka++;
		} else if (name.Equals (KomaConst.komaNg)) {
			gi++;
		} else if (name.Equals (KomaConst.komaNk)) {
			ke++;
		} else if (name.Equals (KomaConst.komaNy)) {
			ky++;
		} else if (name.Equals (KomaConst.komaTo)) {
			fu++;
		} else if (name.Equals (KomaConst.komaOu2) || name.Equals (KomaConst.komaGy2)) {
			ou2++;
		} else if (name.Equals (KomaConst.komaHi2)) {
			hi2++;
		} else if (name.Equals(KomaConst.komaKa2)) {
			ka2++;
		} else if (name.Equals(KomaConst.komaKi2)) {
			ki2++;
		} else if (name.Equals(KomaConst.komaGi2)) {
			gi2++;
		} else if (name.Equals(KomaConst.komaKe2)) {
			ke2++;
		} else if (name.Equals(KomaConst.komaKy2)) {
			ky2++;
		} else if (name.Equals(KomaConst.komaFu2)) {
			fu2++;
		} else if (name.Equals (KomaConst.komaRy2)) {
			hi2++;
		} else if (name.Equals (KomaConst.komaUm2)) {
			ka2++;
		} else if (name.Equals (KomaConst.komaNg2)) {
			gi2++;
		} else if (name.Equals (KomaConst.komaNk2)) {
			ke2++;
		} else if (name.Equals (KomaConst.komaNy2)) {
			ky2++;
		} else if (name.Equals (KomaConst.komaTo2)) {
			fu2++;
		}
	}
	public void Minus(string name) {
		if (name.Equals (KomaConst.komaOu) || name.Equals (KomaConst.komaGy)) {
			ou--;
		} else if (name.Equals (KomaConst.komaHi)) {
			hi--;
		} else if (name.Equals (KomaConst.komaKa)) {
			ka--;
		} else if (name.Equals (KomaConst.komaKi)) {
			ki--;
		} else if (name.Equals (KomaConst.komaGi)) {
			gi--;
		} else if (name.Equals (KomaConst.komaKe)) {
			ke--;
		} else if (name.Equals (KomaConst.komaKy)) {
			ky--;
		} else if (name.Equals (KomaConst.komaFu)) {
			fu--;
		} else if (name.Equals (KomaConst.komaOu2) || name.Equals (KomaConst.komaGy2)) {
			ou2--;
		} else if (name.Equals (KomaConst.komaHi2)) {
			hi2--;
		} else if (name.Equals(KomaConst.komaKa2)) {
			ka2--;
		} else if (name.Equals(KomaConst.komaKi2)) {
			ki2--;
		} else if (name.Equals(KomaConst.komaGi2)) {
			gi2--;
		} else if (name.Equals(KomaConst.komaKe2)) {
			ke2--;
		} else if (name.Equals(KomaConst.komaKy2)) {
			ky2--;
		} else if (name.Equals(KomaConst.komaFu2)) {
			fu2--;
		}
	}
	// KRB2G2S2N2L9Pkrb2g2s2n2l9p
	public string GetSfen() {
		string line = "";
		if (ou > 0) {
			line += "K";
			if (ou > 1) {
				line += ou;
			}
		}
		if (hi > 0) {
			line += "R";
			if (hi > 1) {
				line += hi;
			}
		}
		if (ka > 0) {
			line += "B";
			if (ka > 1) {
				line += ka;
			}
		}
		if (ki > 0) {
			line += "G";
			if (ki > 1) {
				line += ki;
			}
		}
		if (gi > 0) {
			line += "S";
			if (gi > 1) {
				line += gi;
			}
		}
		if (ke > 0) {
			line += "N";
			if (ke > 1) {
				line += ke;
			}
		}
		if (ky > 0) {
			line += "L";
			if (ky > 1) {
				line += ky;
			}
		}
		if (fu > 0) {
			line += "P";
			if (fu > 1) {
				line += fu;
			}
		}
		if (ou2 > 0) {
			line += "k";
			if (ou2 > 1) {
				line += ou2;
			}
		}
		if (hi2 > 0) {
			line += "r";
			if (hi2 > 1) {
				line += hi2;
			}
		}
		if (ka2 > 0) {
			line += "b";
			if (ka2 > 1) {
				line += ka2;
			}
		}
		if (ki2 > 0) {
			line += "g";
			if (ki2 > 1) {
				line += ki2;
			}
		}
		if (gi2 > 0) {
			line += "s";
			if (gi2 > 1) {
				line += gi2;
			}
		}
		if (ke2 > 0) {
			line += "n";
			if (ke2 > 1) {
				line += ke2;
			}
		}
		if (ky2 > 0) {
			line += "l";
			if (ky2 > 1) {
				line += ky2;
			}
		}
		if (fu2 > 0) {
			line += "p";
			if (fu2 > 1) {
				line += fu2;
			}
		}
		return line;
	}
	void Start () {
		
	}
	void Update () {
		
	}
}