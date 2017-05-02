using UnityEngine;
using System.Collections;
using Vuforia;

public class ButtonListener : MonoBehaviour, ITrackableEventHandler {

	public string gameObjectName;
	private TrackableBehaviour trackableBehaviour;
	private Animator animator;

	private bool showButton = false;
	private Rect startDancingButtonRect = new Rect(50,50,120,60);
	private Rect stopDancingButtonRect = new Rect(50,150,120,60);

	void Start () {
		trackableBehaviour = GetComponent<TrackableBehaviour>();
		if (trackableBehaviour)
		{
			trackableBehaviour.RegisterTrackableEventHandler(this);
		}
		animator = GameObject.Find (gameObjectName).GetComponent<Animator> ();
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
			showButton = true;
		}
		else
		{
			showButton = false;
		}
	}

	void OnGUI() {
		if (showButton) {
			// start dancing button
			if (GUI.Button(startDancingButtonRect, "Start Dancing")) {
				animator.SetTrigger ("startAnimating");
			}

			// stop dancing button
			if (GUI.Button(stopDancingButtonRect, "Stop Dancing")) {
				animator.SetTrigger ("stopAnimating");
			}
		}
	}
}