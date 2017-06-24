using UnityEngine;
using System.Collections;

public class DestroyBubble : MonoBehaviour {


	GameManager gm;

	// Use this for initialization
	void Start () {
		
		gm = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Destroy (other.gameObject);
			gm.fauls++;

	}
}
