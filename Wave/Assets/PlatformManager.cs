using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public List<GameObject> platforms;
	// Use this for initialization
	void Start () {
		this.platforms = new List<GameObject>();

		foreach (Transform platform in this.gameObject.transform)
		{
			this.platforms.Add(platform.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
