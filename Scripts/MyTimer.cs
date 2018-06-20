using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour {

	public float countdown;
	private Text timerText;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		timerText.text = countdown.ToString ("f0");
	}
}
