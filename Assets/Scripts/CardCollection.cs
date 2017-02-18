using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {
	public static List<KeyValuePair <int , string []>> collection;

	void Awake () {
		collection = new List<KeyValuePair <int, string []>> ();
		collection.Add(new KeyValuePair<int, string []>(1, new string[8]{"scout", "this is a scout", "2", "2", "2", "red", "kjeks", "true"}));
		collection.Add(new KeyValuePair<int, string []>(2, new string[8]{"warrior", "this is a warrior", "2", "3", "3", "blue", "kjeks", "true"}));
		collection.Add(new KeyValuePair<int, string []>(3, new string[8]{"big scout", "this is a big scout", "6", "4", "9", "green", "kjeks", "true"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"big warrior", "this is a big warrior", "6", "7", "9", "black", "kjeks", "true"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"fire imp", "", "1", "2", "1", "red","flower", "false"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"frog", "", "2", "2", "3", "blue", "flower","false"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"vulcano giant", "", "9", "9", "9", "red", "flower", "false"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"elf warrior", "", "2", "2", "3", "green", "flower", "false"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[8]{"elven healer", "", "3", "3", "5", "green", "flower", "false"}));

	}
	public static string [] getCardValues (int cardId) {

		return collection[cardId].Value;
	}

	public static int getCollectionSize () {
		return collection.Count;
	}
}
