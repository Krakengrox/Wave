using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerAction : MonoBehaviour {

    public bool trigger;
    [SerializeField]
    public Action action;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (trigger)
        {
            trigger = false;
            action.invoke();
        }
	}
}



[System.Serializable]
public class Action
{
    public bool enable = false;

    [System.Serializable]
    public class ActionDelegate : UnityEvent { }

    public ActionDelegate action;

    public void invoke()
    {
        if (this.enable) { this.action.Invoke(); }
    }
}
