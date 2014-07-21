using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject m_player;
	public Transform m_spawnPoint;
	public bool m_bStomp = false;

	// Use this for initialization
	private void OnTriggerEnter(Collider other)
	{
		if (!m_bStomp && other.tag == "Player")
		{
			// GameObject.FindWithTag("MainCamera")
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
	
	// Update is called once per frame
	void Update () {
		if (m_bStomp)
		{
			transform.Translate(0, 4.0f, 1.0f);
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z / 2);
			// stop movement
			gameObject.GetComponent<MonsterFeet>().Kill ();
			m_bStomp = false;
			StartCoroutine (Fall());
		}
	}

	IEnumerator Fall() 
	{
		// accelerate
		for (float speed = 0.02f; speed < 2.0f; speed *= 1.2f)
		{
			transform.Translate(0, 0, speed);
			yield return new WaitForSeconds(.1f);
		}

		// done falling
		Destroy (gameObject);
	}
}
