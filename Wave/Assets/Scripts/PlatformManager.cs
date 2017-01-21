using System.Collections.Generic;
using UnityEngine;

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

    public void DoWave()
    {
        print("move");
        foreach (var item in platforms)
        {
            item.Move(true);
        }
    }

    void findChildren()
    {

        this.platforms = new List<TerrainBehaiviour>();

        foreach (TerrainBehaiviour platform in FindObjectsOfType<TerrainBehaiviour>())
        {
            this.platforms.Add(platform);

            //defualts

            //platform.data.Amplitud = 3f;
            //platform.data.desplazamiento =;
            //platform.data.offset =;
            //platform.data.secPerPeriod =;
            //platform.data.waitTime =;
            //platform.data.periods = 20;

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
