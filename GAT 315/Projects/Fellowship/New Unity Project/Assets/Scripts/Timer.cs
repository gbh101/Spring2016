using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	private int timer = 0;
	public string levelToLoad;

	void Update () 
	{
		if (timer >= 400) 
		{
			Application.LoadLevel(levelToLoad);
		}
		timer++;
	}
}
