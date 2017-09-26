using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaConst : MonoBehaviour {

	public static string komaOu = "koma_0";
	public static string komaHi = "koma_1";
	public static string komaKa = "koma_2";
	public static string komaKi = "koma_3";
	public static string komaGi = "koma_4";
	public static string komaKe = "koma_5";
	public static string komaKy = "koma_6";
	public static string komaFu = "koma_7";
	public static string komaGy = "koma_8";
	public static string komaRy = "koma_9";
	public static string komaUm = "koma_10";
	public static string komaNg = "koma_11";
	public static string komaNk = "koma_12";
	public static string komaNy = "koma_13";
	public static string komaTo = "koma_14";
	public static string komaOu2 = "koma_15";
	public static string komaHi2 = "koma_16";
	public static string komaKa2 = "koma_17";
	public static string komaKi2 = "koma_18";
	public static string komaGi2 = "koma_19";
	public static string komaKe2 = "koma_20";
	public static string komaKy2 = "koma_21";
	public static string komaFu2 = "koma_22";
	public static string komaGy2 = "koma_23";
	public static string komaRy2 = "koma_24";
	public static string komaUm2 = "koma_25";
	public static string komaNg2 = "koma_26";
	public static string komaNk2 = "koma_27";
	public static string komaNy2 = "koma_28";
	public static string komaTo2 = "koma_29";
	public static string motigoma = "Motigoma";
	public static string num = "Num";
	public static string num2 = "Num2";
	public static string narigomaBg = "NarigomaBg";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static string GetKomaName(string name) {
		Dictionary<string, string> komaNames = new Dictionary<string, string>();
		komaNames.Add ("koma_0", "Ou");
		komaNames.Add ("koma_1", "Hi"); 
		komaNames.Add ("koma_2", "Ka");
		komaNames.Add ("koma_3", "Ki");
		komaNames.Add ("koma_4", "Gi");
		komaNames.Add ("koma_5", "Ke");
		komaNames.Add ("koma_6", "Ky");
		komaNames.Add ("koma_7", "Fu");
		komaNames.Add ("koma_8", "Gy");
		komaNames.Add ("koma_9", "Ry");
		komaNames.Add ("koma_10", "Um");
		komaNames.Add ("koma_11", "Ng");
		komaNames.Add ("koma_12", "Nk");
		komaNames.Add ("koma_13", "Ny");
		komaNames.Add ("koma_14", "To");
		komaNames.Add ("koma_15", "Oum");
		komaNames.Add ("koma_16", "Him");
		komaNames.Add ("koma_17", "Kam");
		komaNames.Add ("koma_18", "Kim");
		komaNames.Add ("koma_19", "Gim");
		komaNames.Add ("koma_20", "Kem");
		komaNames.Add ("koma_21", "Kym");
		komaNames.Add ("koma_22", "Fum");
		komaNames.Add ("koma_23", "Gym");
		komaNames.Add ("koma_24", "Rym");
		komaNames.Add ("koma_25", "Umm");
		komaNames.Add ("koma_26", "Ngm");
		komaNames.Add ("koma_27", "Nkm");
		komaNames.Add ("koma_28", "Nym");
		komaNames.Add ("koma_29", "Tom");
		return komaNames [name];
	}
}
