using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_manager : MonoBehaviour
{
    // Start is called before the first frame update
    static public int max_turn, curt_turn;
    public Animator animator;
    public int stop_number, shak_number, fall_number;

    void Start()
    {
       // shak_number = timer_manager.maxturn_timer - (shak_number * timer_manager.players_number);
        //fall_number = timer_manager.maxturn_timer - (fall_number * timer_manager.players_number);
       // stop_number = shak_number;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer_manager.turn_timer <= timer_manager.maxturn_timer - (shak_number * timer_manager.players_number) && timer_manager.turn_timer > timer_manager.maxturn_timer - (fall_number * timer_manager.players_number))
        {
            animator.SetTrigger("shak");
        }
        if (timer_manager.turn_timer <= timer_manager.maxturn_timer - (fall_number * timer_manager.players_number))
        {
            animator.SetTrigger("fall");
        }

        if (timer_manager.turn_timer > timer_manager.maxturn_timer - (shak_number * timer_manager.players_number))
        {
            animator.SetTrigger("normal");
        }
        }
}
