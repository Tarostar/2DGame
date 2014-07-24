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

	void OnTriggerExit2D(Collider2D other)
	{
		// should rather be a timer or affected by death and have a max number, but hey its just a fun summer test project

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
		BoxCollider2D boxCollider = (BoxCollider2D)obj.GetComponent(typeof(BoxCollider2D));

		// get a random x position within area
		float x = Random.Range(obj.transform.position.x, obj.transform.position.x + boxCollider.size.x);

		// set position to spawn (add 1.0f for sprite height)
		Vector2 pos = new Vector2(x, obj.transform.position.y + 1.0f);

		// instantiate prefab monster object - rotate to get sprite correct
		GameObject monster = Instantiate(Resources.Load("Monster"), pos, Quaternion.identity) as GameObject;

		// get movement script and set step and stop position
		MonsterFeet mFeet = monster.GetComponent<MonsterFeet>();

		// set stop position (and ensure a minimum distance)
		mFeet.m_stopPositionX = Random.Range(x, obj.transform.position.x + boxCollider.size.x);
		/*if (mFeet.m_stopPositionX < x + 4.0f)
		{
			mFeet.m_startPositionX -= 4.0f;
			mFeet.m_stopPositionX = mFeet.m_startPositionX + 4.0f;
		}*/

		mFeet.m_stepX = Random.Range(2.0f, 8.0f);
	}
}
