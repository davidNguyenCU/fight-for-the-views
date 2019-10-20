using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsChange : MonoBehaviour
{
    public RawImage imageDisplay;
    public RawImage imageDisplay2;
    public RawImage imageDisplay3;

    RawImage heartless1;
    RawImage heartless2;
    RawImage heartless3;
    public Texture image;

    int yeeted = 0;

    // Start is called before the first frame update
    void Start()
    {
        //imageDisplay = GetComponent<RawImage>();
        //imageDisplay.texture = image;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            yeeted++;
        }

        if (yeeted == 1)
        {
            Debug.Log("One down!");
            heartless1 = imageDisplay3.GetComponent<RawImage>();
            heartless1.texture = image;
        }

        if (yeeted == 2)
        {
            Debug.Log("Two down!");
            heartless2 = imageDisplay2.GetComponent<RawImage>();
            heartless2.texture = image;
        }

        if (yeeted == 3)
        {
            Debug.Log("You Dead!");
            heartless3 = imageDisplay.GetComponent<RawImage>();
            heartless3.texture = image;
        }
    }
}
