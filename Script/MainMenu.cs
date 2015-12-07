using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private bool quality ;
	private bool loadGame;
	private bool newGame;
	public  string  startLevel;

	public GameObject player ;
	public GameObject inventory ;

	// Use this for initialization
	void Start () {
		quality = false;
		loadGame = false;
		newGame = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Nouvelle Partie")) {
			newGame = true ;
		}
		if (newGame) {
			player.SetActive(true) ;
			inventory.SetActive(true);
			player.GetComponent<PlayerStats>().initPlayer() ;
			Application.LoadLevel(startLevel);
			newGame = false ;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "Charger partie")) {
			loadGame = true ;
		}
		if (loadGame) {
			Application.LoadLevel(PlayerPrefs.GetInt("level"));
			player.SetActive(true) ;
			inventory.SetActive(true);
			Inventory MainInventory = player.GetComponent<PlayerInventory> ().getMainInventory ();
			int slotQuantity =16 ;
			for(int i = 0 ; i < slotQuantity ; i++){
				int id = PlayerPrefs.GetInt("inv_item_"+i) ;
				if(id != 0 ) {
					MainInventory.addItemToInventory(id);
				}
			}
			player.GetComponent<PlayerStats>().loadPlayer() ;		
			loadGame = false ;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 , 200, 50), "Régler les qualitées graphiques")) {
			if (!quality) {
				quality = true;
			} else {
				quality = false;
			}
		}

		if (quality) {
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 150, 250, 50), "Très Basse")) {
				QualitySettings.SetQualityLevel(0) ;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 100, 250, 50), "Basse")) {
				QualitySettings.SetQualityLevel(1) ;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 50, 250, 50), "Normale")) {
				QualitySettings.SetQualityLevel(2) ;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 , 250, 50), "Bonne")) {
				QualitySettings.SetQualityLevel(3);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 + 50, 250, 50), "Très bonne")) {
				QualitySettings.SetQualityLevel(4) ;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height / 2 + 100, 250, 50), "Excellente")) {
				QualitySettings.SetQualityLevel(5) ;
			}

			if(Input.GetKeyDown("escape")){
				quality = false ;
			}
		}

		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50 , 200, 50), "Quitter")) {
			Application.Quit();
		}

	}


}
