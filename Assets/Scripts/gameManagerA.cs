using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerA : MonoBehaviour
{

    int playerHealth = 2;
    int enemyHealth = 4;

    int enemyHealthMax = 5;
    int playerHealthMax = 3;

    public avatarAnimate av1;
    public HealthScript3 playerHealthManager;
    public HealthScript5 enemyHealthManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            enemyHealth--;
            playerHealth--;
            if(enemyHealth > 0){
                av1.triggerHurt();
            }else{
                av1.triggerKO();
            } 
        }
        

        if(Input.GetKeyDown(KeyCode.A)){
            enemyHealth++;
            playerHealth++;            
            av1.triggerPunch();
        }

        if(playerHealth > playerHealthMax) playerHealth = playerHealthMax;
        if(enemyHealth > enemyHealthMax) enemyHealth = enemyHealthMax;
        

        playerHealthManager.health = playerHealth;
        enemyHealthManager.health = enemyHealth;
    }
}
