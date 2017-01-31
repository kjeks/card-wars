using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {
	public static List<KeyValuePair <int , string []>> collection;

	void Awake () {
		collection = new List<KeyValuePair <int, string []>> ();
		collection.Add(new KeyValuePair<int, string []>(1, new string[7]{"scout", "this is a scout", "2", "2", "2", "red", "kjeks"}));
		collection.Add(new KeyValuePair<int, string []>(2, new string[7]{"warrior", "this is a warrior", "2", "3", "3", "blue", "kjeks"}));
		collection.Add(new KeyValuePair<int, string []>(3, new string[7]{"big scout", "this is a big scout", "6", "4", "9", "green", "kjeks"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"big warrior", "this is a big warrior", "6", "7", "9", "black", "kjeks"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"fire imp", "", "1", "2", "1", "red","flower"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"frog", "", "2", "2", "3", "blue", "flower"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"vulcano giant", "", "9", "9", "9", "red", "flower"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"elf warrior", "", "2", "2", "3", "green", "flower"}));
		collection.Add(new KeyValuePair<int, string []>(4, new string[7]{"elven healer", "", "3", "3", "5", "green", "flower"}));

	}
	public static string [] getCardValues (int cardId) {

		return collection[cardId].Value;
	}

	public static int getCollectionSize () {
		return collection.Count;
	}
}
