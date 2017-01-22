using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void onClick () {
		GameObject handGameObject = GameObject.Find ("Hand");
		Hand hand = (Hand) handGameObject.GetComponent(typeof(Hand));
		hand.generateCard ();
	}
}
