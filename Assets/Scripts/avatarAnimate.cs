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
            anim.SetBool("Dead", true);
        }

        if(Input.GetKeyDown(KeyCode.S)){
            anim.SetTrigger("Punch");
        }
        
        if(Input.GetKeyDown(KeyCode.D)){
            anim.SetBool("Dead", false);
        }

        //anim.SetInteger("PunchTransition", (anim.GetInteger("PunchTransition") + 1) % 3);

        anim.SetInteger("PunchTransition", 0);

        anim.SetBool("PunchUp", false);
        if(Time.frameCount % 30 == 0){
            anim.SetBool("PunchUp", true);
        }
    }
}
