using UnityEngine;
using System.Collections;

public enum desplazamiento
{
    senosoidal
}

public class TerrainBehaiviour : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public float offset;
        public float waitTime;
        public float secPerPeriod;
        public float Amplitud = 3f;
        public desplazamiento desplazamiento = desplazamiento.senosoidal;
        public int periods = 20;

    }

    public Data data;

    public AreaEffector2D impulse;
    private Rigidbody2D rb;
    private float currTheta;
    private float currSin;
    private float initImpulse;
    private float centerCube;
    private float upLimit;

    private bool move = false;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        initImpulse = impulse.forceMagnitude;
        centerCube = this.transform.position.y;
        upLimit = centerCube + this.transform.localScale.y / 2;
    }

    public void Move(bool value)
    {
        this.move = value;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            waveMove();
        }
    }

    void waveMove()
    {
        //transform.Translate(transform.up* Amplitud * (Mathf.Sin(2 * Mathf.PI * Time.time)));
        if (((Time.time + data.offset) / data.secPerPeriod <= data.periods) && ((Time.time + data.offset) > data.waitTime))
        {
            currTheta = 2 * Mathf.PI * (Time.time + data.offset) / data.secPerPeriod % (2 * Mathf.PI);
            currSin = Mathf.Sin(currTheta);
            //print(Time.time);
            transform.position = new Vector3(transform.position.x, centerCube + data.Amplitud * currSin, transform.position.z);
            //rb.velocity = new Vector2(0f, Amplitud * (Mathf.Sin(2 * Mathf.PI * (Time.time + offset))));
            //rb.velocity = transform.up * Amplitud * (Mathf.Sin(2 * Mathf.PI * Time.time));
        }
        else
        {
            // Con velocity
            //rb.velocity = new Vector2(rb.velocity.x,0f) ;
        }

        //if( currTheta < Mathf.PI/2 || currTheta > 3/2*Mathf.PI)
        if (Mathf.Abs(currTheta - Mathf.PI / 2) < Mathf.PI / 8)
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