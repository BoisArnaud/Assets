using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
		
	public 	int damage ;
	private int initdamage ;
	

	void Start(){

	}

	void Awake(){
		initdamage = damage;
	}

	// Update is called once per frame
	void Update () {
	}

	public void addDamage(int damage){
		this.damage += damage ;
	}

	public void initDamage(){
		damage = initdamage;
	}


}
