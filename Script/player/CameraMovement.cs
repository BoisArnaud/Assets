using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform targetCamera ;
	private Vector3 to ;
	private Transform targetCharacter ;

	// Use this for initialization
	void Start () {
		targetCamera = GameObject.Find ("Target").transform;
		targetCharacter = GameObject.Find ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = Vector3.Lerp (transform.position, targetCamera.position ,0.1f);
		to = targetCharacter.transform.position - transform.position ;

		transform.rotation = Quaternion.Slerp (transform.rotation,Quaternion.LookRotation(to), 0.1f);



	}
}
