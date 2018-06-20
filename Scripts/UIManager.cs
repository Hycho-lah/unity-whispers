using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider sanityBar;
	public Text SPText;
	public PlayerSanityManager playerSanity;

	public Slider gemBar;
	public Text countGem;
	public PlayerMovement player;

	public Slider ghostDetector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sanityBar.maxValue = playerSanity.playerMaxSanity;
		sanityBar.value = playerSanity.playerCurrentSanity;
		SPText.text = "Sanity: " + playerSanity.playerCurrentSanity + "/" + playerSanity.playerMaxSanity;

		gemBar.maxValue = 5;
		gemBar.value = player.count;
		countGem.text = "Gems:" + player.count.ToString () +"/5";

		ghostDetector.value = player.minDistance;
	}
}
