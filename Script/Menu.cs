using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	
	private bool showGUI  ;
	private bool quality  ;

	private PlayerStats ps ;

	// Use this for initialization
	void Start () {
		showGUI = false ;
		quality = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			showGUI = !showGUI ;
			PauseGame(showGUI);
		}


	}
	
	void OnGUI(){
		if (showGUI) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Continuer")) {
				showGUI = !showGUI ;
				PauseGame(showGUI);
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "Sauvegarder")) {
				saveGame();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 0, 200, 50), "Régler les qualitées graphiques")) {
				if (!quality) {
					quality = true;
				} else {
					quality = false;
				}
			}
		
			if (quality) {
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 150, 250, 50), "Très Basse")) {
					QualitySettings.SetQualityLevel (0);
				}
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 100, 250, 50), "Basse")) {
					QualitySettings.SetQualityLevel (1);
				}
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 50, 250, 50), "Normale")) {
					QualitySettings.SetQualityLevel (2);
				}
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2, 250, 50), "Bonne")) {
					QualitySettings.SetQualityLevel (3);
				}
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 + 50, 250, 50), "Très bonne")) {
					QualitySettings.SetQualityLevel (4);
				}
				if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 + 100, 250, 50), "Excellente")) {
					QualitySettings.SetQualityLevel (5);
				}
			
				if (Input.GetKeyDown ("escape")) {
					quality = false;
				}
			}
		
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50), "Quitter")) {
				Application.Quit ();
			}
		
		}
	}

	//This function is called from the InventoryDisplay and Character script.
	public void PauseGame (bool pauseIt )
	{
			if (pauseIt == true)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Time.timeScale = 0.0f;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Confined;
				Time.timeScale = 1.0f;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
			}



	}


	void saveGame(){
		Debug.Log ("sauvegarde ...");
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Debug.Log ("recuperation player ...");

		ps = player.GetComponent<PlayerStats> ();
		Debug.Log (ps);

		Debug.Log ("sauvegarde de l'inventaire...");
		Debug.Log ("recuperation de la liste d'item dans l'inventaire...");
		List<Item> listItemInInv = ps.GetComponent<PlayerInventory> ().getMainInventory ().getItemsInInventory();
		Debug.Log ("recuperation des Id d'item dans l'inventaire...");
		List<int> idItem = new List<int>();
		for (int i = 0; i < listItemInInv.Count; i++) {
			idItem.Add(listItemInInv[i].getIdItem()) ;
		}
		Debug.Log ("sauvegarde des Id d'item dans le playersPrefs...");
		for (int i = 0; i < 16; i++) {
			PlayerPrefs.SetInt("inv_item_"+i,0) ;
		}
		for (int i = 0; i < idItem.Count; i++) {
			PlayerPrefs.SetInt("inv_item_"+i,idItem[i]) ;
		}

		Debug.Log ("sauvegarde des caractéristiques...");



		PlayerPrefs.SetInt("money",ps.getMoney()) ;
		PlayerPrefs.SetInt("exp",ps.getExp() ) ;
		PlayerPrefs.SetInt("level", ps.getLevel()) ;

		// sauvegarde des caractéristiques ;
		PlayerPrefs.SetInt("force", ps.getForce()) ;
		PlayerPrefs.SetInt("endurance" , ps.getEndurance()) ;
		PlayerPrefs.SetInt("intelligence", ps.getIntelligence() ) ;
		PlayerPrefs.SetInt("agilite", ps.getAgilite()) ;
		PlayerPrefs.SetInt("charisme", ps.getCharisme()) ;

		PlayerPrefs.SetInt ("level", Application.loadedLevel);
		Debug.Log ("sauvegarde terminé !");

	}

	
}
