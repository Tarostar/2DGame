using UnityEngine;
using System.Collections;

public class FutureDoor : MonoBehaviour {

	public GameObject openDoor;
	public string nextLevel;

	// Use this for initialization
	void Start () 
	{
		print ("start");
		openDoor.renderer.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print ("trigger enter");

		audio.Play();
		openDoor.renderer.enabled = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		audio.Play();
		openDoor.renderer.enabled = false;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
		{
			Application.LoadLevel(nextLevel);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		print ("OnCollision");
	}

}
