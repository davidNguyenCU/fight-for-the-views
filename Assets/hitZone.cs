using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitZone : MonoBehaviour
{
    //Make sure to assign this in the Inspector window
    Collider m_Collider;
    Vector3 m_Point;
    public gameManagerA gm;
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
                hit();
                other.GetComponent<arrow>().despawn(false);
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "down")
                {
                    partialHit();
                }
                else
                {
                    miss();
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
                hit();
                other.GetComponent<arrow>().despawn(false);
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "up")
                {
                    partialHit();
                }
                else
                {
                    miss();
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
                hit();
                other.GetComponent<arrow>().despawn(false);
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "left")
                {
                    partialHit();
                }
                else
                {
                    miss();
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
                hit();
                other.GetComponent<arrow>().despawn(false);                
            }
            else
            {
                if (other.GetComponent<arrow>().direction == "right")
                {
                    partialHit();
                }
                else
                {
                    miss();
                }
                other.GetComponent<arrow>().despawn(false);
            }
        }
    }

    void hit(){
        gm.hit();
    }

    void partialHit(){
        gm.partialHit();
    }

    void miss(){
        gm.miss();
    }

    private void OnTriggerExit(Collider other)
    {
        miss();
        other.GetComponent<arrow>().despawn(true);
    }
}