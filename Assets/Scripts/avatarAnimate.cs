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

        //anim.Play("PunchLeft");
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95){
            anim.SetTrigger("AnimEnd");
        }
        //anim.Play("PunchLeft");
        
        //anim.Play("PunchRight");
        

    }
}
