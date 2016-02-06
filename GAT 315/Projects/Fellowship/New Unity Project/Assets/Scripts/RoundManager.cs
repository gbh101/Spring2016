using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour
{
    public int roundCounter = 0;
    public GameObject roundVisual;

    public int restPeriod = 1200;
    private int restTimer = 0;

    public int spawnRate = 120;
    private int spawnTimer = 0;
    private int spawnCounter = 0;
    public GameObject[] enemiesArray;

    public GameObject stageHazard1;
    public GameObject stageHazard2;
    public GameObject stageHazard3;

    private bool roundInProgress;

    void Start()
    {
        roundInProgress = false;
    }

    void Update()
    {
        if(roundInProgress)
        {
            if(spawnTimer >= spawnRate)
            {
                if(spawnCounter <= roundCounter)
                {
                    //Instantiate(attackGhost, (gameObject.GetComponent<Transform>().position + (lastMove * attackRange)), Quaternion.identity);
                    spawnCounter++;
                }
                spawnTimer = 0;
            }
            spawnTimer++;
        }
        else
        {
            if(restTimer >= restPeriod)
            {
                RoundStart();
            }
            restTimer++;
        }

        if(Input.GetKeyDown("8"))
        {
            roundCounter += 1;
        }

        if (roundCounter == 3)
        {
            stageHazard1.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
        if (roundCounter == 5)
        {
            stageHazard2.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
        if (roundCounter == 7)
        {
            stageHazard3.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
        if (roundCounter == 11)
        {
            //You Win!
        }
        roundVisual.GetComponent<TextMesh>().text = "" + roundCounter;
    }

    void RoundStart()
    {
        roundInProgress = true;
        roundCounter += 1;
        
        if(roundCounter == 3)
        {
            stageHazard1.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
        if(roundCounter == 5)
        {
            stageHazard2.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
        if (roundCounter == 7)
        {
            stageHazard3.GetComponent<Transform>().position = new Vector3(0, -5000, 0);
        }
    }

    void RoundEnd()
    {
        roundInProgress = false;

        if(roundCounter >= 10)
        {
            //victory
        }
    }
}
