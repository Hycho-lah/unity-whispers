using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;
	public GameObject activateSanityMessage;
	SpriteRenderer rend;
	private bool ghostContact;

	AudioSource spook;

	// Use this for initialization
	void Start () {
		spook = GetComponent<AudioSource> ();

		activateSanityMessage.SetActive (false);

		rend = GetComponent<SpriteRenderer> ();

		ghostContact = false;
	}

	// Update is called once per frame
	void Update () {
		if (ghostContact) {
			StartCoroutine (ghostVisible ());	
		}
	}

void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			spook.Play ();
			ghostContact = true;
			Debug.Log (ghostContact);
			other.gameObject.GetComponent<PlayerSanityManager> ().HurtPlayer (damageToGive);
		}
	}

	IEnumerator ghostVisible()
	{
		activateSanityMessage.SetActive (true);
		rend.enabled = true;
		yield return new WaitForSeconds (2);
		rend.enabled = false;
		activateSanityMessage.SetActive (false);

		ghostContact = false;
	}
}
