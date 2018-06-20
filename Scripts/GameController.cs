using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private bool restart;

	public Text gameOverText;
	public Text restartText;

	public PlayerSanityManager sanity;
	public MyTimer timer;

	public PlayerMovement player;
	public GameObject gem;

	public int xMin;
	public int xMax;
	public int yMin;
	public int yMax;

	// Use this for initialization
	void Start () {
		restart = false;
		restartText.enabled = false;
		gameOverText.enabled = false;
		Random.seed = System.DateTime.Now.Millisecond;
	}
	
	// Update is called once per frame
	void Update () {
		GameOver ();
		if (restart) {
			restartText.enabled = true;
			restartText.text = "Restart? Y/N";
			if (Input.GetKeyDown (KeyCode.Y)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			} 
			else if (Input.GetKeyDown (KeyCode.N)) {
				Application.Quit();
			}

		}
			
	}
	public void GameOver(){
		if (sanity.playerCurrentSanity <= 0) {
			restart = true;
			gameOverText.text = "Game Over";
			gameOverText.enabled = true;
		}
		else if (timer.countdown <=0) {
			restart = true;
			gameOverText.text = "Congratulations! You've Survived!";
			gameOverText.enabled = true;
		}
	}
	public void SpawnGem(){
		Vector2 newPos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		GameObject newGem = Instantiate (gem, newPos, Quaternion.identity) as GameObject;
	}
		
}
