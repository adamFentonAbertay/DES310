using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer_manager : MonoBehaviour
{
    static public int players_number = 4;

    public static int turn_timer = 0;
    public static int maxturn_timer = 20;
    public static bool first_time = true;

    public TextMeshProUGUI timer_text;

    public static bool player_ui = false;
    public Canvas player_canv;
    // Start is called before the first frame update
    void Start()
    {
        if (first_time)
        {
            maxturn_timer = 20 *players_number;
            turn_timer = maxturn_timer ;
            first_time = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer_text.text = turn_timer.ToString();
    }

    public  void turn_end()
    {
        if (Time_button.first_time)
        {

            playerui_switch();
        } 
        else
        {
            if (!Time_button.backward)
            {
                if (turn_timer > 0)
                {
                    turn_timer--;
                    Debug.Log("timer :" + turn_timer);
                }
            }
            else if (Time_button.backward)
            {
                if (turn_timer < maxturn_timer)
                {
                    turn_timer++;
                    Debug.Log("timer :" + turn_timer);
                }
            }
        }
    }

    public static void reset()
    {
        maxturn_timer = 20 * players_number;
        turn_timer = maxturn_timer;
    }
    public void Set_playernumber(int number)
    {
        if (Time_button.first_time)
        {
            Time_button.first_time = false;
        }
        players_number = number;
        reset();
        playerui_switch();
    }

    public void playerui_switch()
    {
        if (player_ui)
        {
            player_canv.gameObject.SetActive(false);
            player_ui = false;
        }
        else
        {
            player_canv.gameObject.SetActive(true);
            player_ui = true;
        }
    }
}
