using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Automatic association of the all elements in the game with instance class, behavior and functions 
/// (Load Level)
/// </summary>
public class LevelLoad
{
	#region Variables

	public GameObject levelGo;

	public List<Transform> obstacles;

	public List<Transform> items;

	ItemManager itemManager;

	ObstaclesManager obstaclesManager;

	#endregion

	#region Methods

	public LevelLoad(GameObject levelGo)
	{
		this.levelGo = levelGo;
		InitElementsList();
		WakeElements();
	}

	/// <summary>
	/// Init List
	/// </summary>
	public void InitElementsList()
	{
		this.obstacles = new List<Transform>();
		this.items = new List<Transform>();
	}

	public void WakeElements()
	{
		this.itemManager = new ItemManager(FindItems());
		this.obstaclesManager = new ObstaclesManager(FindObstacles());
	}
		

	public List<Transform> FindObstacles()
	{
		Transform ts = this.levelGo.transform.FindChild("Obstacles");
		foreach (Transform obstacle in ts)
		{
			this.obstacles.Add(obstacle);
		}
		return this.obstacles;
	}


	public List<Transform> FindItems()
	{
		Transform ts = this.levelGo.transform.FindChild("Items");
		foreach (Transform item in ts)
		{
			this.items.Add(item);
		}
		return this.items;
	}
		
	#endregion
}