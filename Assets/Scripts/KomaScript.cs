using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaScript : MonoBehaviour {

	public int x;
	public int y;
	public string komaName; // 駒の種類
	public string objName; // 駒のオブジェクト名
	public bool selfFlag = false; // 味方はtrue, その他がfalse
	public bool enemyFlag = false; // 敵はtrue, その他がfalse
	public bool chooseFlag = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetKoma(int x, int y, string objName) {
		string[] names = objName.Split (new char[]{ '_' });
		string name = "koma_" + names [1];
		MasuInit detail = new MasuInit ();
		this.x = x;
		this.y = y;
		this.komaName = name;
		this.objName = objName;
		if (int.Parse (names [1]) >= 15) {
			selfFlag = false;
			enemyFlag = true;
		} else {
			selfFlag = true;
			enemyFlag = false;
		}
	}
}
