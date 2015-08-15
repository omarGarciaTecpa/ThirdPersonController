using UnityEngine;
using System.Collections;

public class DungeonEntranceController : MonoBehaviour {
	public GameObject player;
	public Transform lookpoint;


	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("StartOfGame") == 1) {
			player.transform.position = new Vector3 (26.73f, 23.2f, 37.03f);
		} else {
			player.transform.position = new Vector3 (30.31f, 23.2f, 22.87f);
			player.transform.rotation = Quaternion.identity;
			PlayerPrefs.SetInt("StartOfGame", 0);
		}
	}


	

	void OnApplicationQuit() {
		PlayerPrefs.SetInt("StartOfGame", 0);
		PlayerPrefs.Save();
	}

}
