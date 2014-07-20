using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public Transform spawnPoint;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// set new spawnpoint
			spawnPoint.position = new Vector3(transform.position.x, spawnPoint.position.y, spawnPoint.position.z);
			Destroy (gameObject);
		}
	}
}
