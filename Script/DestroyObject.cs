using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	public int health ;
	public int idItem ;
	public AudioClip hitSound ;
	public AudioClip breakSound ;

	public GameObject[] theObjects ;
	public Transform objectSpawnner ;

	public GameObject soundObject ;

	static ItemDataBaseList inventoryItemList;


	void OnTriggerEnter(Collider hit ){
		if (hit.gameObject.tag.Equals ("WeaponPlayer")) {
			soundObject.GetComponent<AudioSource>().PlayOneShot(hitSound);
			health -= hit.transform.root.FindChild("Player").GetComponent<PlayerStats>().getAttack(); 
			if(health <= 0 ){
				itDestroy();
			}
		}


	}

	void itDestroy(){
		for (int i = 0; i < theObjects.Length; i++) {
			inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
			GameObject randomLootItem = (GameObject)Instantiate(theObjects[i],objectSpawnner.position,Quaternion.identity );
			PickUpItem item = randomLootItem.AddComponent<PickUpItem>();
			item.item = inventoryItemList.getItemByID(idItem);

		}
		soundObject.GetComponent<AudioSource> ().PlayOneShot (breakSound);
		Destroy (gameObject);
	}
}
