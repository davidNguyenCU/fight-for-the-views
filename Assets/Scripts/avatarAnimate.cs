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
        if(Input.GetKeyDown(KeyCode.W)){
            anim.SetTrigger("Hurt");
        }
        
        if(Input.GetKeyDown(KeyCode.A)){
            anim.SetTrigger("KO");
        }

        if(Input.GetKeyDown(KeyCode.S)){
            anim.SetTrigger("Punch");
        }
        
        anim.SetInteger("PunchTransition", (anim.GetInteger("PunchTransition") + 1) % 3);        
//        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99){
  //          anim.SetTrigger("AnimEnd");
    //    }
    }
}
