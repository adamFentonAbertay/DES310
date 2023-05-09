using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("timer", Fullmap_manager.turn_timer);

        if (Fullmap_manager.turn_timer <=65 && Fullmap_manager.turn_timer > 60)
        {
            animator.SetTrigger("shak");
        }
        if (Fullmap_manager.turn_timer <= 60)
        {
            animator.SetTrigger("fall");
        }
    }
}
