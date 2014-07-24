using UnityEngine;
using System.Collections;

public class FutureDoor : MonoBehaviour {

	public GameObject openDoor;
	public string nextLevel;

	// since OnTriggerStay2D never stops firing, we must track it ourselves
	bool bAtDoor = false;

	// Use this for initialization
	void Start () 
	{
		openDoor.renderer.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// IMPORTANT (bug?): note if animator is in same object as collider for player then this will keep triggering

		bAtDoor = true;

		audio.Play();
		openDoor.renderer.enabled = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		audio.Play();
		openDoor.renderer.enabled = false;

		bAtDoor = false; 
	}

	// IMPORTANT (bug!): this seems to be broken in Unity - just keeps firing forever even when leaving area
	/*void OnTriggerStay2D(Collider2D other)
	{
		print ("STAY");


		if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
		{
			print ("GO");
			Application.LoadLevel(nextLevel);
		}
	}*/

	void Update()
	{
		if (bAtDoor && (Input.GetKeyDown("up") || Input.GetKeyDown("w")))
		{
			Application.LoadLevel(nextLevel);
		}
	}

}
