using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerranSuperData
{
    public TerrainData terranData;
    public bool forward = false;
}

public class PlatformManager : Singleton<PlatformManager>
{

    public List<TerrainBehaiviour> platforms;

    // Use this for initialization
    void Start()
    {
        init();
    }

    void init()
    {
        findChildren();
    }

    public void DoWave(TerranSuperData data)
    {
        print("move");

        changeDirection(platforms, data.forward);

        foreach (var item in platforms)
        {
            item.data = data.terranData;
            item.Move(true);
        }

    }

    float offsetStep = 0.1f;
    void changeDirection(List<TerrainBehaiviour> platforms, bool forward)
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            float offset= ((forward) ? i : platforms.Count - 1 - i) * offsetStep;
            platforms[i].offset = offset;
        }
    }

    void findChildren()
    {

        this.platforms = new List<TerrainBehaiviour>(FindObjectsOfType<TerrainBehaiviour>());
        this.platforms.Sort((x, y) => x.id.CompareTo(y.id));
    }


    // Update is called once per frame
    void Update()
    {

    }
}
