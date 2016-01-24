using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour
{
    public int lifetime = 10;
    public int timeAlive = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(timeAlive >= lifetime)
        {
            Destroy(gameObject);
        }
        timeAlive++;
	}
}
