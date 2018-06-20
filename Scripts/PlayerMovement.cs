using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public PlayerSanityManager sanity;
	public GhostControl ghostcontroller;

	Rigidbody2D rbody;
	Animator anim;

	public float speed;

	public int count;
	public Text countGem;
	public int maxCount;
	public bool useGem;
	public bool gemInUse;
	GameObject activateGemMessage;

	public GameObject[] ghosts;
	SpriteRenderer rend;

	private List<int> distances = new List<int> (); 
	public int minDistance; 

	AudioSource gemSound;

	public GameController gamecontrol;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		count = 0;
		useGem = false;
		gemInUse = false;
		maxCount = 5;
		activateGemMessage = GameObject.FindWithTag ("Gem Activated");
		activateGemMessage.SetActive (false);
		gemSound = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Gem"))
		{
			if (count<maxCount)
			{
			other.gameObject.SetActive(false);
			count = count + 1;
			}
		}

	}
		

	// Update is called once per frame
	void Update () {
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if(movement_vector != Vector2.zero){
			anim.SetBool("IsWalking",true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		}
		else{
			anim.SetBool ("IsWalking", false);
		}

		rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime*speed);

		if (Input.GetKeyDown (KeyCode.Q) && count > 0) 
		{
			if (!gemInUse) {
				gamecontrol.SpawnGem ();
				count -= 1;
				if (sanity.playerCurrentSanity < sanity.playerMaxSanity) {
					sanity.playerCurrentSanity += 10;
				}
				StartCoroutine (activateGem ());
			}
		}

		ghosts = GameObject.FindGameObjectsWithTag ("Ghost");

		foreach (GameObject ghost in ghosts) {
			float distance= Vector2.Distance (this.transform.position, ghost.transform.position);
			int intDistance = (int)distance;
			distances.Add (intDistance);
		}

		minDistance = distances.Min ();

		distances.Clear();
	}

	IEnumerator activateGem()
	{
		activateGemMessage.SetActive (true);
		gemSound.Play ();
		gemInUse = true;
		foreach (GameObject ghost in ghosts) {
			rend = ghost.gameObject.GetComponent<SpriteRenderer> ();
			rend.enabled = true;
		}
		yield return new WaitForSeconds(10);
		foreach (GameObject ghost in ghosts) {
			rend = ghost.gameObject.GetComponent<SpriteRenderer> ();
			rend.enabled = false;
		}
		gemInUse = false;

		activateGemMessage.SetActive (false);
	}
}
