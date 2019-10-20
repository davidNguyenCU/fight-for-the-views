using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript5 : MonoBehaviour
{

    public int health;
    public Image healthImage1, healthImage2, healthImage3, healthImage4, healthImage5;
    public Sprite heartFull, heartEmpty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthImage1.sprite = heartEmpty;
        healthImage2.sprite = heartEmpty;
        healthImage3.sprite = heartEmpty;
        healthImage4.sprite = heartEmpty;
        healthImage5.sprite = heartEmpty;
        

        if(health >= 1) { healthImage1.sprite = heartFull; }
        if(health >= 2) { healthImage2.sprite = heartFull; }
        if(health >= 3) { healthImage3.sprite = heartFull; }
        if(health >= 4) { healthImage4.sprite = heartFull; }
        if(health >= 5) { healthImage5.sprite = heartFull; }
    }
}
