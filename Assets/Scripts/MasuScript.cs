using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasuScript : MonoBehaviour {
	float per1x = 0.585f;
	float per1y = 0.59325f;
	float basex = 2.90f;
	float basey = 4.18125f;
	// 駒の移動表示フラグ
	public bool chooseFlag = false;
	// 成り駒BGが表示されているかフラグ
	public bool narigomaBgFlag = false;
	// 駒のオブジェクト名
	public string chooseKomaObjName;
	// 選択駒の移動可能座標リスト
	public List<KomaMove> chooseMoves = new List<KomaMove>();
	// 成駒BGを開いた時の選択駒のx座標
	public int narigomaBgx = 0;
	// 成駒BGを開いた時の選択駒のy座標
	public int narigomaBgy = 0;
	// 成駒BGを開いた時の駒名
	public string narigomaBgName = "";

	// Use this for initialization
	void Start () {
		MasuManager manager = MasuManager.Instance;
		manager.Init ();
		// EmptyKoma ();
		manager.InitHirate ();
		RefreshKoma ();
	}
	public void EmptyKoma()
	{
		MasuManager manager = MasuManager.Instance;
		for (int y = 1; y <= 9; y++) {
			for (int x = 1; x <= 9; x++) {
				MasuInit masu = manager.GetMasu (x, y);
				if (masu.exists) {
					DestroyKomaObj (masu.objName);
				}
			}
		}
	}
	public void RefreshKoma()
	{
		MasuManager manager = MasuManager.Instance;
		for (int y = 1; y <= 9; y++) {
			for (int x = 1; x <= 9; x++) {
				MasuInit masu = manager.GetMasu (x, y);
				if (masu.exists) {
					string objName = CreateKomaObj (masu.komaName, x, y);
					manager.UpdMasuObjNameByXAndY (objName, x, y);
				}
			}
		}
	}
	// 駒作成
	public string CreateKomaObj(string komaName, int x, int y) {
		Vector3 komaScale = new Vector3 (100, 100, 0);
		Sprite[] sprites = Resources.LoadAll<Sprite>("koma");
		Sprite sp = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(komaName));
		GameObject gameObj = new GameObject();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		KomaManager komaManager = KomaManager.Instance;
		string objName = komaName + "_" + komaManager.issueKomaAttachId ();
		gameObj.transform.name = objName;
		gameObj.transform.localScale = komaScale;
		gameObj.transform.position = new Vector3(basex - per1x * x, basey - per1y * y, 2);
		BoxCollider2D box = gameObj.AddComponent<BoxCollider2D>() as BoxCollider2D;
		KomaScript sc = gameObj.AddComponent<KomaScript>();
		sc.SetKoma (x, y, objName);
		return objName;
	}
	// 駒削除
	public void DestroyKomaObj(string objName) {
		GameObject objKoma = transform.Find ("../" + objName).gameObject;
		Destroy(objKoma);
	}

	// Update is called once per frame
	void Update() {
	}
	// 駒選択処理
	public void chooseKoma(string name) {
		Debug.Log (name);
		floatKomaObj (name);
		string[] names = name.Split(new char[]{'_'});
		string komaname = "koma_" + names[1];
		Debug.Log (komaname);
		GameObject komaObj = GameObject.Find (name);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		List<KomaMove> moves = new List<KomaMove> ();
		if (komaname.Equals (KomaConst.komaOu) 
			|| komaname.Equals (KomaConst.komaGy)) {
			KomaOu koma = new KomaOu ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaHi)) {
			KomaHi koma = new KomaHi ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKa)) {
			KomaKa koma = new KomaKa ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKi)) {
			KomaKi koma = new KomaKi ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaGi)) {
			KomaGi koma = new KomaGi ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKe)) {
			KomaKe koma = new KomaKe ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKy)) {
			KomaKy koma = new KomaKy ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaFu)) {
			KomaFu koma = new KomaFu ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaRy)) {
			KomaRy koma = new KomaRy ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaUm)) {
			KomaUm koma = new KomaUm ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaNg)) {
			KomaNg koma = new KomaNg ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaNk)) {
			KomaNk koma = new KomaNk ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaNy)) {
			KomaNy koma = new KomaNy ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaTo)) {
			KomaTo koma = new KomaTo ();
			moves = koma.GetMoves (sc);
		} else if (komaname.Equals (KomaConst.komaOu2)
			|| komaname.Equals (KomaConst.komaGy2)) {
			KomaOu koma = new KomaOu ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaHi2)) {
			KomaHi koma = new KomaHi ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaKa2)) {
			KomaKa koma = new KomaKa ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaKi2)) {
			KomaKi koma = new KomaKi ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaGi2)) {
			KomaGi koma = new KomaGi ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaKe2)) {
			KomaKe koma = new KomaKe ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaKy2)) {
			KomaKy koma = new KomaKy ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaFu2)) {
			KomaFu koma = new KomaFu ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaRy2)) {
			KomaRy koma = new KomaRy ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaUm2)) {
			KomaUm koma = new KomaUm ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaNg2)) {
			KomaNg koma = new KomaNg ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaNk2)) {
			KomaNk koma = new KomaNk ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaNy2)) {
			KomaNy koma = new KomaNy ();
			moves = koma.GetMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaTo2)) {
			KomaTo koma = new KomaTo ();
			moves = koma.GetMoves (sc, true);
		}
		this.RefresAbles (sc, moves, name);
	}
	// 持ち駒選択処理
	public void chooseMotigoma(string name) {
		Debug.Log (name);

		// 選択持ち駒を浮かせる
		if (KomaFunction.isSelfKoma (name)) {
			GameObject obj = transform.Find ("../Motigoma1").gameObject;
			MotigomaScript mSc = obj.GetComponent<MotigomaScript> ();
			mSc.floatKomaObj (name);
		} else {
			GameObject obj = transform.Find ("../Motigoma2").gameObject;
			MotigomaScript mSc = obj.GetComponent<MotigomaScript> ();
			mSc.floatKomaObj (name);
		}

		string[] names = name.Split(new char[]{'_'});
		string komaname = "koma_" + names[1];
		Debug.Log (komaname);
		GameObject komaObj = GameObject.Find (name);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		List<KomaMove> moves = new List<KomaMove> ();
		if (komaname.Equals (KomaConst.komaOu) || komaname.Equals (KomaConst.komaGy)) {
			KomaOu koma = new KomaOu ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaHi)) {
			KomaHi koma = new KomaHi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKa)) {
			KomaKa koma = new KomaKa ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKi)) {
			KomaKi koma = new KomaKi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaGi)) {
			KomaGi koma = new KomaGi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKe)) {
			KomaKe koma = new KomaKe ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKy)) {
			KomaKy koma = new KomaKy ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaFu)) {
			KomaFu koma = new KomaFu ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaOu2) || komaname.Equals (KomaConst.komaGy2)) {
			KomaOu koma = new KomaOu ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaHi2)) {
			KomaHi koma = new KomaHi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKa2)) {
			KomaKa koma = new KomaKa ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKi2)) {
			KomaKi koma = new KomaKi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaGi2)) {
			KomaGi koma = new KomaGi ();
			moves = koma.GetMotigomaMoves (sc);
		} else if (komaname.Equals (KomaConst.komaKe2)) {
			KomaKe koma = new KomaKe ();
			moves = koma.GetMotigomaMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaKy2)) {
			KomaKy koma = new KomaKy ();
			moves = koma.GetMotigomaMoves (sc, true);
		} else if (komaname.Equals (KomaConst.komaFu2)) {
			KomaFu koma = new KomaFu ();
			moves = koma.GetMotigomaMoves (sc, true);
		}
		this.RefresAbles (sc, moves, name);
	}
	// 駒を浮かせる
	public void floatKomaObj(string objName) {
		GameObject komaObj = GameObject.Find (objName);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		komaObj.transform.position = new Vector3 (basex - per1x * sc.x - 0.05f, basey - per1y * sc.y + 0.05f, 0);

		iTween.ColorTo(komaObj, iTween.Hash("r" ,0.7f, "g" ,0.7f, "b" ,0.7f, "time", 0.5f, "loopType", "pingpong"));
	}
	// 駒を浮かせた駒を戻す
	public void resetFloatKomaObj(string objName) {
		GameObject komaObj = GameObject.Find (objName);
		KomaScript sc = komaObj.GetComponent<KomaScript> ();
		komaObj.transform.position = new Vector3 (basex - per1x * sc.x, basey - per1y * sc.y, 0);

		iTween.ColorTo(komaObj, iTween.Hash("r" ,1f, "g" ,1f, "b" ,1f, "time", 0.1f));
	}
	// 移動可能駒のマス表示
	public void RefresAbles(KomaScript sc, List<KomaMove> moves, string name)
	{
		List<KomaMove> chooseKomaMoves = new List<KomaMove> ();
		if (!chooseFlag) {
			int i = 0;
			foreach (KomaMove move in moves) {
				if (sc.x + move.x > 9 || sc.x + move.x < 1) {
					continue;
				}
				if (sc.y + move.y > 9 || sc.y + move.y < 1) {
					continue;
				}
				Sprite sp = Resources.Load<Sprite> ("KomaAble");
				GameObject gameObj = new GameObject ();
				SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer> ();
				spriteRenderer.sprite = sp;
				gameObj.transform.parent = FindObjectOfType<Canvas> ().transform;
				gameObj.transform.localScale = new Vector3 (140, 140, 0);
				gameObj.transform.name = "KomaAble" + i;
				gameObj.transform.position = new Vector3 (basex - per1x * (sc.x + move.x), basey - per1y * (sc.y + move.y), 0);
				BoxCollider2D box = gameObj.AddComponent<BoxCollider2D>() as BoxCollider2D;
				KomaAble komaAble = gameObj.AddComponent<KomaAble> ();
				komaAble.x = sc.x + move.x;
				komaAble.y = sc.y + move.y;
				i++;
				chooseKomaMoves.Add(move);
			}
			chooseFlag = true;
			chooseMoves = chooseKomaMoves;
			Debug.Log ("able objName=" + name);
			chooseKomaObjName = name;
		}
	}
	public void DelchooseMoves() {
		if (chooseFlag) {
			int i = 0;
			if (chooseMoves != null && chooseMoves.Count > 0) {
				foreach (KomaMove move in chooseMoves) {
					GameObject obj = transform.Find ("../KomaAble" + i).gameObject;
					Destroy (obj);
					i++;
				}
			}
			chooseFlag = false;
		}
	}
	// 駒移動処理
	public void MoveKomaObj(string name, int x, int y) {
		bool motigomaFlag = false;
		// 持ち駒の場合
		if (name.IndexOf (KomaConst.motigoma) > -1) {
			name = name.Replace (KomaConst.motigoma, "");
			MotigomaManager motigomaManager = MotigomaManager.Instance;
			motigomaManager.Minus (name);
			if (KomaFunction.isSelfKoma (name)) {
				GameObject obj = transform.Find ("../Motigoma1").gameObject;
				MotigomaScript mSc = obj.GetComponent<MotigomaScript> ();
				mSc.RefreshKoma ();
			} else {
				GameObject obj = transform.Find ("../Motigoma2").gameObject;
				MotigomaScript mSc = obj.GetComponent<MotigomaScript> ();
				mSc.RefreshKoma ();
			}
			name = CreateKomaObj (name, x, y);
			MasuManager manager = MasuManager.Instance;
			manager.SetMasu (x, y, KomaFunction.GetKomaNameByObjName(name));
			manager.UpdMasuObjNameByXAndY (name, x, y);
			motigomaFlag = true;
		}
		GameObject gameObj = GameObject.Find (name);
		KomaScript sc = gameObj.GetComponent<KomaScript> ();
		gameObj.transform.position = new Vector3(basex - per1x * x, basey - per1y * y, 2);
		// 持ち駒でない場合
		if (!motigomaFlag) {
			Debug.Log ("motigomadenai " + name);
			execCheckGetEnemyKoma (name, x, y);
			execCheckNarigoma (name, x, y);
			// 移動前のマスを初期化
			MasuManager manager = MasuManager.Instance;
			manager.EmptyMasu (sc.x, sc.y);
			sc.x = x;
			sc.y = y;
			manager.SetMasu (x, y, KomaFunction.GetKomaNameByObjName(name));
			manager.UpdMasuObjNameByXAndY (name, x, y);
		}
	}
	// 駒成確認＆実行時
	void execCheckNarigoma (string name, int x, int y) {
		GameObject gameObj = GameObject.Find(name);
		KomaScript sc = gameObj.GetComponent<KomaScript>();
		if (sc.selfFlag) {
			// 駒がまだ成ってない
			if (KomaFunction.isNotNarigoma(sc.komaName)) {
				if (y <= 3 || sc.y <= 3 && sc.y != 0) {
					if (KomaFunction.isRequireNarigoma (sc.komaName, x, y)) {
						modKomanariObj (chooseKomaObjName, KomaFunction.GetNarigomaByKoma (sc.komaName), x, y);
					} else {
						string[] names = name.Split (new char[]{ '_' });
						name = "koma_" + names [1];
						CreateNarigomaBg (KomaFunction.GetNarigomaByKoma (name), x, y);
						CreateNarigomaBg2 (name, x, y);
						narigomaBgFlag = true;
					}
				}
			}
		} else if (sc.enemyFlag) {
			// 駒がまだ成ってない
			if (KomaFunction.isNotNarigoma(sc.komaName)) {
				if (y >= 7 || sc.y >= 7) {
					if (KomaFunction.isRequireNarigoma (sc.komaName, x, y)) {
						modKomanariObj (chooseKomaObjName, KomaFunction.GetNarigomaByKoma (sc.komaName), x, y);
					} else {
						string[] names = name.Split (new char[]{ '_' });
						name = "koma_" + names [1];
						CreateNarigomaBg (KomaFunction.GetNarigomaByKoma (name), x, y);
						CreateNarigomaBg2 (name, x, y);
						narigomaBgFlag = true;
					}
				}
			}
		}
	}
	// 成駒BGの成り駒側BG
	void CreateNarigomaBg(string name, int x, int y) {
		Vector3 komaScale = new Vector3 (150, 200, 0);
		Sprite sp = Resources.Load<Sprite>("NarigomaBg");
		GameObject gameObj = new GameObject();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		gameObj.transform.name = KomaConst.narigomaBg + "1";
		gameObj.transform.localScale = komaScale;
		float xPlus = 0;
		if (x == 9) {
			xPlus = 0.20f;
		} else if (x == 1) {
			xPlus = -0.15f;
		}
		gameObj.transform.position = new Vector3(basex - per1x * x - 0.30f + xPlus, basey - per1y * y, -2);
		spriteRenderer.color = new Color (0.8f, 0.8f, 0.5f, 1f);
		BoxCollider2D box = gameObj.AddComponent<BoxCollider2D>() as BoxCollider2D;
		NarigomaBgScript sc = gameObj.AddComponent<NarigomaBgScript>();
		narigomaBgx = x;
		narigomaBgy = y;
		narigomaBgName = name;
		CreateNarigomaBgKomaObj (name, x, y);
	}
	// 成駒BGの通常駒側BG
	void CreateNarigomaBg2(string name, int x, int y) {
		Vector3 komaScale = new Vector3 (150, 200, 0);
		Sprite sp = Resources.Load<Sprite>("NarigomaBg");
		GameObject gameObj = new GameObject();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		gameObj.transform.name = KomaConst.narigomaBg + "2";
		gameObj.transform.localScale = komaScale;
		float xPlus = 0;
		if (x == 9) {
			xPlus = 0.20f;
		} else if (x == 1) {
			xPlus = -0.15f;
		}
		gameObj.transform.position = new Vector3(basex - per1x * x + 0.30f + xPlus, basey - per1y * y, -2);
		spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
		BoxCollider2D box = gameObj.AddComponent<BoxCollider2D>() as BoxCollider2D;
		NarigomaBgScript sc = gameObj.AddComponent<NarigomaBgScript>();
		CreateNarigomaBg2KomaObj (name, x, y);
	}
	// 成駒BGの成駒側内部駒作成
	public void CreateNarigomaBgKomaObj(string name, int x, int y) {
		Vector3 komaScale = new Vector3 (100, 100, 0);
		Sprite[] sprites = Resources.LoadAll<Sprite>("koma");
		Sprite sp = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(name));
		GameObject gameObj = new GameObject();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		gameObj.transform.name = KomaConst.narigomaBg + "koma1";
		gameObj.transform.localScale = komaScale;
		float xPlus = 0;
		if (x == 9) {
			xPlus = 0.20f;
		} else if (x == 1) {
			xPlus = -0.15f;
		}
		gameObj.transform.position = new Vector3(basex - per1x * x - 0.30f + xPlus, basey - per1y * y, -2);
		spriteRenderer.sortingOrder = 1;
	}
	// 成駒BGの通常側内部駒作成
	public void CreateNarigomaBg2KomaObj(string name, int x, int y) {
		Vector3 komaScale = new Vector3 (100, 100, 0);
		Sprite[] sprites = Resources.LoadAll<Sprite>("koma");
		Sprite sp = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(name));
		GameObject gameObj = new GameObject();
		SpriteRenderer spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = sp;
		gameObj.transform.parent = FindObjectOfType<Canvas>().transform;
		gameObj.transform.name = KomaConst.narigomaBg + "koma2";
		gameObj.transform.localScale = komaScale;
		float xPlus = 0;
		if (x == 9) {
			xPlus = 0.20f;
		} else if (x == 1) {
			xPlus = -0.15f;
		}
		gameObj.transform.position = new Vector3(basex - per1x * x + 0.30f + xPlus, basey - per1y * y, -2);
		spriteRenderer.sortingOrder = 1;
	}
	public void DestroyNarigomaBg() {
		GameObject obj = transform.Find ("../" + KomaConst.narigomaBg + "1").gameObject;
		Destroy (obj);
		GameObject obj2 = transform.Find ("../" + KomaConst.narigomaBg + "2").gameObject;
		Destroy (obj2);
		GameObject objKoma = transform.Find ("../" + KomaConst.narigomaBg + "koma1").gameObject;
		Destroy (objKoma);
		GameObject objKoma2 = transform.Find ("../" + KomaConst.narigomaBg + "koma2").gameObject;
		Destroy (objKoma2);
	}
	// 相手の駒を取ったか確認＆実行時
	void execCheckGetEnemyKoma (string objName, int x, int y) {
		GameObject gameObj = GameObject.Find(objName);
		KomaScript sc = gameObj.GetComponent<KomaScript>();
		MasuManager manager = MasuManager.Instance;
		MasuInit masu = manager.GetMasu (x, y);
		MotigomaManager mManager = MotigomaManager.Instance;
		if (sc.selfFlag && masu.enemyFlag) {
			if (masu.komaName.Equals (KomaConst.komaOu2) || masu.komaName.Equals (KomaConst.komaGy2)) {
				mManager.Plus (KomaConst.komaOu);
			} else if (masu.komaName.Equals (KomaConst.komaHi2) || masu.komaName.Equals (KomaConst.komaRy2)) {
				mManager.Plus (KomaConst.komaHi);
			} else if (masu.komaName.Equals (KomaConst.komaKa2) || masu.komaName.Equals (KomaConst.komaUm2)) {
				mManager.Plus (KomaConst.komaKa);
			} else if (masu.komaName.Equals (KomaConst.komaKi2)) {
				mManager.Plus (KomaConst.komaKi);
			} else if (masu.komaName.Equals (KomaConst.komaGi2) || masu.komaName.Equals (KomaConst.komaNg2)) {
				mManager.Plus (KomaConst.komaGi);
			} else if (masu.komaName.Equals (KomaConst.komaKe2) || masu.komaName.Equals (KomaConst.komaNk2)) {
				mManager.Plus (KomaConst.komaKe);
			} else if (masu.komaName.Equals (KomaConst.komaKy2) || masu.komaName.Equals (KomaConst.komaNy2)) {
				mManager.Plus (KomaConst.komaKy);
			} else if (masu.komaName.Equals (KomaConst.komaFu2) || masu.komaName.Equals (KomaConst.komaTo2)) {
				mManager.Plus (KomaConst.komaFu);
			}
			GameObject obj = transform.Find ("../Motigoma1").gameObject;
			MotigomaScript mSc = obj.GetComponent<MotigomaScript>();
			mSc.RefreshKoma();
			DestroyKomaObj (masu.objName);
		} else if (sc.enemyFlag && masu.selfFlag) {
			if (masu.komaName.Equals (KomaConst.komaOu) || masu.komaName.Equals (KomaConst.komaGy)) {
				mManager.Plus (KomaConst.komaOu2);
			} else if (masu.komaName.Equals (KomaConst.komaHi) || masu.komaName.Equals (KomaConst.komaRy)) {
				mManager.Plus (KomaConst.komaHi2);
			} else if (masu.komaName.Equals (KomaConst.komaKa) || masu.komaName.Equals (KomaConst.komaUm)) {
				mManager.Plus (KomaConst.komaKa2);
			} else if (masu.komaName.Equals (KomaConst.komaKi)) {
				mManager.Plus (KomaConst.komaKi2);
			} else if (masu.komaName.Equals (KomaConst.komaGi) || masu.komaName.Equals (KomaConst.komaNg)) {
				mManager.Plus (KomaConst.komaGi2);
			} else if (masu.komaName.Equals (KomaConst.komaKe) || masu.komaName.Equals (KomaConst.komaNk)) {
				mManager.Plus (KomaConst.komaKe2);
			} else if (masu.komaName.Equals (KomaConst.komaKy) || masu.komaName.Equals (KomaConst.komaNy)) {
				mManager.Plus (KomaConst.komaKy2);
			} else if (masu.komaName.Equals (KomaConst.komaFu) || masu.komaName.Equals (KomaConst.komaTo)) {
				mManager.Plus (KomaConst.komaFu2);
			}
			GameObject obj = transform.Find ("../Motigoma2").gameObject;
			MotigomaScript mSc = obj.GetComponent<MotigomaScript>();
			mSc.RefreshKoma();
			DestroyKomaObj (masu.objName);
		}
	}
	public void modKomanariObj(string objName, string narigomaName, int x, int y) {
		string objNarigomaName = CreateKomaObj (narigomaName, x, y);
		MasuManager manager = MasuManager.Instance;
		manager.SetMasu (x, y, KomaFunction.GetKomaNameByObjName(objNarigomaName));
		manager.UpdMasuObjNameByXAndY (objNarigomaName, x, y);
		DestroyKomaObj (objName);
	}
}
