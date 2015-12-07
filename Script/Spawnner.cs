using UnityEngine;
using System.Collections;

public class Spawnner : MonoBehaviour {

	public  GameObject ennemy ;
	public GameObject[] ennemyList ;
	public int ennemyNumber ;
	public int rangeX ;
	public int rangeZ ;
	public float timeTospawn ; 
	public Transform pnjQuest ;


	private bool startToSpawn ;
	private int ennemySpawnned ;

	private float timer ;
	
	void Start(){
		startToSpawn = false ;
		ennemyList = new GameObject[ennemyNumber];
	}
	
	void Update(){
		if(startToSpawn &&  ennemySpawnned < ennemyNumber && Time.realtimeSinceStartup  - timer > timeTospawn  ){
			float x = Random.Range(this.transform.position.x - rangeX,this.transform.position.x + rangeX);
			float z = Random.Range(this.transform.position.z - rangeZ,this.transform.position.z + rangeZ);
			ennemyList[ennemySpawnned] = Instantiate(ennemy);
			ennemyList[ennemySpawnned].transform.localPosition = new Vector3(x,this.transform.position.y, z);
			ennemyList[ennemySpawnned].GetComponent<EnemyHealth>().setQuest(pnjQuest.GetComponent<Quest>());
			ennemySpawnned++ ;
			timer = Time.realtimeSinceStartup ;
		}	
		checkEnemmyNumberDead();
		
	}
	
	
	void checkEnemmyNumberDead(){
		int val = 0 ;
		for(int i=1 ; i<ennemyList.Length ; i++){
			if(ennemyList[i] == null){
				val++;
			}
		}
		ennemySpawnned =  ennemyNumber - val ;
	}
	
	
	
	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Player"){
			startToSpawn = true ;
		}
	}
	
	void OnTriggerExit(Collider hit){
		if(hit.gameObject.tag == "Player"){
			startToSpawn = false ;
		}
	}
}
