using UnityEngine;
using System.Collections;

public class MonsterAnimate : MonoBehaviour {

	private AnimatedTextureExtendedUV animateTexture;
	private MonsterFeet monsterFeet;

	enum eMonsterDir {stationary = 0, left, right, up, down};
	private eMonsterDir eMoving = eMonsterDir.stationary;

	// Use this for initialization
	void Start () {
		animateTexture = GetComponent<AnimatedTextureExtendedUV>();

		monsterFeet = GetComponent<MonsterFeet>();
	}

	
	// Update is called once per frame
	void Update () 
	{
		// TODO: diagonal
		bool bStationary = monsterFeet.IsStationary();

		if (bStationary && eMoving != eMonsterDir.stationary)
		{
			// standing still
			eMoving = eMonsterDir.stationary;
			animateTexture.rowNumber = 0;
			return;
		}
		else if (!bStationary)
		{
			// not standing still

			if (monsterFeet.IsHorizontal())
			{
				if (monsterFeet.ReverseX() && eMoving != eMonsterDir.left)
				{
					eMoving = eMonsterDir.left;
					animateTexture.rowNumber = 1;
				}
				else if (!monsterFeet.ReverseX() && eMoving != eMonsterDir.right)
				{
					eMoving = eMonsterDir.right;
					animateTexture.rowNumber = 2;
				}
			}

			if (monsterFeet.IsVertical())
			{
				if (monsterFeet.ReverseY() && eMoving != eMonsterDir.up)
				{
					eMoving = eMonsterDir.up;
					animateTexture.rowNumber = 3;
				}
				else if (!monsterFeet.ReverseY() && eMoving != eMonsterDir.down)
				{
					eMoving = eMonsterDir.down;
					animateTexture.rowNumber = 0;
				}
			}
		}
	}
}
