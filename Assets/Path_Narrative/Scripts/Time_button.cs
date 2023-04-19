using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Time_button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public static bool backward;

    private bool pointerDown;
    private float downTimer;
    private float requiredHold = 2.0f;


    public UnityEvent onLongClick;

    public Image fill;
    public TextMeshProUGUI text;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            downTimer += Time.deltaTime;
            if (downTimer > requiredHold)
            {
                //if (onLongClick != null)
                //{
                // onLongClick.Invoke();
                //}
                clock_switch();
                reset();
            }
            if (downTimer > requiredHold/9.5)
            {
                fill.fillAmount = downTimer / requiredHold;
            }
        }

    }

    void reset()
    {
        pointerDown = false;
        downTimer = 0;
        fill.fillAmount = downTimer / requiredHold;
    }

    void clock_switch()
    {
        if (!backward)
        {
            backward = true;
            text.text = "Turn Back";
        }
        else if (backward)
        {
            backward = false;
            text.text = "Turn End";
        }


    }
}
