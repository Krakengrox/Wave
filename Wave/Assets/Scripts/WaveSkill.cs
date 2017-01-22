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

    public bool loop = false;
    IEnumerator triggerSkill()
    {
        bool once = true;
        while (loop || once)
        {
            if (once) once = false;

            foreach (var skillConfig in this.skillConfigs)
            {
                platformManager.DoWave(skillConfig);
                yield return new WaitForSeconds(this.delay);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
