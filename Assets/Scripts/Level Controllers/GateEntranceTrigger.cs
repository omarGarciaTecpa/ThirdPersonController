using UnityEngine;
using System.Collections;

public class GateEntranceTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag =="Player") {
			Debug.Log ("Player Entered");
			Application.LoadLevel("FirstFloor");
		}
	}
}
