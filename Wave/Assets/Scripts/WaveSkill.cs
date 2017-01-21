using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkill : MonoBehaviour {

    public TerranSuperData skillConfig;
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
        platformManager.DoWave(skillConfig);
    }

	// Update is called once per frame
	void Update () {

	}
}
