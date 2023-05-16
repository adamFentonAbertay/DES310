using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPageScript : MonoBehaviour
{
    public GameObject ShopSymbol;
    public GameObject TradeExample;
    public GameObject CrabBoss;
    public GameObject TradeDiagram;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShopSymbol()
    {
        if (ShopSymbol.activeSelf)
        {
            ShopSymbol.SetActive(false);
        }
        else
        {
            ShopSymbol.SetActive(true);
        }
    }

    public void ToggleTradeExample()
    {
        if (TradeExample.activeSelf)
        {
            TradeExample.SetActive(false);
        }
        else
        {
            TradeExample.SetActive(true);
        }
    }

    public void ToggleCrabBoss()
    {
        if (CrabBoss.activeSelf)
        {
            CrabBoss.SetActive(false);
        }
        else
        {
            CrabBoss.SetActive(true);
        }
    }

    public void ToggleTradeDiagram()
    {
        if (TradeDiagram.activeSelf)
        {
            TradeDiagram.SetActive(false);
        }
        else
        {
            TradeDiagram.SetActive(true);
        }
    }
}
