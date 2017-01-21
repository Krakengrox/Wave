using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float velocity;
	public float verticalImpulse;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		velocity = 10f;
		verticalImpulse = 1000f;
	}

	void Update() {
		if (Input.GetKey ("space")) 
		{
			rb.AddForce(transform.up * verticalImpulse);
		}

		//rb.AddForce(transform.forward * velocity * Input.GetAxis("Horizontal"));
		rb.velocity = (transform.forward * velocity * Input.GetAxis("Horizontal"));
	}
}