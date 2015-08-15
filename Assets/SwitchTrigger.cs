using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {
	public GameObject target;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			print("User is stepping on switch");
			transform.position = new Vector3(transform.position.x,transform.position.y- 0.5f, transform.position.z);
			Destroy(target);
			Destroy(this.gameObject);
		}	
	}
}
