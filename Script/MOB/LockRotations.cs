using UnityEngine;
using System.Collections;

public class LockRotations : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
