using UnityEngine;
using System.Collections;

public class FutureDoor : MonoBehaviour {

	public GameObject openDoor;
	public string nextLevel;

	// Use this for initialization
	void Start () {
		openDoor.renderer.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			audio.Play();
			openDoor.renderer.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			audio.Play();
			openDoor.renderer.enabled = false;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && (Input.GetKeyDown("up") || Input.GetKeyDown("w")))
		{
			Application.LoadLevel(nextLevel);
		}
	}
}
