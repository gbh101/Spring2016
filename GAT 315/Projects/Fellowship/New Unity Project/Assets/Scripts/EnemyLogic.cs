using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour
{
    public int health = 4;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTiggerEnter(Collider other)
    {
        Debug.Log("UHN");
        if(other.gameObject.name == "PlayerAttack")
        {
            health -= 1;
            Debug.Log(health);
        }
    }

    void OnTiggerStay(Collider other)
    {
        Debug.Log("asdf");
        if (other.gameObject.name == "PlayerAttack")
        {
            health -= 1;
            Debug.Log(health);
        }
    }
}
