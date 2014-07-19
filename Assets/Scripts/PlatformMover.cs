using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour 
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

	// TODO: test variable - should be removed
	public bool bVertical = false;

	// Use this for initialization
	void Start () 
	{
		// TODO: this is test - remove
		m_direction = bVertical ? eDirection.dirVertical : eDirection.dirHorizontal;

		m_startPositionX = transform.position.x;
		m_startPositionY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// set maximum
		if (m_direction == eDirection.dirHorizontal || m_direction == eDirection.dirDiagnoal)
		{
			//print (transform.position.x + " stop: " + m_stopPositionX);
			if (transform.position.x >= m_stopPositionX)
				m_bReverseX = true;
			else if (transform.position.x <= m_startPositionX)
				m_bReverseX = false;
		}

		if (m_direction == eDirection.dirVertical || m_direction == eDirection.dirDiagnoal)
		{
			if (transform.position.y >= m_stopPositionY)
				m_bReverseY = true;
			else if (transform.position.y <= m_startPositionY)
				m_bReverseY = false;
		}

		// platform movement
		if (m_direction == eDirection.dirHorizontal || m_direction == eDirection.dirDiagnoal)
		{
			if (m_bReverseX)
				transform.Translate (-m_stepX, 0, 0);
			else
				transform.Translate (m_stepX, 0, 0);
		}

		if (m_direction == eDirection.dirVertical || m_direction == eDirection.dirDiagnoal)
		{
			if (m_bReverseY)
				transform.Translate (0, -m_stepY, 0);
			else
				transform.Translate (0, m_stepY, 0);
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
}
