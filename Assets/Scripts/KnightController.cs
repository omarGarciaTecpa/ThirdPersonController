using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour {
	#region Variables
	float horizontalVal, verticalVal;
	Animator playerAnim;
	public float spinSpeed = 50;
	CharacterController controller;
	public BoxCollider sword;
	#endregion

	#region Metodos de Unity
	// Use this for initialization
	void Start () {
		playerAnim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		verticalVal = Input.GetAxis ("Vertical");
		horizontalVal = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown (KeyCode.J)) {
			resetTriggers ();
			playerAnim.SetTrigger ("attackTrigger");
			StartCoroutine(SwordAttack());

		} else if(Input.GetKeyDown (KeyCode.I)){
			resetTriggers();
			playerAnim.SetTrigger ("rollTrigger");
		}else {
			if (verticalVal > 0) {
				resetTriggers();
				playerAnim.SetTrigger("runTrigger");

				if(Input.GetKeyDown (KeyCode.I)){
					resetTriggers();
					playerAnim.SetTrigger ("rollTrigger");
					return;
				}

				if(horizontalVal != 0) Spin();
			
			}else if(verticalVal < 0){
				//resetTriggers();
				//playerAnim.SetTrigger ("backTrigger");
			}else{
				resetTriggers();
				playerAnim.SetTrigger("idleTrigger");

				if(Input.GetKeyDown (KeyCode.I)){
					resetTriggers();
					playerAnim.SetTrigger ("rollTrigger");
					return;
				}


				if(horizontalVal != 0) Spin();
			}
		}


	}
	#endregion

	#region Metodos de Ayuda
	void resetTriggers(){
		playerAnim.ResetTrigger("runTrigger");
		playerAnim.ResetTrigger("idleTrigger");
		playerAnim.ResetTrigger ("attackTrigger");
		playerAnim.ResetTrigger ("rollTrigger");
	}

	void Spin(){
		//print ("Rotating");
		transform.Rotate (Vector3.up * horizontalVal * spinSpeed *Time.deltaTime, Space.World);
	}

	IEnumerator SwordAttack(){
		sword.collider.enabled = true;
		yield return new WaitForSeconds (0.5f);
		sword.collider.enabled = false;

	} 


	#endregion

	#region enumerators
	#endregion
}
