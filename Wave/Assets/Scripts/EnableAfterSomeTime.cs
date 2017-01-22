using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableAfterSomeTime : MonoBehaviour
{

    public GameObject[] targets;
    public float delay = 0;
    public Actions.Action atStart;
    public Actions.Action isDone;
    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        atStart.invoke();
        foreach (GameObject target in targets)
        {
            target.SetActive(false);
            Image image = target.GetComponentInChildren<Image>();
            image.CrossFadeAlpha(0, 0, false);
        }

        targets[0].SetActive(true);

        StartCoroutine(timer(delay));
    }

    IEnumerator timer(float delay)
    {

        foreach (var item in targets)
        {
            item.SetActive(true);
            Image image = item.GetComponentInChildren<Image>();
            image.CrossFadeAlpha(1f, delay / 2, false);
            yield return new WaitForSeconds(delay / 2);
            image.CrossFadeAlpha(0f, delay / 2, false);
            yield return new WaitForSeconds(delay / 2);
            item.SetActive(false);
        }
        isDone.invoke();
    }

}