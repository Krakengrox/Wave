using UnityEngine;
using System.Collections;

/// <summary>
/// Abstracts Class that defines an object in the game, gives attributes and behaviors,
/// It allows the elements to communicate with each other.
/// </summary>
public abstract class GameElement
{
    #region Variables
    public abstract ELEMENTTYPE elemetSide { get; set; }
	public abstract Rigidbody2D rb { get; protected set; }
    public abstract GameObject elementObject { get; set; }
	public virtual Detector detector { get; protected set; }
    public virtual ElementStatus status { get; set; }
    #endregion

    #region Methods
    public virtual void ChangeStats(ELEMENTSTATS statistics, int value)
    {

    }

	public virtual void Dead()
	{
		
	}

	public virtual void Point(int pointCount)
	{


	}
    #endregion

}
