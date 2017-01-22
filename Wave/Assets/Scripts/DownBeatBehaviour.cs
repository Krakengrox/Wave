using System.Collections;
using UnityEngine;
using SynchronizerData;

public class DownBeatBehaviour : MonoBehaviour {

	private Animator anim;
	private BeatObserver beatObserver;
	[SerializeField]
	private WaveSkill wave;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> ();
		beatObserver = GetComponent<BeatObserver> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
		//if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat) {
		//if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat) {
			//anim.SetTrigger ("DownBeatTrigger");
			//transform.Rotate(new Vector3(0f,0f,45f)); 
			wave.StartCoroutine("TriggerSkill1");

			//wave.TriggerSkill1 ();
		}
	}
}
	