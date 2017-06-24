using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


	public Text bestscoretxt;
	public Text endscoretxt;
	public Text ingametxt;
	public GameObject PauseMenu;
	public int fauls;
	int mode=3;
	public int score;
	int a,oldscore;
	float spawnTimer,globalTimer,difficultyTimer,difficulty=0.5f;
	Spot[] spawnSpots;
	Spot spawnSpot,lastSpot;
	Pop bubbleOb;
	Pop[] bubbles;
	public GameObject bubble;
	public GameObject bubbleSmall;
	public GameObject bubbleBig;
	public GameObject InGameScore;
	public AudioSource audioS;


	void Start () {
		audioS = gameObject.GetComponent<AudioSource> ();


		bestscoretxt.text = PlayerPrefs.GetInt ("score").ToString();

		oldscore = PlayerPrefs.GetInt ("score");
			
		spawnSpots = Spot.FindObjectsOfType <Spot>();

			foreach(Spot spawnSpot in spawnSpots){
			a++;

		}

	}


	void Update(){

		ingametxt.text = score.ToString ();


		globalTimer += Time.deltaTime;
		spawnTimer += Time.deltaTime;

		if (globalTimer < 30f) {
			if (spawnTimer > 0.7f) {
				SpawnBubble ();
				spawnTimer = 0;
			}
		}

		if (globalTimer > 30f && globalTimer < 70f) {

			if (spawnTimer > 0.5f) {
				SpawnBubble ();
				spawnTimer = 0;
			}

		}

		if (globalTimer > 71f) {
			difficultyTimer += Time.deltaTime;
			if (difficultyTimer > 20f) {
				difficultyTimer = 0;
				if(difficulty > 0.2f) 
				difficulty -= 0.1f;

			} 
			if (spawnTimer > difficulty) {
				SpawnBubble ();
				spawnTimer = 0;
			}

		}




		Debug.Log (globalTimer);




		if (fauls == mode) {
			End ();
		}

	}

	void SpawnBubble(){
		Spot spawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
		//Debug.Log (spawnSpot.name);
		if (lastSpot != spawnSpot) {
			int size = Random.Range (0, 7);
			if (size >= 0 && size < 3) {
				Instantiate (bubbleBig, spawnSpot.transform.position, spawnSpot.transform.rotation);
			} else if (size >= 3 && size < 6) {
				Instantiate (bubble, spawnSpot.transform.position, spawnSpot.transform.rotation);

			} else if (size > 6) {
				Instantiate (bubbleSmall, spawnSpot.transform.position, spawnSpot.transform.rotation);

			}
			lastSpot = spawnSpot;

		} else {
			return;
		}

	
	}

	void End (){
		//Time.timeScale = 0;
		bubbles = Pop.FindObjectsOfType <Pop>();
		foreach(Pop bubbleOb in bubbles)
			Destroy (bubbleOb.gameObject);

		endscoretxt.text = score.ToString ();
		InGameScore.SetActive (false);
		PauseMenu.SetActive (true);


	}

	public void Restart(){
		if (oldscore > score) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			PlayerPrefs.SetInt ("score", score);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}	

	void OnApplicationQuit(){
		if (oldscore > score) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			PlayerPrefs.SetInt ("score", score);
		}
	}

	public void ExitGame(){
		if (oldscore > score) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			PlayerPrefs.SetInt ("score", score);
		}

		Application.Quit();
	}
}
