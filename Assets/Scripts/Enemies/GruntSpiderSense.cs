using UnityEngine;
using System.Collections;

public class GruntSpiderSense : MonoBehaviour {
	public GameObject spider;
	GruntSpider spiderController;

	void Start(){
		spiderController = spider.GetComponent<GruntSpider> ();
	}


	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			print ("Player found");
			spiderController.target = other.transform;
		}
	}




}
