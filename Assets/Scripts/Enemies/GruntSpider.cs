using UnityEngine;
using System.Collections;

public class GruntSpider : MonoBehaviour {
	public float spiderHP = 10;
	Animator anim;
	NavMeshAgent nav;
	public Transform target;
	SpiderState state;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		state = SpiderState.rushing;

	}
	
	// Update is called once per frame
	void Update () {
		if(spiderHP <= 0){
			resetTriggers();
			anim.SetTrigger("dieTrigger");
			Destroy(this.transform.parent.gameObject, 3);
			Destroy(this.gameObject, 3);
			state = SpiderState.dead;
			nav.Stop();
			return;
		}
		if (target && state != SpiderState.dead) {StartCoroutine(Follow());}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerWeapon") {
			if(spiderHP > 0){
				spiderHP--;
				print("Spider was damaged HP: "+ spiderHP);
			}
		}
	}



	void resetTriggers(){
		anim.ResetTrigger ("idleTrigger");
		anim.ResetTrigger ("attackTrigger");
		anim.ResetTrigger ("walkTrigger");
	}


	IEnumerator Follow(){
		resetTriggers ();
		switch(state){
		case SpiderState.rushing:
			resetTriggers();
			anim.SetTrigger("walkTrigger");
			nav.SetDestination(target.position);
			if(nav.remainingDistance >0 && nav.remainingDistance < 2f){
				state = SpiderState.attacking;
			}
			break;
		case SpiderState.attacking:
			transform.LookAt(target.position);
			resetTriggers();
			anim.SetTrigger("attackTrigger");
			yield return new WaitForSeconds (0.25f);
			resetTriggers();
			anim.SetTrigger("idleTrigger");
			yield return new WaitForSeconds (3f);
			state = SpiderState.rushing;
			break;
		}
	}

}


enum SpiderState{
	rushing,attacking, dead
}
