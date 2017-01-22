using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// component that identifies an object as a Game Element
/// </summary>
public class GEComponent : MonoBehaviour
{
    #region Variables
    public GameElement gameElement = null;
    public Action fixedUpdateEvent;
    public Action updateEvent;
    #endregion

    #region Variables
    void FixedUpdate()
    {
        if (fixedUpdateEvent != null)
            fixedUpdateEvent();

    }

    void Update()
    {
        if (updateEvent != null)
            updateEvent();
    }
    #endregion
}
