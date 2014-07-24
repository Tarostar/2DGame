using UnityEngine;
using System.Collections;

public class GardenDoor : MonoBehaviour {

	public GameObject openDoor;
	public string nextLevel;

	// since OnTriggerStay2D never stops firing, we must track it ourselves
	bool bAtDoor = false;

	void Start () 
	{
		openDoor.renderer.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			audio.Play();
			openDoor.renderer.enabled = true;
			bAtDoor = true; 
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			audio.Play();
			openDoor.renderer.enabled = false;
			bAtDoor = false; 
		}
	}

	void Update()
	{
		if (bAtDoor && (Input.GetKeyDown("up") || Input.GetKeyDown("w")) &&
		     GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation == false)
		{
			Application.LoadLevel(nextLevel);
		}
	}
}
