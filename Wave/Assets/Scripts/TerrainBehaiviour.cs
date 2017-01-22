using UnityEngine;
using System.Collections;

public enum desplazamiento
{
    senosoidal
}

[System.Serializable]
public class TerrainData
{
    public float waitTime;
    public float secPerPeriod;
    public float Amplitud ;
    public desplazamiento desplazamiento;
    public float periods;
    public bool positiveWave;
}

public class TerrainBehaiviour : MonoBehaviour
{

    public int id = 0;
    public float offset;

    public TerrainData data;

    public AreaEffector2D impulse;
    private Rigidbody2D rb;
    private float currTheta;
    private float currSin;
    private float initImpulse;
    private float centerCube;
    private float upLimit;

    private Vector3 initialPos;
    [SerializeField]
    public bool move = false;



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
        this.initialPos = this.transform.position;
    }

    float timeToReach = 0f;


    public void Move(bool value)
    {

        if (value)
        {
            StartCoroutine(startThisThing());
        }
    }

    IEnumerator startThisThing()
    {
        yield return new WaitForSeconds(offset);
        SetTimeToReach();
        this.move = true;
    }

    void SetTimeToReach()
    {
        //this.timeToReach = Time.fixedTime + (data.secPerPeriod * data.periods) - offset;
        this.timeToReach = (data.secPerPeriod * data.periods);
        this.startTime0f = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aTime = Time.time;
        if (move)
        {
            waveMove();
        }
    }

    float aTime;
    float startTime0f;

    bool criteria()
    {
        bool value = false;

        value = (Time.fixedTime - this.startTime0f <= this.timeToReach);
        return value;
    }

    bool isImpulse()
    {
        //return (Mathf.Abs(currTheta - Mathf.PI / 2)  < Mathf.PI / 8) && this.move;
        return (Mathf.Abs(currSin - 1) < Mathf.Sin(Mathf.PI / 8)) && this.move;

    }


    float isPositiveWave()
    {
        return (this.data.positiveWave) ? 1f : -1f;
    }

    void waveMove()
    {

        if (criteria())
        {

            currTheta = 2 * Mathf.PI * (Time.fixedTime - this.startTime0f) / data.secPerPeriod % (2 * Mathf.PI);

            currSin = isPositiveWave() * Mathf.Sin(currTheta);
            transform.position = new Vector3(transform.position.x, centerCube + data.Amplitud * currSin, transform.position.z);
        }
        else
        {
            this.move = false;
            this.transform.position = this.initialPos;
        }

        makeImpulse();
    }

    void makeImpulse()
    {
        if (isImpulse())
        {
            impulse.enabled = true;
            impulse.forceMagnitude = initImpulse * Mathf.Max(Manager.gManager.player.transform.position.y - upLimit, centerCube);
            //Manager.gManager.player.transform.parent = null;
        }
        else
        {
            impulse.enabled = false;
            //Manager.gManager.player.transform.parent = this.transform;
        }
    }
}