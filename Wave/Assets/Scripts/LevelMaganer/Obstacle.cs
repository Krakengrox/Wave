using UnityEngine;
using System.Collections;

/// <summary>
/// class that creates an Item based on an GameElement within the game
/// </summary>
public class Obstacle : GameElement
{

    #region Variables
    public override Detector detector { get; protected set; }

    public override GameObject elementObject { get; set; }

	public override ELEMENTTYPE elemetSide { get { return ELEMENTTYPE.OBSTACLE; } set { this.elemetSide = value; } }

	public override Rigidbody2D rb { get; protected set; }

	public OBSTACLETYPE obstacleType  { get; set; }

    #endregion

    #region Methods

    public Obstacle(GameObject prefab)
    {
        this.elementObject = prefab;
        InitComponent();
    }

    void InitComponent()
    {
        this.elementObject.AddComponent<GEComponent>().gameElement = this;
        this.detector = this.elementObject.AddComponent<Detector>();
		this.rb = this.elementObject.GetComponent<Rigidbody2D>();
        this.detector.actionCollision += Test;
        this.detector.enter = true;
    }

    void Test(GameElement target, bool enter)
    {
		
		switch (this.obstacleType) {
		case OBSTACLETYPE.SUPERIORSOLIDO:
			if (target.elementObject.transform.position.y < this.elementObject.transform.position.y) //debajo
			{
				target.Dead();
			} else {
				
			}
			break;
		case OBSTACLETYPE.INFERIORTRANSPARENTE:
			if (target.elementObject.transform.position.y < this.elementObject.transform.position.y) //debajo
			{
				//this.elementObject.GetComponent<Collider2D>().enabled = false;
				this.elementObject.transform.GetChild (0).GetComponent<Collider2D>().enabled = false;
			} else {
				//this.elementObject.GetComponent<Collider2D>().enabled = true;
				this.elementObject.transform.GetChild (0).GetComponent<Collider2D>().enabled = true;
			}
	
			break;
		case OBSTACLETYPE.SUPERIORTRANSPARENTE:
			if (target.elementObject.transform.position.y < this.elementObject.transform.position.y) //debajo
			{
				//this.elementObject.GetComponent<Collider2D>().enabled = true;
				this.elementObject.transform.GetChild (0).GetComponent<Collider2D>().enabled = true;
				//if (!enter) {
					target.Dead ();
				//}

			} else {
				//this.elementObject.GetComponent<Collider2D>().enabled = false;
				this.elementObject.transform.GetChild (0).GetComponent<Collider2D>().enabled = false;
			}

			break;

		default:
			break;
		}
    }
    #endregion

}
