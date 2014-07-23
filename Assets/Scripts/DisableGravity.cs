using UnityEngine;
using System.Collections;

public class DisableGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.angularVelocity = 0;
	}

}
