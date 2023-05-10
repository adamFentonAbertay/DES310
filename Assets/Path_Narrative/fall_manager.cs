using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public int stop_number, shak_number, fall_number;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("timer", Fullmap_manager.turn_timer);

        if (Fullmap_manager.turn_timer <= shak_number && Fullmap_manager.turn_timer > fall_number)
        {
            animator.SetTrigger("shak");
        }
        if (Fullmap_manager.turn_timer <= fall_number)
        {
            animator.SetTrigger("fall");
        }

        if (Fullmap_manager.turn_timer > stop_number)
        {
            animator.SetTrigger("normal");
        }
        }
}
