using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector2 tap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition = Physics2D.OverlapPoint(tap);
			GameObject masuObj = GameObject.Find ("Canvas/Masu");
			MasuScript masuScript = masuObj.GetComponent<MasuScript> ();
			// 成り駒bgが開いている時
			if (masuScript.narigomaBgFlag) {
				if (collition) {
					string name = collition.transform.gameObject.name;
					if (name.IndexOf (KomaConst.narigomaBg) > -1) {
						// 駒を成る選択をした時
						if (name.Equals (KomaConst.narigomaBg + "1")) {
							masuScript.modKomanariObj (masuScript.chooseKomaObjName 
								, masuScript.narigomaBgName
								, masuScript.narigomaBgx
								, masuScript.narigomaBgy
							);
						}
						masuScript.DestroyNarigomaBg ();
						masuScript.narigomaBgFlag = false;
					}
				}
			// 駒が移動選択状態の時
			} else if (masuScript.chooseFlag) {
				if (collition) {
					string name = collition.transform.gameObject.name;
					if (name.IndexOf ("KomaAble") > -1) {
						Debug.Log (name);
						GameObject gameObj = GameObject.Find (name);
						KomaAble komaAble = gameObj.GetComponent<KomaAble> ();
						masuScript.MoveKomaObj (masuScript.chooseKomaObjName, komaAble.x, komaAble.y);
					}
				}
				// 持ち駒でない時の浮き駒戻し
				if (masuScript.chooseKomaObjName.IndexOf (KomaConst.motigoma) == -1) {
					masuScript.resetFloatKomaObj (masuScript.chooseKomaObjName);
				} else {
					// 持ち駒の時の浮き駒戻し
					if (KomaFunction.isSelfKoma (masuScript.chooseKomaObjName)) {
						GameObject motigomaObj = GameObject.Find ("Canvas/Motigoma1");
						MotigomaScript motigomaScript = motigomaObj.GetComponent<MotigomaScript> ();
						motigomaScript.resetFloatKomaObj (masuScript.chooseKomaObjName);
					} else {
						GameObject motigomaObj = GameObject.Find ("Canvas/Motigoma2");
						MotigomaScript motigomaScript = motigomaObj.GetComponent<MotigomaScript> ();
						motigomaScript.resetFloatKomaObj (masuScript.chooseKomaObjName);
					}
				}
				masuScript.DelchooseMoves ();
			} else {
				if (collition) {
					string name = collition.transform.gameObject.name;
					// 持ち駒の場合
					if (name.IndexOf (KomaConst.motigoma) > -1) {
						masuScript.chooseMotigoma (name);
					// 盤上の駒の場合
					} else {
						masuScript.chooseKoma (name);
					}
				}
			}
		}
	}
}
