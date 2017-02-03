using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

	public delegate void clickAction ();
	public static event clickAction onClicked;

	void Start () {
		StartCoroutine (startPhases ());
	}

	IEnumerator startPhases () {
		for(int a = 0; a < 10; a++) {
			Debug.Log ("test");
			yield return new WaitForSeconds (5.0f);
			onClicked ();
		}
	}
}
