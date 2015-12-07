using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {


	public float speed ;
	public float speedRotate ;
	public float gravity ;
	public float speedRun ;
	public float jumpSpeed ;
	public float jumpDuration;
	public GameObject weapon ;
	public float timeAnimBasicAttackSword ; 
	private float timeSkill ; 


	private CharacterController controller ;
	private Vector3 moveDirection ;
	private float deltaTime ;
	public bool walk , run , jump , attackBasic;

	private float inputH ; 
	private float inputV ; 

	private Animator anim ;

	private bool isJumping;
	private float timejumping = 0f;
	private float timeStartjumping = 0f;
	public float timer ;

//	private Weapon weaponScript ;
	public PlayerStats playerStats ;


	// Use this for initialization
	void Start () {
	
		controller = GetComponent<CharacterController>();
		anim  = GameObject.Find ("Model").GetComponent<Animator> ();
//		weaponScript = GameObject.FindGameObjectWithTag("WeaponPlayer").GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
	
		// Cadence du temps
		deltaTime = Time.deltaTime ;

		// deinission des input
		inputV = Input.GetAxis ("Vertical");
		inputH = Input.GetAxis ("Horizontal");

		// affectation des input à l'animator 
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool ("run", run);
		anim.SetBool ("jump", jump); 
	//	anim.SetBool ("attackBasic", attackBasic);
		
		// Deplacements Haut/bas

		if (Input.GetKey (KeyCode.LeftShift)) {
			moveDirection = new Vector3(0.0f,0.0f,Input.GetAxis("Vertical") * speedRun );
			run = true;
		} else {
			moveDirection = new Vector3(0.0f,0.0f,Input.GetAxis("Vertical") * speed );
			run = false ;
		}





		// changer sur l'axe local
		moveDirection = transform.TransformDirection (moveDirection);	

		// Rotation du personnage 
		transform.Rotate(new Vector3(0.0f,Input.GetAxis("Horizontal") * speedRotate * deltaTime,0.0f ));

		// Gravity
		if (!controller.isGrounded) {
			moveDirection.y -= gravity;
		}




		// Saut du personnage 
		if (Input.GetKey (KeyCode.Space) && timejumping - timeStartjumping <= jumpDuration) {

			if(!isJumping){
				timeStartjumping = Time.realtimeSinceStartup ;
				isJumping = true ;
			}
			else{
				timejumping = Time.realtimeSinceStartup ;
				moveDirection.y += jumpSpeed;
			}
			jump = true;

		} else {
			jump = false;
		}

		if (controller.isGrounded) {
			isJumping = false ;
			timejumping = 0f ;
			timeStartjumping = 0f ;
		}

		// Deplacements du Character Controller

		controller.Move (moveDirection * deltaTime);


		if (Input.GetMouseButtonDown (0)) {
			if(!attackBasic){
				timer = Time.realtimeSinceStartup ;
				attackBasic = true ;	
				weapon.GetComponent<MeshCollider>().enabled = true ;
				anim.Play("attackBasic");
			}
		
		} else {
			if(Time.realtimeSinceStartup  - timer > timeAnimBasicAttackSword ){
				weapon.GetComponent<MeshCollider>().enabled = false ;
				attackBasic = false ;	
				timer = 0f ;
			}

		}

	/*	if (Input.GetKey (KeyCode.Alpha1)) {
			if(!attackBasic){
				Skill skill = playerStats.getSkill(0) ;
				timeSkill = skill.getAnimTime();
				weaponScript.addDamage(skill.getDamageSkill());
				attackBasic = true ;
				timer = Time.realtimeSinceStartup ;
				weapon.GetComponent<BoxCollider>().enabled = true ;
				anim.Play(skill.getAnim());
			}

		} else {
			if(Time.realtimeSinceStartup  - timer > timeSkill ){
				weapon.GetComponent<BoxCollider>().enabled = false ;
				weaponScript.initDamage();
				attackBasic = false ;	
				timer = 0f ;
			}

		}*/



	}




}
