using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject pauseLogic;

    public bool player1 = true;

    public float moveSpeed = 10f;

    public int attackSpeed = 30;
    private int attackTimer;
    public float attackRange = 2f;

    public float health = 4f;

    private GameObject h1;
    private GameObject h2;
    private GameObject h3;
    private GameObject h4;

    public GameObject p1h1;
    public GameObject p1h2;
    public GameObject p1h3;
    public GameObject p1h4;

    public GameObject p2h1;
    public GameObject p2h2;
    public GameObject p2h3;
    public GameObject p2h4;

    public int dodgeCool = 90;
    private int dodgeTimer;

    public GameObject loseText;

    x360_Gamepad gamepad; // Gamepad instance

    private Vector3 lastMove = new Vector3 (0.0f, 0.0f, -1.0f);

    // Player Attack Shape
    public Transform attackGhost;

    void Awake()
    {
        if(player1)
        {
            // Obtain the desired gamepad from GamepadManager
            gamepad = GamepadManager.Instance.GetGamepad(1);
            h1 = p1h1;
            h2 = p1h2;
            h3 = p1h3;
            h4 = p1h4;
        }
        else
        {
            // Obtain the desired gamepad from GamepadManager
            gamepad = GamepadManager.Instance.GetGamepad(2);
            h1 = p2h1;
            h2 = p2h2;
            h3 = p2h3;
            h4 = p2h4;
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

            // Player Attacks
            if (gamepad.GetButtonDown("X"))
            {
                if(attackTimer >= attackSpeed)
                {
                    Instantiate(attackGhost, (gameObject.GetComponent<Transform>().position + (lastMove * attackRange)), Quaternion.identity);
                    attackTimer = 0;
                }
            }

            /*************Cheats*************/
            /********************************/
            /*if (Input.GetKeyDown("8"))
            {
                next Round
            }*/
            if (Input.GetKeyDown("9"))
            {
                health = 9999;
            }
            if (Input.GetKeyDown("0"))
            {
                health = 0;
            }
            /*********************************/
            /*********************************/

            if (health >= 4)
            {
                h1.GetComponent<SpriteRenderer>().enabled = true;
                h2.GetComponent<SpriteRenderer>().enabled = true;
                h3.GetComponent<SpriteRenderer>().enabled = true;
                h4.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (health == 3)
            {
                h1.GetComponent<SpriteRenderer>().enabled = false;
                h2.GetComponent<SpriteRenderer>().enabled = true;
                h3.GetComponent<SpriteRenderer>().enabled = true;
                h4.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (health == 2)
            {
                h1.GetComponent<SpriteRenderer>().enabled = false;
                h2.GetComponent<SpriteRenderer>().enabled = false;
                h3.GetComponent<SpriteRenderer>().enabled = true;
                h4.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (health == 1)
            {
                h1.GetComponent<SpriteRenderer>().enabled = false;
                h2.GetComponent<SpriteRenderer>().enabled = false;
                h3.GetComponent<SpriteRenderer>().enabled = false;
                h4.GetComponent<SpriteRenderer>().enabled = true;
            }
            // Needs to be replaced by a downed mechanic
            else
            {
                // Destroys the player character if they lose all health
                Destroy(gameObject);
                h1.GetComponent<SpriteRenderer>().enabled = false;
                h2.GetComponent<SpriteRenderer>().enabled = false;
                h3.GetComponent<SpriteRenderer>().enabled = false;
                h4.GetComponent<SpriteRenderer>().enabled = false;
                loseText.GetComponent<Transform>().position = new Vector3 (0f, -2.45983f, 12.14942f);
            }

            // Update Timers
            dodgeTimer++;
            attackTimer++;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        // Kills the player if they fall out of the arena
        if (collision.gameObject.tag == "Killzone")
        {
            health = 0;
        }

        // Damages the player if they collide with an enemy
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }

        // Damages the player if they collide with an enemy's attack
        if (collision.gameObject.tag == "EnemyAttack")
        {
            health -= 1;
        }
    }
}
