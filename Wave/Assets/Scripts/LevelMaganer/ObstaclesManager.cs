using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Associated all enemy GameObject in the level with an instance of one enemy class
/// </summary>
public class ObstaclesManager
{
    #region Variables

    List<Transform> obstacles = null;


    Obstacle obstacle = null;


    #endregion

    #region Methods

    public ObstaclesManager(List<Transform> obstacles)
    {
        this.obstacles = obstacles;

        CreatedEnemies();
    }

    void CreatedEnemies()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].name == "SuperiorSolido")
            {
                obstacle = new Obstacle(obstacles[i].gameObject);
				obstacle.obstacleType = OBSTACLETYPE.SUPERIORSOLIDO;
            }
			else if (obstacles[i].name == "InferiorTransparente")
            {
                obstacle = new Obstacle(obstacles[i].gameObject);
				obstacle.obstacleType = OBSTACLETYPE.INFERIORTRANSPARENTE;
            }
			else if (obstacles[i].name == "SuperiorTransparente")
			{
				obstacle = new Obstacle(obstacles[i].gameObject);
				obstacle.obstacleType = OBSTACLETYPE.SUPERIORTRANSPARENTE;
			}
        }
    }
    #endregion
}


