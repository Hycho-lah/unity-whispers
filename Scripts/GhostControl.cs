using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour {
	public float moveSpeed;
	public Rigidbody2D myRigidbody; 
	private bool moving;
	public float timeBetweenMove;
	public float timeToMove;
	private Vector3 moveDirection;
	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;

	private bool chase;
	public Transform player;
	private float playerDistance;
	public float maxDistance;
	public float chaseSpeed;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCounter = Random.Range (timeBetweenMove *0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove = 0.75f, timeBetweenMove * 1.25f);

	}

	// Update is called once per frame
	void Update () {
		playerDistance = Vector2.Distance (player.position, transform.position);

		if (playerDistance<maxDistance)
		{
			lookAtPlayer ();
		}
		else if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection; 
			if (timeToMoveCounter < 0f) 
			{
				moving = false;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove *0.75f, timeBetweenMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
				timeToMoveCounter = Random.Range (timeToMove = 0.75f, timeBetweenMove * 1.25f);
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f), 0f);
			}
		}
	}

	void lookAtPlayer(){
		transform.position = Vector2.MoveTowards (transform.position, player.position, chaseSpeed * Time.deltaTime);
	}
}
