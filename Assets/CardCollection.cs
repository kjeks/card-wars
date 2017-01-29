using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {
	public static List<KeyValuePair <int , string []>> collection;

	void Start () {
		collection = new List<KeyValuePair <int, string []>> ();
		collection.Add(new KeyValuePair<int, string []>(1, new string[6]{"scout", "this is a scout", "2", "2", "2", "red"}));
		collection.Add(new KeyValuePair<int, string []>(2, new string[6]{"warrior", "this is a warrior", "2", "3", "3", "blue"}));
		collection.Add(new KeyValuePair<int, string []>(3, new string[6]{"big scout", "this is a big scout", "6", "4", "9", "green"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"big warrior", "this is a big warrior", "6", "7", "9", "black"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"fire imp", "", "1", "2", "1", "red"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"frog", "", "2", "2", "3", "blue"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"vulcano giant", "", "9", "9", "9", "red"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"elf warrior", "", "2", "2", "3", "green"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[6]{"elven healer", "", "3", "3", "5", "green"}));

	}
	public static string [] getCardValues (int cardId) {

		return collection[cardId].Value;
	}

	public static int getCollectionSize () {
		return collection.Count;
	}
}
