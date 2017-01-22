using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : DropZone {

	public void generateCard () {
		GameObject generatedCard = (GameObject)Instantiate (Resources.Load ("Card"));
	
		generatedCard.transform.SetParent (this.transform);
	}

}
