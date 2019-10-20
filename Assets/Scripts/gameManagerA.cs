using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerA : MonoBehaviour
{
    //1 = Attacking
    //2 = Damaging
    //3 = Blocking
    //4 = Parrying
    int state = 1;

    int comboCount = 0;

    public float spawnInterval;

    int enemyHealth = 5;
    int playerHealth = 3;

    int enemyHealthMax = 5;
    int playerHealthMax = 3;

    bool gameEnd = false;
    float timeUntilEndCard = 3;

    public GameObject toSpawn;
    public GameObject viewerInstance;

    public avatarAnimate av1;
    public HealthScript3 playerHealthManager;
    public HealthScript5 enemyHealthManager;
    public StateImageManager stateImgManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnArrow", 2.0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
        if( gameEnd && enemyHealth <= 0 ){
            if( timeUntilEndCard <= 0 ){
                SceneManager.LoadScene("EndCardWin");
            }else{
                timeUntilEndCard -= Time.deltaTime;
            }

            return;
        }

        if (gameEnd && playerHealth <= 0)
        {
            if (timeUntilEndCard <= 0){
                SceneManager.LoadScene("EndCardLose");
            }
            else
            {
                timeUntilEndCard -= Time.deltaTime;
            }

            return;
        }

        if (playerHealth <= 0)
        {
            gameEnd = true;
        }

        if(enemyHealth <= 0){
            gameEnd = true;
            av1.triggerKO();
        }

        if(playerHealth > playerHealthMax) playerHealth = playerHealthMax;
        if(enemyHealth > enemyHealthMax) enemyHealth = enemyHealthMax;
        

        playerHealthManager.health = playerHealth;
        enemyHealthManager.health = enemyHealth;
    }

    public void hit(){
        comboCount++;
        changePhase();
    }
    public void partialHit(){
        comboCount++;
        changePhase();
    }
    public void miss(){
        comboCount = -1;
        changePhase();
    }


    public void changePhase()
    {
        if(gameEnd){
            return;
        }
        if (comboCount != -1)
        {
            spawnViewer();
        }

        if (state == 1)//Attacking
        {
            av1.triggerBlock();
            if (comboCount % 5 == 0)
            {
                state = 2; //Transition to Damaging
                stateImgManager.setDamage();
            }
            if (comboCount == -1)
            {
                state = 3; //Transition to Blocking
                stateImgManager.setBlock();
            }
        }

        else if (state == 2)//Damaging
        {
            av1.triggerBlock();
            if (comboCount % 5 == 0)
            {
                enemyHealth -= 1;
                av1.triggerHurt();
                state = 1;
                stateImgManager.setAttack();
            }
            if (comboCount == -1)
            {
                state = 3; //Transition to Blocking
                stateImgManager.setBlock();
            }
        }

        else if (state == 3)//Blocking
        {
            av1.triggerPunch();
            if (comboCount % 5 == 0)
            {
                state = 4; //Transition to parrying
                stateImgManager.setParry();
            }
            if (comboCount == -1)
            {
                comboCount = 0;
                playerHealth -= 1;
            }
        }

        else if (state == 4) //Parrying
        {
            av1.triggerPunch();
            if (comboCount % 5 == 0)
            {
                state = 1; //Transition to attack
                stateImgManager.setAttack(); 
            }
            if (comboCount == -1)
            {
                state = 3; //Transition back to blocking
                stateImgManager.setBlock(); 
            }
        }

        
    }

    void spawnViewer()
    {
        Instantiate(viewerInstance, new Vector3(Random.Range(-91.8f, -27.1f), Random.Range(21.0f, 154.5f), -300), Quaternion.identity);
    }

    void spawnArrow()
    {
        Instantiate(toSpawn, new Vector3(-100, 144, 200), Quaternion.AngleAxis(90, Vector3.up));
        /*
        print(comboCount);
        if (state == 1)
            print("Attacking");

        if (state == 2)
            print("Damaging");

        if (state == 3)
            print("Blocking");

        if (state == 4)
            print("Parrying");
            */
    }
}
