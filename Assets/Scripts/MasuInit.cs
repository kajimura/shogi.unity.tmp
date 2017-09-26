using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1マスの詳細クラス
 */
public class MasuInit : MonoBehaviour {
	public int x;
	public int y;
	public string komaName; // 駒の種類
	public string objName; // 駒のオブジェクト名
	public bool exists = false; // 駒があればtrue, なければfalse
	public bool selfFlag = false; // 味方はtrue, その他がfalse
	public bool enemyFlag = false; // 敵はtrue, その他がfalse
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Init(int x, int y) {
		this.x = x;
		this.y = y;
		komaName = "";
		objName = "";
		exists = false;
		selfFlag = false;
		enemyFlag = false;
	}
}
