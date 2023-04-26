using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class button_hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    private bool pointerDown;
    private float downTimer;
    private float requiredHold = 1.5f;


    public UnityEvent onLongClick;

    public Image fill;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        reset();
    }

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
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                reset();
            }
            if (downTimer > requiredHold / 9.5)
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
}