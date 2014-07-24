using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;

	public RollGround rollGround;
	private Transform originalParent;

	void Awake()
	{
		originalParent = this.transform.parent as Transform;
		character = GetComponent<PlatformerCharacter2D>();


	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (Input.GetButtonDown("Jump")) jump = true;
#endif

    }

	void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif

		// Pass all parameters to the character control script.
		character.Move( h, crouch , jump );

		if (rollGround !=  null)
		{
			rollGround.Roll(h, crouch, jump);
		}

        // Reset the jump input once it has been used.
	    jump = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{		
		if (other.gameObject.tag == "Platform" && this.gameObject.tag == "Player")
		{
			this.transform.parent = other.gameObject.transform;
			
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{		
		if (other.gameObject.tag == "Platform" && this.gameObject.tag == "Player")
		{
			this.transform.parent = originalParent;
			
		}
	}
}
