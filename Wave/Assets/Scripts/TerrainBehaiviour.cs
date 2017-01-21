using UnityEngine;
using System.Collections;

public class TerrainBehaiviour : MonoBehaviour
{

    public float offset;
    private Rigidbody2D rb;
    public float Amplitud = 5f;
    private int periods = 4;
    private float currTheta;
    private float currSin;
    public AreaEffector2D impulse;
    private float initImpulse;
    private float centerCube;
    private float upLimit;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initImpulse = impulse.forceMagnitude;
        centerCube = this.transform.position.y;
        upLimit = centerCube + this.transform.localScale.y/2;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(transform.up* Amplitud * (Mathf.Sin(2 * Mathf.PI * Time.time)));
        if (Time.time + offset <= periods ) {
            currTheta = 2 * Mathf.PI * (Time.time + offset) % (2 * Mathf.PI);
            currSin = Mathf.Sin(currTheta);
            transform.position = new Vector3(transform.position.x, centerCube + Amplitud * currSin, transform.position.z);
            //rb.velocity = new Vector2(0f, Amplitud * (Mathf.Sin(2 * Mathf.PI * (Time.time + offset))));
            //rb.velocity = transform.up * Amplitud * (Mathf.Sin(2 * Mathf.PI * Time.time));
        }
        else
        {
            // Con velocity 
            //rb.velocity = new Vector2(rb.velocity.x,0f) ;
        }

        //if( currTheta < Mathf.PI/2 || currTheta > 3/2*Mathf.PI)
        if ( Mathf.Abs(currTheta - Mathf.PI / 2) < Mathf.PI/8)
            {
            impulse.enabled = true;
            impulse.forceMagnitude = initImpulse * Mathf.Max(Manager.gManager.player.transform.position.y - upLimit, centerCube);
            //this.transform.SetParent(Manager.gManager.player.transform,false);
            Manager.gManager.player.transform.parent = null;
        }
        else
        {
            //if (Time.time + offset <= periods){}
            
                impulse.enabled = false;
                //this.transform.SetParent(Manager.gManager.player.transform);
                Manager.gManager.player.transform.parent = this.transform;
            

        }

    }
}