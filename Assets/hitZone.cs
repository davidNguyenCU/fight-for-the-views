using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitZone : MonoBehaviour
{
    //Make sure to assign this in the Inspector window
    Collider m_Collider;
    Vector3 m_Point;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Collider from the GameObject this script is attached to
        m_Collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if ((other.GetComponent<Rigidbody>().position.y <= 0)
                && (other.GetComponent<Rigidbody>().position.y > -12)
                && (other.GetComponent<arrow>().direction == "down"))
            {
                print("Hit!");
                gameManagerA.comboCount++;
                gameManagerA.changePhase();
                other.GetComponent<arrow>().despawn(false);
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "down")
                {
                    print("Partial Hit");
                    gameManagerA.comboCount++;
                    gameManagerA.changePhase();
                }
                else
                {
                    gameManagerA.comboCount = -1;
                    gameManagerA.changePhase();
                }
                    
                other.GetComponent<arrow>().despawn(false);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if ((other.GetComponent<Rigidbody>().position.y <= 0)
                && (other.GetComponent<Rigidbody>().position.y > -12)
                && (other.GetComponent<arrow>().direction == "up"))
            {
                print("Hit!");
                gameManagerA.comboCount++;
                gameManagerA.changePhase();
                other.GetComponent<arrow>().despawn(false);
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "up")
                {
                    print("Partial Hit");
                    gameManagerA.comboCount++;
                    gameManagerA.changePhase();
                }
                else
                {
                    gameManagerA.comboCount = -1;
                    gameManagerA.changePhase();
                }
                other.GetComponent<arrow>().despawn(false);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if ((other.GetComponent<Rigidbody>().position.y <= 0)
                && (other.GetComponent<Rigidbody>().position.y > -12)
                && (other.GetComponent<arrow>().direction == "left"))
            {
                print("Hit!");
                gameManagerA.comboCount++;
                gameManagerA.changePhase();
                other.GetComponent<arrow>().despawn(false);

            }
            else
            {
                if (other.GetComponent<arrow>().direction == "left")
                {
                    print("Partial Hit");
                    gameManagerA.comboCount++;
                    gameManagerA.changePhase();
                }
                else
                {
                    gameManagerA.comboCount = -1;
                    gameManagerA.changePhase();
                }
                other.GetComponent<arrow>().despawn(false);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if ((other.GetComponent<Rigidbody>().position.y <= 0)
                && (other.GetComponent<Rigidbody>().position.y > -12)
                && (other.GetComponent<arrow>().direction == "right"))
            {
                print("Hit!");
                gameManagerA.comboCount++;
                gameManagerA.changePhase();
                other.GetComponent<arrow>().despawn(false);

            }
            else
            {
                if (other.GetComponent<arrow>().direction == "right")
                {
                    print("Partial Hit");
                    gameManagerA.comboCount++;
                    gameManagerA.changePhase();
                }
                else
                {
                    gameManagerA.comboCount = -1;
                    gameManagerA.changePhase();
                }
                other.GetComponent<arrow>().despawn(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManagerA.comboCount = -1;
        gameManagerA.changePhase();
        other.GetComponent<arrow>().despawn(true);
    }
}