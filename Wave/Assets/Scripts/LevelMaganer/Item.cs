using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// class that creates an Item based on an GameElement within the game
/// </summary>
public class Item : GameElement
{
    #region Variables
    public override GameObject elementObject { get; set; }
    public override ELEMENTTYPE elemetSide { get { return ELEMENTTYPE.ITEM; } set { this.elemetSide = value; } }
	public override Rigidbody2D rb { get; protected set; }
	public override Detector detector{ get; protected set; }
    #endregion

    #region Methods

    public Item(GameObject prefab)
    {
        this.elementObject = prefab;
        InitComponent();
    }

    /// <summary>
    /// Init component it needs the object
    /// </summary>
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
		target.Point(1);
        this.elementObject.SetActive(false);
    }
    #endregion
}
