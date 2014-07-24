using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public Transform spawnPoint;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			print ("spawnPoint set");
			// set new spawnpoint
			spawnPoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			// store spawn point between game sessions and levels

			PlayerPrefs.SetFloat ("spawnX", spawnPoint.position.x);
			PlayerPrefs.SetFloat ("spawnY", spawnPoint.position.y);
			PlayerPrefs.SetFloat ("spawnZ", spawnPoint.position.z);
			PlayerPrefs.SetString("Level", Application.loadedLevelName);

			// optionally we can destroy checkpoint
			// Destroy (gameObject);
		}
	}
}
