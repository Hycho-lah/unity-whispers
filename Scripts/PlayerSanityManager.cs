using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanityManager : MonoBehaviour {

	public int playerMaxSanity;
	public int playerCurrentSanity;
	// Use this for initialization
	void Start () {
		playerCurrentSanity = playerMaxSanity;

	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentSanity <= 0) {
			gameObject.SetActive (false);
		}
	}
	public void HurtPlayer(int damageToGive)
	{
		playerCurrentSanity -= damageToGive;
	}	

	public void SetMaxSanity()
	{
		playerCurrentSanity = playerMaxSanity;
	}
}
