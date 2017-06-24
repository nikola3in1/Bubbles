using UnityEngine;
using System.Collections;

public class Pop : MonoBehaviour {
	float lifespawn=10f;
	GameManager gm;
	SphereCollider sCol,oCol;
	Rigidbody rb;



	// Use this for initialization
	void Start () {
		gm = FindObjectOfType <GameManager> ();
		sCol = gameObject.GetComponent<SphereCollider> ();
		rb = gameObject.GetComponent<Rigidbody> ();

	}
	

	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)) {
			gm.score++;
			gm.audioS.Play ();
			Destroy (gameObject);
		}
	}
	void FixedUpdate(){
		//Debug.Log (rb.velocity);

		if (rb.velocity.magnitude > 2f) {
			Destroy (gameObject);
		}
	}
	void Update(){
		lifespawn -= Time.deltaTime;
		if (lifespawn < 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		oCol = col.gameObject.GetComponent<SphereCollider> ();
		if (col.gameObject.tag == "Bubble")
			Physics.IgnoreCollision (sCol,oCol);
	}
}
