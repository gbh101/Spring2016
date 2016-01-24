using UnityEngine;
using System.Collections;

public class RefreshGamepads : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GamepadManager.Instance.Refresh();
    }
}
