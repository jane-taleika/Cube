using UnityEngine;
using System.Collections;

public class Congrats{
	private static string message;
	public static string get(){
		return message;
	}
	public static void set(string value){
		message = value;
	}
}
