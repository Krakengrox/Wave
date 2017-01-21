using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkill : MonoBehaviour {

    public TerrainBehaiviour.Data skillConfig;
    PlatformManager platformManager;
    // Use this for initialization

    void Start () {
        init();
	}

    void init()
    {
        this.platformManager = PlatformManager.Instance;
    }

    public void TriggerSkill()
    {
        platformManager.DoWave();
    }

	// Update is called once per frame
	void Update () {

	}
}
