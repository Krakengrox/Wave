using UnityEngine;
using System.Collections;

public class Manager : Singleton<Manager>
{
    public static Manager gManager;
    public PlayerController player;
    LevelLoad levelLoad;
    public GameObject levelGo;

    public Actions.Action gameOver;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();

        gManager = this;
        levelLoad = new LevelLoad(levelGo);

    }

    public void GameOver()
    {
        gameOver.invoke();
    }
}
