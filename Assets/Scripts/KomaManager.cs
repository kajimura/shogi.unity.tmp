using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 駒管理
 * KomaManager manager = KomaManager.Instance;
 */
public class KomaManager : MonoBehaviour {
	private static KomaManager mInstance;
	// 駒作成ID()
	public int komaAttachId = 0;
	private KomaManager () {
	}
	public static KomaManager Instance {
		get {
			if (mInstance == null) {
				GameObject go = new GameObject("KomaManager");
				mInstance = go.AddComponent<KomaManager>();
			}
			return mInstance;
		}
	}
	// 駒作成するたびにIDをインクリメンタルする
	public int issueKomaAttachId(){
		komaAttachId++;
		return komaAttachId;
	}
	void Start () {
	}
	void Update () {
	}
}