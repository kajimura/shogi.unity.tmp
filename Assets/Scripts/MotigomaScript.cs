using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotigomaScript : MonoBehaviour {

	float per1x = 0.57f;
	float basex = -1.9f;
	// Use this for initialization
	void Start () {
		RefreshKoma ();
	}
	// 味方駒初期化
	void RefreshInit1() {
		string[] komaNames = {
			KomaConst.komaOu,
			KomaConst.komaHi,
			KomaConst.komaKa,
			KomaConst.komaKi,
			KomaConst.komaGi,
			KomaConst.komaKe,
			KomaConst.komaKy,
			KomaConst.komaFu
		};
		foreach (string komaName in komaNames) {
			GameObject obj = GameObject.Find (KomaConst.motigoma + komaName);
			Destroy (obj);
			GameObject objNum = GameObject.Find (KomaConst.motigoma + komaName + KomaConst.num);
			Destroy (objNum);
			GameObject objNum2 = GameObject.Find (KomaConst.motigoma + komaName + KomaConst.num2);
			Destroy (objNum2);
		}
	}
	// 敵駒初期化
	void RefreshInit2() {
		string[] komaNames = {
			KomaConst.komaOu2,
			KomaConst.komaHi2,
			KomaConst.komaKa2,
			KomaConst.komaKi2,
			KomaConst.komaGi2,
			KomaConst.komaKe2,
			KomaConst.komaKy2,
			KomaConst.komaFu2
		};
		foreach (string komaName in komaNames) {
			GameObject obj = GameObject.Find (KomaConst.motigoma + komaName);
			Destroy (obj);
			GameObject objNum = GameObject.Find (KomaConst.motigoma + komaName + KomaConst.num);
			Destroy (objNum);
			GameObject objNum2 = GameObject.Find (KomaConst.motigoma + komaName + KomaConst.num2);
			Destroy (objNum2);
		}
	}
	// 駒再描画
	public void RefreshKoma() {
		// 味方
		if (transform.name == "Motigoma1") {
			RefreshKoma1 ();
		} else if (transform.name == "Motigoma2") {
			RefreshKoma2 ();
		}
	}
	// 味方駒再描画
	void RefreshKoma1() {
		RefreshInit1 ();
		MotigomaManager manager = MotigomaManager.Instance;
		string[] komaNames = {
			KomaConst.komaOu,
			KomaConst.komaHi,
			KomaConst.komaKa,
			KomaConst.komaKi,
			KomaConst.komaGi,
			KomaConst.komaKe,
			KomaConst.komaKy,
			KomaConst.komaFu
		};
		int i = 0;
		foreach (string komaName in komaNames) {
			if (komaName.Equals (KomaConst.komaOu) && manager.ou >= 1) {
				createKomaObj (KomaConst.komaOu, i, manager.ou);
				i++;
			} else if (komaName.Equals (KomaConst.komaHi) && manager.hi >= 1) {
				createKomaObj (KomaConst.komaHi, i, manager.hi);
				i++;
			} else if (komaName.Equals (KomaConst.komaKa) && manager.ka >= 1) {
				createKomaObj (KomaConst.komaKa, i, manager.ka);
				i++;
			} else if (komaName.Equals (KomaConst.komaKi) && manager.ki >= 1) {
				createKomaObj (KomaConst.komaKi, i, manager.ki);
				i++;
			} else if (komaName.Equals (KomaConst.komaGi) && manager.gi >= 1) {
				createKomaObj (KomaConst.komaGi, i, manager.gi);
				i++;
			} else if (komaName.Equals (KomaConst.komaKe) && manager.ke >= 1) {
				createKomaObj (KomaConst.komaKe, i, manager.ke);
				i++;
			} else if (komaName.Equals (KomaConst.komaKy) && manager.ky >= 1) {
				createKomaObj (KomaConst.komaKy, i, manager.ky);
				i++;
			} else if (komaName.Equals (KomaConst.komaFu) && manager.fu >= 1) {
				createKomaObj (KomaConst.komaFu, i, manager.fu);
				i++;
			}
		}
	}
	// 敵駒再描画
	void RefreshKoma2() {
		RefreshInit2 ();
		MotigomaManager manager = MotigomaManager.Instance;
		string[] komaNames = {
			KomaConst.komaOu2,
			KomaConst.komaHi2,
			KomaConst.komaKa2,
			KomaConst.komaKi2,
			KomaConst.komaGi2,
			KomaConst.komaKe2,
			KomaConst.komaKy2,
			KomaConst.komaFu2
		};
		int i = 0;
		foreach (string komaName in komaNames) {
			if (komaName.Equals (KomaConst.komaOu2) && manager.ou2 >= 1) {
				createKomaObj (KomaConst.komaOu2, i, manager.ou2);
				i++;
			} else if (komaName.Equals(KomaConst.komaHi2) && manager.hi2 >= 1) {
				createKomaObj (KomaConst.komaHi2, i, manager.hi2);
				i++;
			} else if (komaName.Equals(KomaConst.komaKa2) && manager.ka2 >= 1) {
				createKomaObj (KomaConst.komaKa2, i, manager.ka2);
				i++;
			} else if (komaName.Equals(KomaConst.komaKi2) && manager.ki2 >= 1) {
				createKomaObj (KomaConst.komaKi2, i, manager.ki2);
				i++;
			} else if (komaName.Equals(KomaConst.komaGi2) && manager.gi2 >= 1) {
				createKomaObj (KomaConst.komaGi2, i, manager.gi2);
				i++;
			} else if (komaName.Equals(KomaConst.komaKe2) && manager.ke2 >= 1) {
				createKomaObj (KomaConst.komaKe2, i, manager.ke2);
				i++;
			} else if (komaName.Equals(KomaConst.komaKy2) && manager.ky2 >= 1) {
				createKomaObj (KomaConst.komaKy2, i, manager.ky2);
				i++;
			} else if (komaName.Equals(KomaConst.komaFu2) && manager.fu2 >= 1) {
				createKomaObj (KomaConst.komaFu2, i, manager.fu2);
				i++;
			}
		}
	}

	void createKomaObj(string name, int x, int cnt) {
		// 駒表示
		Vector3 komaScale = new Vector3 (100, 100, 0);
		Sprite[] sprites = Resources.LoadAll<Sprite> ("koma");
		Sprite sp = System.Array.Find<Sprite> (sprites, (sprite) => sprite.name.Equals (name));
		GameObject gameObj = new GameObject ();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas> ().transform;
		string objName = KomaConst.motigoma + name;
		gameObj.transform.name = objName;
		gameObj.transform.localScale = komaScale;
		gameObj.transform.position = new Vector3 (transform.position.x + basex + per1x * x, transform.position.y, 2);
		BoxCollider2D box = gameObj.AddComponent<BoxCollider2D>() as BoxCollider2D;
		KomaScript sc = gameObj.AddComponent<KomaScript>();
		sc.SetKoma (0, 0, objName);
		// 枚数
		createKomaNum2Obj (name, x, cnt); // 2桁目
		createKomaNumObj (name, x, cnt); // 1桁目
	}
	// 駒枚数1桁目
	void createKomaNumObj(string name, int x, int cnt) {
		cnt = (int) (cnt % 10);
		Vector3 numScale = new Vector3 (30, 20, 0);
		Sprite[] numSprites = Resources.LoadAll<Sprite>("Num");
		Sprite numSp = System.Array.Find<Sprite>(numSprites, (sprite) => sprite.name.Equals("Num_" + cnt));
		GameObject numGameObj = new GameObject();
		SpriteRenderer numSpriteRenderer = numGameObj.AddComponent<SpriteRenderer>();
		numSpriteRenderer.sprite = numSp;
		numGameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		numGameObj.transform.name = KomaConst.motigoma + name + KomaConst.num;
		numGameObj.transform.localScale = numScale;
		numGameObj.transform.position = new Vector3(transform.position.x + basex + per1x * x + 0.28f, transform.position.y + 0.2f, 2);
	}
	// 駒枚数2桁目
	void createKomaNum2Obj(string name, int x, int cnt) {
		int keta2Cnt = (int)(cnt / 10);
		if (keta2Cnt > 0) {
			Vector3 numScale = new Vector3 (30, 20, 0);
			Sprite[] numSprites = Resources.LoadAll<Sprite> ("Num");
			Sprite numSp = System.Array.Find<Sprite> (numSprites, (sprite) => sprite.name.Equals ("Num_" + keta2Cnt));
			GameObject numGameObj = new GameObject ();
			SpriteRenderer numSpriteRenderer = numGameObj.AddComponent<SpriteRenderer> ();
			numSpriteRenderer.sprite = numSp;
			numGameObj.transform.parent = FindObjectOfType<Canvas> ().transform;
			numGameObj.transform.name = KomaConst.motigoma + name + KomaConst.num2;
			numGameObj.transform.localScale = numScale;
			numGameObj.transform.position = new Vector3 (transform.position.x + basex + per1x * x + 0.28f - 0.1f, transform.position.y + 0.2f, 2);
		}
	}
	// 駒を浮かせる
	public void floatKomaObj(string objName) {
		GameObject komaObj = GameObject.Find (objName);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		// komaObj.transform.position = new Vector3 (transform.position.x + basex + per1x * x - 0.05f, transform.position.y + 0.05f, 2);
		komaObj.transform.position = new Vector3 (komaObj.transform.position.x - 0.05f, transform.position.y + 0.05f, 2);
	}
	// 駒を浮かせた駒を戻す
	public void resetFloatKomaObj(string objName) {
		GameObject komaObj = GameObject.Find (objName);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		// komaObj.transform.position = new Vector3 (transform.position.x + basex + per1x * x, transform.position.y, 2);
		komaObj.transform.position = new Vector3 (komaObj.transform.position.x + 0.05f, transform.position.y, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
