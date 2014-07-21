using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			audio.Play();
			transform.parent.gameObject.GetComponent<Enemy>().m_bStomp = true;
		}
	}
}
