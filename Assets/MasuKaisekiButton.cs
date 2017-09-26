using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasuKaisekiButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick()
	{
		MasuManager manager = MasuManager.Instance;
		Debug.Log(manager.GetMasuStr ());
		Debug.Log (manager.GetSfen ());
		Debug.Log (manager.GetMasuDetail ());
	}
}
