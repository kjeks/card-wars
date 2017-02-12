using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	private Text currentPhaseText;
	private static float msToNextPhase; 

	void Start () {
		GameObject GOtext = GameObject.FindGameObjectWithTag("Info");
		currentPhaseText = GOtext.GetComponent<Text> ();
		StartCoroutine (phaseController ());
	}

	void Update () {
		msToNextPhase -= Time.deltaTime; 	
		float seconds = Mathf.Round (msToNextPhase);
		updatePhaseDisplay (seconds);

	}
	private void updatePhaseDisplay (float seconds) {
		currentPhaseText.text = getCurrentPhase ().ToString () + "  " + seconds;
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
		currentPhase = Phase.INITIAL_DRAW;
		currentPhaseText.text = "initial draw";
		initialDraw ();


	}
	void setupPhase () {
		currentPhase = Phase.SETUP;
		msToNextPhase = 5.0f;
		currentPhaseText.text = "Setup" + getMsToNextPhase();
		setup ();

	}
	void reactionPhase () {
		currentPhase = Phase.REACTION;
		msToNextPhase = 10.0f;
		currentPhaseText.text = "reaction";
		reaction ();
	}
	void drawPhase () {
		currentPhase = Phase.DRAW;
		currentPhaseText.text = "draw";
		draw ();
	}
	void battlePhase () {
		currentPhase = Phase.BATTLE;
		msToNextPhase = 5.0f;
		currentPhaseText.text = "battle";
		battle ();
	}
	void summaryPhase () {
		currentPhase = Phase.SUMMARY;
		currentPhaseText.text = "summary";
		summary ();
	}
	public static Phase getCurrentPhase () {
		return currentPhase;
	}
	public static float getMsToNextPhase() {
		return msToNextPhase;
	}

}
