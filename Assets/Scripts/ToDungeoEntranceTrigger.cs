using UnityEngine;
using System.Collections;

public class ToDungeoEntranceTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("Player Exiting");
			PlayerPrefs.SetInt("StartOfGame", 1);
			Application.LoadLevel("DungeonEntrance");
		}
	}
}
