using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public static Manager gManager;
    public PlayerController player;
	LevelLoad levelLoad;
	public GameObject levelGo;

	// Use this for initialization
	void Awake () {
        gManager = this;
		levelLoad = new LevelLoad (levelGo);
	}

}
