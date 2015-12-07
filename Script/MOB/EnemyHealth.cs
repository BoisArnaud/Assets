using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health ;
	public int healthMax ;
	public float timeToStayAfterDeath ;
	public int exp ;
	public Quest quest ; 
	public string ennemyname ;

	private AdvancedAI ia ;
	private CharacterController characterController ;

	private Animation anim ;
	private float speedAnimationDie = 1 ;
	private bool isdead ;
	private float hourOfDeath ;

	private GameObject player ;
	private PlayerStats playerStats ;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		isdead = false;
		hourOfDeath = 0.0f;
		ia = GetComponent<AdvancedAI> ();
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isdead && timeToStayAfterDeath + hourOfDeath <= Time.realtimeSinceStartup) {
			dead ();
		}
	}

	void OnTriggerExit(Collider hit){	
		if (hit.transform.tag == "WeaponPlayer") {
			player = GameObject.FindGameObjectWithTag("Player") ; // recupere le parent le plus haut dans la hierrachie
			playerStats = player.GetComponent<PlayerStats>() ;
			health -= playerStats.getAttack() ;
			anim.Play ("gethit");

			if (health <= 0) {
				ia.enabled = false;
				characterController.enabled = false ;
				anim.Play ("die");
				anim ["die"].speed = speedAnimationDie; 
				isdead = true;
				hourOfDeath = Time.realtimeSinceStartup;
				giveXp();

				if(quest != null ){
					quest.SendMessage("oneEnnemyDie",getEnnemyname());
				} 
			}
		}

	}

	void dead(){
		Destroy (gameObject);
	}

	void giveXp(){
		playerStats.addExp(exp);
	}


	public string getEnnemyname(){
		return ennemyname;
	}

	public void setQuest(Quest quest){
		this.quest = quest ;
	}


}
