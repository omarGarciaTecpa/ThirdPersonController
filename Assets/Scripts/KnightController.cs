using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour {
	#region Variables
	float horizontalVal, verticalVal;
	Animator playerAnim;
	public float spinSpeed = 50;
	#endregion

	#region Metodos de Unity
	// Use this for initialization
	void Start () {
		playerAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		verticalVal = Input.GetAxis ("Vertical");
		horizontalVal = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown (KeyCode.J)) {
			resetTriggers ();
			playerAnim.SetTrigger ("attackTrigger");
		} else {
			if (verticalVal > 0) {
				resetTriggers();
				playerAnim.SetTrigger("runTrigger");
				if(horizontalVal != 0) Spin();
			}else{
				resetTriggers();
				playerAnim.SetTrigger("idleTrigger");
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
	}

	void Spin(){
		print ("Rotating");
		transform.Rotate (Vector3.up * horizontalVal * spinSpeed *Time.deltaTime, Space.World);
	}
	#endregion

	#region enumerators
	#endregion
}
