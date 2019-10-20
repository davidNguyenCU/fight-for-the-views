using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerA : MonoBehaviour
{
    //1 = Attacking
    //2 = Damaging
    //3 = Blocking
    //4 = Parrying
    public static int state = 1;

    public static int comboCount = 0;

    public float spawnInterval;

    public static int playerHealth = 3;
    public static int enemyHealth = 1;

    int enemyHealthMax = 5;
    int playerHealthMax = 3;

    bool gameEnd = false;
    float timeUntilEndCard = 3;

    public GameObject toSpawn;

    public avatarAnimate av1;
    public HealthScript3 playerHealthManager;
    public HealthScript5 enemyHealthManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnArrow", 2.0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnd){
            if(timeUntilEndCard <= 0){
                SceneManager.LoadScene("EndCard");
            }else{
                timeUntilEndCard -= Time.deltaTime;
            }

            return;
        }

        if(Input.GetKeyDown(KeyCode.W)){
            enemyHealth--;
            playerHealth--;
            if(enemyHealth > 0){
                av1.triggerHurt();
            }else{
                av1.triggerKO();   
                gameEnd = true;
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


    public static void changePhase()
    {
        if (state == 1)//Attacking
        {
            if (comboCount % 5 == 0)
            {
                state = 2; //Transition to Damaging
            }
            if (comboCount == -1)
            {
                state = 3; //Transition to Blocking
            }
        }

        else if (state == 2)//Damaging
        {
            if (comboCount % 5 == 0)
            {
                enemyHealth -= 1;
                state = 1;
            }
            if (comboCount == -1)
            {
                state = 3; //Transition to Blocking
            }
        }

        else if (state == 3)//Blocking
        {
            if (comboCount % 5 == 0)
            {
                state = 4; //Transition to parrying
            }
            if (comboCount == -1)
            {
                comboCount = 0;
                playerHealth -= 1;
            }
        }

        else if (state == 4) //Parrying
        {
            if (comboCount % 5 == 0)
            {
                state = 1; //Transition to parrying
            }
            if (comboCount == -1)
            {
                state = 3; //Transition back to blocking
            }
        }
    }

    void spawnArrow()
    {
        Instantiate(toSpawn, new Vector3(-100, 144, 200), Quaternion.AngleAxis(90, Vector3.up));
        print(comboCount);
        if (state == 1)
            print("Attacking");

        if (state == 2)
            print("Damaging");

        if (state == 3)
            print("Blocking");

        if (state == 4)
            print("Parrying");
    }
}
