using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	public GameObject m_player;
	public Transform m_spawnPoint;

	// Use this for initialization
	void Start () 
	{
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
		GameObject newPlayer = Instantiate(m_player, m_spawnPoint.position, Quaternion.identity) as GameObject;
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
