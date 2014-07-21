using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour {

	public GameObject m_spawnPoint;

	// Use this for initialization
	void Start () 
	{
		int nMonsters = Random.Range(1, 5);

		for (int i = 0; i < nMonsters; i++)
			SpawnMonster(gameObject);
	}

	void OnTriggerExit(Collider other)
	{

		if (other.tag == "Player")
		{
			int nMonsters = Random.Range(0, 3);
			
			for (int i = 0; i < nMonsters; i++)
				SpawnMonster(m_spawnPoint);
		}
	}

	private void SpawnMonster(GameObject obj)
	{
		// WARNING! This is just experimental for fun stuff to learn Unity and NOT the way to do it - there are better ways, but this is about learning methods

		// get box collider as we use that to measure the area it can spawn and roam
		BoxCollider boxCollider = (BoxCollider)obj.GetComponent(typeof(BoxCollider));

		// get a random x position within area
		float x = Random.Range(obj.transform.position.x, obj.transform.position.x + boxCollider.size.x);

		// set position to spawn (add 1.0f for sprite height)
		Vector3 pos = new Vector3(x, obj.transform.position.y + 1.0f, 0);

		// instantiate prefab monster object - rotate to get sprite correct
		GameObject monster = Instantiate(Resources.Load("Monster"), pos, Quaternion.Euler(new Vector3(90.0f, 180.0f, 0.0f))) as GameObject;

		// get movement script and set step and stop position
		MonsterFeet mFeet = monster.GetComponent<MonsterFeet>();

		// set stop position (and ensure a minimum distance)
		mFeet.m_stopPositionX = Random.Range(x, obj.transform.position.x + boxCollider.size.x);
		if (mFeet.m_stopPositionX < x + 2.0f)
			mFeet.m_stopPositionX += 2.0f;

		mFeet.m_stepX = Random.Range(2.0f, 8.0f);
	}
}
