using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Automatic detector element enter in a collider
/// </summary>
public class Detector : MonoBehaviour
{
    #region Variables

    public Action<GameElement, bool> actionCollision = null;

    public Action actionColli = null;

    public GameElement target = null;

    GameElement myGameElement;


    public bool enter = false;


    float timeToWait = 2;
    float time = 3;
    #endregion

    #region Methods
    void Awake()
    {
        this.myGameElement = this.GetComponent<GEComponent>().gameElement;
    }
			
	void OnTriggerEnter2D(Collider2D incommingObject)
    {
		this.enter = true;
		if (incommingObject.gameObject.tag == "Player" && incommingObject.GetComponent<GEComponent>())
		{
			this.target = incommingObject.GetComponent<GEComponent>().gameElement;
			actionCollision(target, enter);
		}

		//if (incommingObject.GetComponent<GEComponent>())
        //
          //  this.target = incommingObject.GetComponent<GEComponent>().gameElement;

           // if (this.myGameElement.elemetSide == ELEMENTTYPE.ENEMY && ELEMENTTYPE.ALLY == target.elemetSide)
//{
           //     StartCoroutine(Timer());
           // }
           // else if (this.myGameElement.elemetSide == ELEMENTTYPE.ITEM && this.myGameElement.elemetSide != ELEMENTTYPE.ENEMY)
            //{
             //   actionCollision(target, enter);
           // }
           // else if (this.myGameElement.elemetSide == ELEMENTTYPE.ALLY && target.elemetSide != ELEMENTTYPE.ITEM && target.elemetSide != ELEMENTTYPE.ENEMY)
            //{
		//
		//
//            }
       //}
       //else if (this.myGameElement.elemetSide == ELEMENTTYPE.ALLY)
        //{
       //     actionColli();
      //  }


    }

	void OnTriggerExit2D(Collider2D incommingObject)
    {
		
		//if (incommingObject.gameObject.tag == "Player" && incommingObject.GetComponent<GEComponent>())
		//	actionCollision(target, enter);
		//	this.enter = false;
		//if (incommingObject.GetComponent<GEComponent>())
        //{
		//	this.target = incommingObject.GetComponent<GEComponent>().gameElement;
        //    this.enter = false;
        //}
        //else if (this.myGameElement.elemetSide == ELEMENTTYPE.ALLY)
        //{
            //Destroy(this.myGameElement.elementObject);
        //}

    }

	
    IEnumerator Timer()
    {
        while (enter)
        {
            this.time += Time.deltaTime;
            if (this.time >= timeToWait)
            {
                actionCollision(target, enter);
                this.time = 0f;
            }
            yield return null;
        }
        this.time = 3f;
        yield return 0;

    }
    #endregion
}