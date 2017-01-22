using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : GameElement {

    #region Variables
    public System.Action deadEvent;
	public override GameObject elementObject { get; set; }

	public override ELEMENTTYPE elemetSide { get { return ELEMENTTYPE.PLAYER; } set { this.elemetSide = value; } }

	public override Rigidbody2D rb { get; protected set; }

	public Text pointCount;
	public int point;
	public void Init(Rigidbody2D rb)
	{
		this.rb = rb;
	}
	public override void Dead ()
	{
		base.Dead ();
		this.elementObject.SetActive(false);
        this.deadEvent();
	}
	public override void Point (int pointCount)
	{
		base.Point (pointCount);
		point += pointCount;
		this.pointCount.text = point.ToString ();
	}
	#endregion
}
