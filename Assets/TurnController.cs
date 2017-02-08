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
	public static event phaseAction summary;

	public enum Phase {INITIAL_DRAW, DRAW, SETUP, REACTION, BATTLE, SUMMARY};
	private static Phase currentPhase = Phase.INITIAL_DRAW;

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
			yield return new WaitForSeconds (5.0f);
			summaryPhase ();
		}

	}
	void initialDrawPhase () {
		Debug.Log ("initialPhase");
		currentPhase = Phase.INITIAL_DRAW;
		initialDraw ();

	}
	void setupPhase () {
		Debug.Log ("setupPhase");
		currentPhase = Phase.SETUP;
		setup ();
	}
	void reactionPhase () {
		Debug.Log ("reactionPhase");
		currentPhase = Phase.REACTION;
		reaction ();
	}
	void drawPhase () {
		Debug.Log ("drawPhase");
		currentPhase = Phase.DRAW;
		draw ();
	}
	void battlePhase () {
		Debug.Log ("battlePhase");
		currentPhase = Phase.BATTLE;
		battle ();
	}
	void summaryPhase () {
		Debug.Log ("summaryPhase");
		currentPhase = Phase.SUMMARY;
		summary ();
	}
	public static Phase getCurrentPhase () {
		return currentPhase;
	}
}
