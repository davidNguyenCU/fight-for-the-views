using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateImageManager : MonoBehaviour
{
    public Image stateImage;
    public Sprite block, parry, attack, damage;

    float stateVisibleTimeMax = 1;
    float stateVisibleTime;

    // Start is called before the first frame update
    void Start()
    {
        setAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateVisibleTime > 0){
            stateVisibleTime -= Time.deltaTime;
            Color c = stateImage.color;
            c.a = (stateVisibleTime/stateVisibleTimeMax);
            stateImage.color = c;
        }
    }

    public void setBlock(){
        stateImage.sprite = block;
        stateVisibleTime = stateVisibleTimeMax;
    }
    public void setDamage(){
        stateImage.sprite = damage;
        stateVisibleTime = stateVisibleTimeMax;
    }
    public void setAttack(){
        stateImage.sprite = attack;
        stateVisibleTime = stateVisibleTimeMax;
    }
    public void setParry(){
        stateImage.sprite = parry;
        stateVisibleTime = stateVisibleTimeMax;
    }
}
