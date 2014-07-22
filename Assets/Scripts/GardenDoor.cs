using UnityEngine;
using System.Collections;

public class GardenDoor : MonoBehaviour {

	public GameObject openDoor;
	public string nextLevel;

	void Start () 
	{
		openDoor.renderer.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			audio.Play();
			openDoor.renderer.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			audio.Play();
			openDoor.renderer.enabled = false;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && (Input.GetKeyDown("up") || Input.GetKeyDown("w")) &&
		    GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			Application.LoadLevel(nextLevel);
		}
	}
}
