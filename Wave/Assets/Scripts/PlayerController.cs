using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity;
    public float verticalImpulse;
    Vector3 movement;
    public float speed = 10f;
    public PlayerManager playerManager = null;
    public Text countPoint;

    Animator animator;
    void Awake()
    {
        this.animator = this.GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        //velocity = 10f;
        //verticalImpulse = 20f;
        Manager.gManager.player = this;
        this.playerManager = new PlayerManager();
        this.playerManager.elementObject = this.gameObject;
        this.playerManager.Init(this.rb);
        this.playerManager.pointCount = this.countPoint;
        this.gameObject.AddComponent<GEComponent>().gameElement = this.playerManager;

        this.playerManager.deadEvent += Manager.Instance.GameOver;

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

    float isMoving;

    void Move()
    {

        isMoving = Input.GetAxisRaw("Horizontal");

        movement.Set(isMoving, 0f, 0f);

        movement = movement.normalized * speed * Time.deltaTime;

        this.transform.Translate(movement);

        animate(isMoving);
    }

    bool isPressing = false;
    void animate(float side)
    {
        if (side < 0)
        {
            this.animator.SetBool("CambioAIdl", true);

            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);


            if (!isPressing)
            {
                print("lesf");
                this.animator.SetBool("CambioAIdle", true);
                isPressing = true;
            }
        }
        else if (side > 0)
        {


            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

            if (!isPressing)
            {
                print("r");
                this.animator.SetBool("CambioAIdle", true);
                isPressing = true;
            }

        }
        else
        {

            if (isPressing)
            {
                print("min");
                this.animator.SetBool("CambioAIdle", false);
                isPressing = false;
            }
        }
    }

}
