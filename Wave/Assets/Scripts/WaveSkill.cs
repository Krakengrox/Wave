using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkill : MonoBehaviour
{

    public List<TerranSuperData> skillConfigs;
    public TerranSuperData skillUnique;

    PlatformManager platformManager;

    // Use this for initialization
    void Start()
    {
        init();
    }

    void init()
    {
        this.platformManager = PlatformManager.Instance;
    }

    public void TriggerSkill()
    {
        StartCoroutine(triggerSkill());
    }

    public void TriggerSkill1()
    {
        platformManager.DoWave(skillUnique);
    }


    public float delay = 0f;

    IEnumerator triggerSkill()
    {
        foreach (var skillConfig in this.skillConfigs)
        {
            platformManager.DoWave(skillConfig);
            yield return new WaitForSeconds(this.delay);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
