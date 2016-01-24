using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool player1 = true;

    public float moveSpeed = 10f;

    public float attackSpeed = 1f;
    public float attackRange = 2;

    public float health = 4f;

    public int dodgeCool = 90;
    private int dodgeTimer;

    x360_Gamepad gamepad; // Gamepad instance

    private Vector3 lastMove = new Vector3 (0.0f, 0.0f, -1.0f);

    public Transform attackGhost;

    void Awake()
    {
        if(player1)
        {
            // Obtain the desired gamepad from GamepadManager
            gamepad = GamepadManager.Instance.GetGamepad(1);
        }
        else
        {
            // Obtain the desired gamepad from GamepadManager
            gamepad = GamepadManager.Instance.GetGamepad(2);
        }

        dodgeTimer = dodgeCool;
    }
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
        if(gamepad.IsConnected)
        {
            // Moving in straight lines
            if (gamepad.GetButton("DPad_Up"))
            {
                Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Down"))
            {
                Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Left"))
            {
                Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Right"))
            {
                Vector3 movement = new Vector3(-1.0f, 0.0f, 0.0f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }

            // Moving Diagonally
            if (gamepad.GetButton("DPad_Up") && gamepad.GetButton("DPad_Left"))
            {
                Vector3 movement = new Vector3(0.75f, 0.0f, -0.75f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Up") && gamepad.GetButton("DPad_Right"))
            {
                Vector3 movement = new Vector3(-0.75f, 0.0f, -0.75f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Down") && gamepad.GetButton("DPad_Left"))
            {
                Vector3 movement = new Vector3(0.75f, 0.0f, 0.75f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            else if (gamepad.GetButton("DPad_Down") && gamepad.GetButton("DPad_Right"))
            {
                Vector3 movement = new Vector3(-0.75f, 0.0f, 0.75f);
                gameObject.GetComponent<Rigidbody>().velocity = movement * moveSpeed;
                lastMove = movement;
            }
            
            // Dodge Roll
            if (gamepad.GetButtonDown("A"))
            {
                if (dodgeTimer >= dodgeCool)
                {
                    dodgeTimer = 0;
                    //                timer            power         fade
                    gamepad.AddRumble(0.1f, new Vector2(0.1f, 0.1f), 0.1f);
                    gameObject.GetComponent<Rigidbody>().velocity = lastMove * moveSpeed * 3;
                }
            }

            if (gamepad.GetButtonDown("X"))
            {
                Instantiate(attackGhost, (gameObject.GetComponent<Transform>().position + (lastMove * attackRange)), Quaternion.identity);
                Debug.Log("Attack");
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }

            dodgeTimer++;
        }
	}

    void OnCollision(GameObject other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            health = 0;
        }

        if(other.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
