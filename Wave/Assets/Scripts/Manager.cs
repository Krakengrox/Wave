using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public static Manager gManager;
    public PlayerController player;
	// Use this for initialization
	void Awake () {
        gManager = this;
	}

}
