using UnityEngine;
using System.Collections;

public class Merchant : MonoBehaviour {


	public string shopName ;
	public string shopDesc ;

	private bool showGUI ;
	private PlayerStats ps ;

	public Transform[] items ;
	public string[] itemsName;
	public int[] itemsPrice ;
	public Transform itemSpawnner ;

	// Use this for initialization
	void Start () {
	
	}
	

	void OnTriggerEnter(Collider hit){
		Debug.Log ("enter");
		if (hit.tag.Equals("Player")) {
			Debug.Log ("open mag");
			showGUI = true ;
			ps = hit .GetComponent<PlayerStats>() ;
		}

	}

	
	void OnTriggerExit(Collider hit){
		if (hit.tag.Equals("Player")) {
			showGUI = false ;
		}
		
	}

	void OnGUI(){
		if (showGUI) {
			Cursor.lockState = CursorLockMode.Confined;

			GUI.BeginGroup( new Rect(Screen.width/2 - 165f , Screen.height/2 - 75 ,340,150 ) );
			GUI.Box( new Rect(0,0,340,150),shopName );
			GUI.Label( new Rect(10,20,320,300),shopDesc);

			int posX = 5 ; 
			int posY = 60;
			int cpt  = 0 ;


			for(int i = 0 ; i < items.Length ; i++ ){
				if(GUI.Button( new Rect(posX,posY,100,30), itemsName[i] + "("+itemsPrice[i]+"gold)")){
					if(ps.getMoney() >= itemsPrice[i]){
						ps.setMoney(ps.getMoney() - itemsPrice[i]);
						Instantiate (items[i],itemSpawnner.position, Quaternion.identity ); // changer les positions vector 3
									
					}
				}
				posX += 115 ;
				cpt ++ ;
				if(cpt >= 3){
					posX = 5 ;
					posY += 40 ;
					cpt = 0 ;
				}

			}

			GUI.EndGroup();


		}

	}


}
