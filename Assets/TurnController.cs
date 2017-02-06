using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

	public delegate void phaseAction ();
	public static event phaseAction initialDraw;
	public static event phaseAction setup;
	public static event phaseAction reaction;
	public static event phaseAction draw;
	public static event phaseAction battle;

	void Start () {
		StartCoroutine (phaseController ());
	}
	IEnumerator phaseController () {
		initialDrawPhase ();
		for (int a = 0; a < 10; a++) {
			drawPhase ();
			setupPhase ();
			yield return new WaitForSeconds(5.0f);
			reactionPhase ();
			yield return new WaitForSeconds (10.0f);
			battlePhase ();

		}

	}
	void initialDrawPhase () {
		Debug.Log ("initialPhase");
		initialDraw ();

	}
	void setupPhase () {
		Debug.Log ("setupPhase");
		setup ();
	}
	void reactionPhase () {
		Debug.Log ("reactionPhase");
		reaction ();
	}
	void drawPhase () {
		Debug.Log ("draw");
		draw ();
	}
	void battlePhase () {
		Debug.Log ("battle");
		battle ();
	}
}
