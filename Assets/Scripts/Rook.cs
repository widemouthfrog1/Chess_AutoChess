﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{

    public override string Name()
    {
        return "Rook";
    }

    public override List<string> Territory()
    {
        List<string> territory = new List<string>();
        string tilePosition = transform.parent.gameObject.name;
        int tileY = int.Parse("" + tilePosition[1]);
        int tileX = IndexOf(tilePosition[0]);
        Tile tile;
        string tileName;
        //up
        for(int i = 1; tileY + i <= 8; i++)
        {
            tileName = letters[tileX] + (tileY + i);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //down
        for (int i = 1; tileY - i >= 1; i++)
        {
            tileName = letters[tileX] + (tileY - i);
            territory.Add(tileName);
            tile = board.GetTile(tileName);

            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //left
        for (int i = 1; tileX - i >= 0; i++)
        {
            tileName = letters[tileX - i] + tileY;
            territory.Add(tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //right
        for (int i = 1; tileX + i < 8; i++)
        {
            tileName = letters[tileX + i] + tileY;
            territory.Add(tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        
        return territory;
    }

    public override int Worth()
    {
        return 5;
    }

    //TODO: Valid Moves Castle

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
