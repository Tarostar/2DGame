using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	public Transform m_spawnPoint;

	// Use this for initialization
	void Start () 
	{
		float x = PlayerPrefs.GetFloat ("spawnX");
		float y = PlayerPrefs.GetFloat ("spawnY");
		float z = PlayerPrefs.GetFloat ("spawnZ");

		// check if we have a stored spawn point
		if (Application.loadedLevelName == PlayerPrefs.GetString("Level") &&
		    (x != 0 || y != 0 || z != 0))
		{
			// set spawn point
			m_spawnPoint.position = new Vector3(x, y, z);
		}
		else if (Application.loadedLevelName == "2DGame" &&
		         PlayerPrefs.GetString("Level") == "SecretLab")
		{
			// respawn at door
			GameObject target = GameObject.Find("FutureDoor");
			m_spawnPoint.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

		}

		// instantiate first player
		CreateNewPlayer();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy (other.gameObject);

			CreateNewPlayer();
		}
	}

	private void CreateNewPlayer()
	{
		GameObject newPlayer = Instantiate(Resources.Load("Player"), m_spawnPoint.position, Quaternion.identity) as GameObject;
		if (newPlayer == null)
		{
			// TODO: better error handling
			print ("no new player object!");
			return;
		}
		
		SmoothFollow2 followScript = Camera.main.GetComponent<SmoothFollow2>();
		
		followScript.target = newPlayer.transform;
	}
}
