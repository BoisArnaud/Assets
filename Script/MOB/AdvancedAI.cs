using UnityEngine;
using System.Collections;

public class AdvancedAI : MonoBehaviour {


	private float distance;

	public Transform target ;
	public float lookAtDistance;
	public float chaseRange;
	public float attackRange;
	public float moveSpeed ;
	public float damping ;
	public float attackRepeatTime ;

	public int damage ;

	private float attackTime ;

	public CharacterController controller ;
	public float gravity ;

	private Vector3 moveDirection ; 


	private Animation anim ;


	public float speedAnimationAttack ;
	public float speedAnimationRun ;


	// Use this for initialization
	void Start () {
		attackTime = Time.time ;
		anim = GetComponent<Animation> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		distance = Vector3.Distance (target.position, transform.position);

		if (distance <= lookAtDistance) {
			lookAt ();
		} 
		else {
			// rien pour le moment ;
		}

		if (distance <= attackRange) {
			attack();
		}
		else if (distance <= chaseRange) {
			chase();
		}


	}

	void lookAt(){
		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack(){
		if (Time.time > attackTime) {
			anim.Play("attack");
			anim["attack"].speed = speedAnimationAttack ;

		//	target.SendMessage("applyDamage", damage );
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void chase(){
		anim.Play ("run");
		anim ["run"].speed = speedAnimationRun; 

		moveDirection = transform.forward ;
		moveDirection *= moveSpeed ;

		moveDirection.y -= gravity * Time.deltaTime ;
		controller.Move (moveDirection * Time.deltaTime);

	}



}
