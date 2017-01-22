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
        //findChildren();
        instantiateChildren(this.childrenCount);
        this.platforms.Sort((x, y) => x.id.CompareTo(y.id));
    }
    public float xoffsetStep = -7.5f;
    public float startOffset = 1.5f;
    public int childrenCount = 10;

    void instantiateChildren(int count)
    {
        this.platforms = new List<TerrainBehaiviour>();

        GameObject recurso = Resources.Load<GameObject>("PlatformToInstantiate");
        TerrainBehaiviour terrainBehaiviour;

        for (int i = 0; i < count; i++)
        {
            this.platforms.Add(Instantiate(recurso).GetComponent<TerrainBehaiviour>());
            terrainBehaiviour = this.platforms[i];
            terrainBehaiviour.id = i;
            terrainBehaiviour.gameObject.name = i.ToString();
            terrainBehaiviour.transform.position = new Vector3(xoffsetStep + (startOffset * i), 0, 0);
            terrainBehaiviour.transform.parent = this.transform;
            terrainBehaiviour.gameObject.SetActive(true);
        }
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

    public float offsetStep = 0.1f;
    void changeDirection(List<TerrainBehaiviour> platforms, bool forward)
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            float offset = ((forward) ? i : platforms.Count - 1 - i) * offsetStep;
            platforms[i].offset = offset;
        }
    }

    void findChildren()
    {

        this.platforms = new List<TerrainBehaiviour>(FindObjectsOfType<TerrainBehaiviour>());
    }


    // Update is called once per frame
    void Update()
    {

    }
}
