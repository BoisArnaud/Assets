using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	private bool showGUI ;
	private bool questAccepted ;
	public Texture background ;


	public string questTitle ;
	public string questDescription ;

	public int ennemyKilled ;
	public GameObject[] ennemy ;

	public int questXp ;
	public int questMoney ;

	private PlayerStats playerStats ;


	// Use this for initialization
	void Start () {
		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats>();
		showGUI = false ;
		questAccepted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ennemyKilled <= 0 && questAccepted) {
			GetComponent<Quest>().enabled = false ;
			playerStats.addExp(questXp);
			playerStats.addMoney(questMoney);
		}
	}

	void OnGUI(){
		if (showGUI) {
			GUI.BeginGroup(new Rect(Screen.width/2 - 150 , Screen.height/4 - 75 , 600 , 300 ),new GUIContent(background));
			GUI.Label(new Rect(180,60,400,300), questTitle);
			GUI.Label(new Rect(40,80,580,300), questDescription );
			if(GUI.Button(new Rect(30,230,80,50), "Accepter" )){
				questAccepted = true ;
				showGUI = false ;
			}
			if(GUI.Button(new Rect(330,230,80,50), "Refuser" )){
				questAccepted = false ;
				showGUI = false ;
			}

			GUI.EndGroup();

		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Player") {
			showGUI = true ;
		}
	}


	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Player") {
			showGUI = false ;
		}
	}

	void oneEnnemyDie(string name){
		if (questAccepted) {
			for (int i = 0; i < this.ennemy.Length; i++) {
				if (this.ennemy [i] != null) {
					if (name.Equals (this.ennemy [i].GetComponent<EnemyHealth> ().getEnnemyname ())) {
						ennemyKilled --;
						i = this.ennemy.Length;
					}
				}
			}
		}
	}

}
