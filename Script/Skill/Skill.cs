using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	public string nomAnimation ;
	public int    animationTime ;
	public int    damageSkillMin ;
	public int    damageSkillMax ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getAnim(){
		return nomAnimation;
	}

	public int getAnimTime(){
		return animationTime;
	}

	public int getDamageSkill(){
		return Random.Range(damageSkillMin,damageSkillMax);
	}


}
