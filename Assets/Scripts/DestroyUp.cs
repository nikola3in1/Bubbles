using UnityEngine;
using System.Collections;

public class DestroyUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision other){
		Destroy (other.gameObject);
	

	}
}
