using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class avatarAnimate : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void triggerHurt(){
        anim.SetTrigger("Hurt");
    }

    public void triggerPunch(){
        float punchRNG = Random.Range(0.0f, 100.0f);
        
        //Debug.Log(punchRNG);
        
        if(punchRNG > 90.0f){
            anim.SetInteger("PunchTransition", 0);
        }else if(punchRNG > 45.0f){
            anim.SetInteger("PunchTransition", 1);
        }else{
            anim.SetInteger("PunchTransition", 2);
        }
        anim.SetTrigger("Punch");
    }

    public void triggerKO(){
        anim.SetBool("Dead", true);
        anim.SetTrigger("KO");
    }
}
