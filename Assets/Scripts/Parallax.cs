using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	// array list of all parallaxed backgrounds (and foregrounds)
	public Transform[] backgrounds;
	// how much to move it (based on z-axis)
	private float[] parallaxScales;
	// smoothness of parallax (must be > 0)
	public float smoothing = 1.0f;

	// reference to main cameras transform
	private Transform cam;
	// camera position in previous frame
	private Vector3 previousCamPos;

	// before start (great for references)
	void Awake()
	{
		// set up camera referance
		cam = Camera.main.transform;
	}

	// init at startup
	void Start () 
	{
		// store previous frame position
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	// called each fram
	void Update () 
	{
		// for each background
		for (int i = 0; i < backgrounds.Length; i++)
		{
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set target x position which is current position plus parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// TODO: also for Y-axis
			// float backgroundTargetPosY = backgrounds[i].position.y + parallax;

			// create target position - background's current pos with target x pos
			Vector3 backgroundTargetPosition = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		// set previous camera position to camera's position at end of the frame
		previousCamPos = cam.position;
	}
}
