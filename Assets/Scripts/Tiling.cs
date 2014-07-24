using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	// offset to avoid weird errors...
	public int offsetX = 2;

	// check if neew to instantiate
	public bool hasRightBuddy = false;
	public bool hasLeftBuddy = false;

	// used if object not tilable
	public bool reverseScale = false;

	// width of element
	private float spriteWidth = 0.0f;

	private Camera cam;
	private Transform myTransform;

	public Parallax parallaxScript;

	void Awake()
	{

		// set up camera referance
		cam = Camera.main;

		myTransform = transform;
	}

	void Start () 
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}

	void Update () 
	{
		if (hasLeftBuddy && hasRightBuddy)
			return;

		// ok, we need a buddy

		// calculate the cameras extend (half the width) of what camera can see in world coordinates
		float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

		// calculate x position where camera can see edge of sprite (element)
		float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
		float edgeVisiblePositionLeft =  (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

		// can we see edge of element?
		if (!hasRightBuddy && cam.transform.position.x >= edgeVisiblePositionRight - offsetX)
		{
			MakeNewBuddy (1);
			hasRightBuddy = true;
		}

		if (!hasLeftBuddy && cam.transform.position.x <= edgeVisiblePositionLeft + offsetX)
		{
			MakeNewBuddy (-1);
			hasLeftBuddy = true;
		}
	}

	// right +1, left -1
	void MakeNewBuddy(int rightOrLeft)
	{
		// calculate new buddy position
		Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

		parallaxScript.AddNewTile(newBuddy);

		// if not tilable, reverse x scale to make it tile perfectly
		if (reverseScale)
		{
			newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		// keep objects in same parent
		newBuddy.parent = myTransform.parent;

		if (rightOrLeft > 0)
			newBuddy.GetComponent<Tiling>().hasLeftBuddy = true;
		else
			newBuddy.GetComponent<Tiling>().hasRightBuddy = true;
	}
}
