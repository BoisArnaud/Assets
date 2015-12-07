using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

	public int currentWeapon ;
	public int maxWeapon ;

	void Awake(){
		SelectWeapon (0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			currentWeapon ++;
		} 
		else if(Input.GetAxis ("Mouse ScrollWheel") < 0) {
			currentWeapon --;
		}
		if (currentWeapon > maxWeapon) {
			currentWeapon = 0;
		} else if (currentWeapon < 0) {
			currentWeapon = maxWeapon ;
		}
		SelectWeapon (currentWeapon);
	}

	void SelectWeapon(int index){
		for(int i = 0 ; i < transform.childCount ; i++){
			if ( i == index ){
				transform.GetChild(i).gameObject.SetActive(true);
			}
			else{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}

}
