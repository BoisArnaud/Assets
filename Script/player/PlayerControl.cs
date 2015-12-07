using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public bool weapon ;
	public bool canSwing ;
	private Animation anim;
	public float speedAnimation ;
	public float defaultSwingTimer ;
	private float swingTimer ;
	public bool isSwinging ;


	// Use this for initialization
	void Start () {
		anim= GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
	


		if (weapon == true && canSwing == true) {
			if(Input.GetMouseButtonDown(0)){
				GetComponent<MeshCollider>().enabled = true ;
				anim.Play("attack_basic");
				anim["attack_basic"].speed = speedAnimation ;

				isSwinging = true ;
				canSwing = false ;
			}


	


		} 

		if (canSwing == false) {
			swingTimer -= Time.deltaTime ;
		}

		if (swingTimer <= 0) {
			GetComponent<MeshCollider>().enabled = false ;
			swingTimer = defaultSwingTimer ;
			canSwing = true ;
			isSwinging = false ;
		}

	}
}
