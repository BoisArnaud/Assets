using UnityEngine;
using System.Collections;

public class Tp : MonoBehaviour {

	public string sceneName ;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel(sceneName);
		}
	}

}
