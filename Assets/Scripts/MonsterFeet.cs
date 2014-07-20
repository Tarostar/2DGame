using UnityEngine;
using System.Collections;

public class MonsterFeet : MonoBehaviour 
{
	// movement direction
	enum eDirection {dirStationary = 0, dirVertical, dirHorizontal, dirDiagnoal};
	private eDirection m_direction = eDirection.dirStationary;

	// start/stop  position for horizontal and vertical movemenet
	private float m_startPositionX = 0.0f;
	private float m_startPositionY = 0.0f;
	public float m_stopPositionX = 0.0f;
	public float m_stopPositionY = 0.0f;

	public bool m_bAllowDiagonal = false;

	// tracks movement direction per axes
	private bool m_bReverseX = false;
	private bool m_bReverseY = false;

	// step size
	public float m_stepX = 0;
	public float m_stepY = 0;

	// random tweaks to the speed each time changes direction
	private float m_speedModX = 0;
	private float m_speedModY = 0;

	// don't start checking for this time
	public float m_startCheckInSeconds = 2.5f; 
	
	//check with this frequency
	public float m_checkEverySecond = 1.0f;

	// TODO: test variable - should be removed and replaced with enum type
	public bool bVertical = false;

	// Use this for initialization
	void Start () 
	{
		// TODO: this is test - remove
		m_direction = bVertical ? eDirection.dirVertical : eDirection.dirHorizontal;

		m_startPositionX = transform.position.x;
		m_startPositionY = transform.position.y;

		StartCoroutine (SpeedTweak());
	}

	IEnumerator SpeedTweak()
	{
		yield return new WaitForSeconds(m_startCheckInSeconds);

		// TODO: diagnoal

		while (m_stepX + m_stepY > 0.0f)
		{
			m_speedModX = Random.Range(0.0f, m_stepX);
			m_speedModY = Random.Range(0.0f, m_stepY);

			if (m_direction == eDirection.dirHorizontal && m_speedModX < m_stepX / 4.0f)
			{
				m_direction = eDirection.dirStationary;
			}
			else if (m_direction == eDirection.dirVertical && m_speedModY < m_stepY / 4.0f)
			{
				m_direction = eDirection.dirStationary;
			}
			else if (m_direction == eDirection.dirStationary)
			{
				if (bVertical && m_speedModY >= m_stepY / 4.0f)
					m_direction = eDirection.dirVertical;
				else if (!bVertical && m_speedModX >= m_stepY / 4.0f)
					m_direction = eDirection.dirHorizontal;

			}

			float wait = m_checkEverySecond + m_speedModX + m_speedModY;
			yield return new WaitForSeconds(wait);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// set maximum
		if (m_direction == eDirection.dirHorizontal || m_direction == eDirection.dirDiagnoal)
		{
			if (transform.position.x >= m_stopPositionX)
				m_bReverseX = false;
			else if (transform.position.x <= m_startPositionX)
				m_bReverseX = true;
		}

		if (m_direction == eDirection.dirVertical || m_direction == eDirection.dirDiagnoal)
		{
			if (transform.position.y >= m_stopPositionY)
				m_bReverseY = false;
			else if (transform.position.y <= m_startPositionY)
				m_bReverseY = true;
		}

		// monster movement
		if (m_direction == eDirection.dirHorizontal || m_direction == eDirection.dirDiagnoal)
		{
			if (m_bReverseX)
				transform.Translate ((-m_stepX + m_speedModX) * Time.deltaTime, 0, 0);
			else
				transform.Translate ((m_stepX - m_speedModX) * Time.deltaTime, 0, 0);
		}

		if (m_direction == eDirection.dirVertical || m_direction == eDirection.dirDiagnoal)
		{
			if (m_bReverseY)
				transform.Translate (0, (-m_stepY + m_speedModY) * Time.deltaTime, 0);
			else
				transform.Translate (0, (m_stepY - m_speedModY) * Time.deltaTime, 0);
		}
	}

	public void ToggleDirection()
	{
		if (m_direction == eDirection.dirVertical)
			m_direction = eDirection.dirHorizontal;

		if (m_direction == eDirection.dirHorizontal)
		{
			if (m_bAllowDiagonal)
				m_direction = eDirection.dirDiagnoal;
			else
				m_direction = eDirection.dirStationary;
		}

		if (m_direction == eDirection.dirDiagnoal)
			m_direction = eDirection.dirStationary;

		if (m_direction == eDirection.dirStationary)
			m_direction = eDirection.dirVertical;
	}

	public void SetVertical()
	{
		m_direction = eDirection.dirVertical;
	}

	public void SetHorizontal()
	{
		m_direction = eDirection.dirHorizontal;
	}

	public void SetDiagonal()
	{
		m_direction = eDirection.dirDiagnoal;
	}

	public void SetStationary()
	{
		m_direction = eDirection.dirStationary;
	}

	public bool IsVertical()
	{
		return m_direction == eDirection.dirVertical;
	}

	public bool IsHorizontal()
	{
		return m_direction == eDirection.dirHorizontal;
	}

	public bool IsStationary()
	{
		return m_direction == eDirection.dirStationary;
	}

	public bool ReverseX()
	{
		return m_bReverseX;
	}

	public bool ReverseY()
	{
		return m_bReverseY;
	}

	public void Kill()
	{
		StopCoroutine (SpeedTweak());

		m_direction = eDirection.dirStationary;
		m_stepX = 0;
		m_stepY = 0;
		m_speedModX = 0;
		m_speedModY = 0;
	}
}
