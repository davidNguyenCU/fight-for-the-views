using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingPress : MonoBehaviour
{
    Text text;
    public bool recording;
    float waitingTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartBlinking();
    }

    // Update is called once per frame
    void Update()
    {
        if (recording == true)
        {
            waitingTime = 1.0f;
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(waitingTime);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(waitingTime);
                    break;
            }
        }
    }
    
    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
