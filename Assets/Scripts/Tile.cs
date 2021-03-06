﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum STATE {INACTIVE, SELECTED, HIGHLIGHT, HIGHLIGHTPIECE}
    public STATE state;
    private Color color;
    private bool first = true;
    private bool whiteTerritory;
    private bool blackTerritory;
    // Start is called before the first frame update
    void Start()
    {
        state = STATE.INACTIVE;
    }

    // Update is called once per frame
    void Update()
    {
        
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        if (first)
        {
            color = r.color;
            first = false;
        }
        if (state == STATE.SELECTED)
        {
            r.color = new Color(color.r - 0.2f, color.g + 0.2f, color.b);
        }

        if (state == STATE.INACTIVE)
        {
            r.color = new Color(color.r, color.g, color.b);
        }
    }

    public void ResetTerritory()
    {
        whiteTerritory = false;
        blackTerritory = false;
    }

    public void SetTerritory(bool white)
    {
        if (white)
        {
            whiteTerritory = true;
        }
        else
        {
            blackTerritory = true;
        }
    }

    public bool IsWhiteTerritory()
    {
        return whiteTerritory;
    }

    public bool IsBlackTerritory()
    {
        return blackTerritory;
    }
}
