using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {
	public static List<KeyValuePair <int , string []>> collection;

	void Start () {
		collection = new List<KeyValuePair <int, string []>> ();
		collection.Add(new KeyValuePair<int, string []>(1, new string[6]{"scout", "this is a scout", "2", "2", "2", "red"}));
		collection.Add(new KeyValuePair<int, string []>(2, new string[6]{"warrior", "this is a warrior", "2", "3", "3", "red"}));
		collection.Add(new KeyValuePair<int, string []>(3, new string[6]{"big scout", "this is a big scout", "6", "4", "9", "red"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"big warrior", "this is a big warrior", "6", "7", "9", "red"}));
//			{2, new string ["warrior", "warrior", 5, 5, 5, "red"] }

	}
	public static string [] getCardValues (int cardId) {

		return collection[cardId].Value;
	}


//	public string [] getCardValues (int cardId) {
//		return collection [cardId];
//	}
}
