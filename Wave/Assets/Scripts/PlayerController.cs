using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity;
    public float verticalImpulse;
	PlayerManager playerManager = null;
	public Text countPoint;
	Vector3 movement;
	public float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //velocity = 10f;
        //verticalImpulse = 20f;
        Manager.gManager.player = this;	
		this.playerManager = new PlayerManager ();
		this.playerManager.elementObject = this.gameObject;
		this.playerManager.Init (this.rb);
		this.playerManager.pointCount = this.countPoint;
		this.gameObject.AddComponent<GEComponent> ().gameElement = this.playerManager;

    }

    void Update()
    {
       // if (Input.GetKey("space"))
       // {
        //    rb.AddForce(transform.up * verticalImpulse);
        //}

        //rb.AddForce(transform.forward * velocity * Input.GetAxis("Horizontal"));
       // rb.AddForce (transform.right *velocity * Input.GetAxis("Horizontal"));
		Move();

    }

	void Move()
	{

			movement.Set(Input.GetAxisRaw("Horizontal"), 0f, 0f);

		movement = movement.normalized * speed * Time.deltaTime;

		this.transform.Translate(movement);

	}

}
