using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour {

    public PlayerMovement player;

    
	SpriteRenderer rend;
    // Use this for initialization
	void Start () {
		rend = this.gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = !rend.enabled;

    }

	// Update is called once per frame
	void Update ()
    {
	}
		

}
