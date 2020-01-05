using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{

    public override string Name()
    {
        return "King";
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
        if (tileY + 1 <= 8)
        {
            tileName = letters[tileX] + (tileY + 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //down
        if (tileY - 1 > 0)
        {
            tileName = letters[tileX] + (tileY - 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //left
        if (tileX - 1 >= 0)
        {
            tileName = letters[tileX - 1] + tileY;
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //right
        if (tileX + 1 < 8)
        {
            tileName = letters[tileX + 1] + tileY;
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //up-right
        if (tileX + 1 < 8 && tileY + 1 <= 8)
        {
            tileName = letters[tileX + 1] + (tileY + 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //up-left
        if (tileX - 1 >= 0 && tileY + 1 <= 8)
        {
            tileName = letters[tileX - 1] + (tileY + 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //down-right
        if (tileX + 1 < 8 && tileY - 1 > 0)
        {
            tileName = letters[tileX + 1] + (tileY - 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }
        //down-left
        if (tileX - 1 >= 0 && tileY - 1 > 0)
        {
            tileName = letters[tileX - 1] + (tileY - 1);
            territory.Add(tileName);
            tile = board.GetTile(tileName);
        }

        return territory;
    }

    public override List<string> ValidMoves()
    {
        List<string> validMoves = new List<string>();
        List<string> territory = Territory();
        Tile tile;
        for (int i = 0; i < territory.Count; i++)
        {
            tile = board.GetTile(territory[i]);
            if(color == 1) //if this king is white
            {
                if (tile.IsBlackTerritory())
                {
                    continue; //not a valid move so continue
                }
            }
            else
            {
                if (tile.IsWhiteTerritory())
                {
                    continue;
                }
            }
            foreach (Transform piece in tile.gameObject.transform)
            {
                if (piece.gameObject.GetComponent<Piece>().color != color)
                {
                    validMoves.Add(territory[i]);
                }
            }
            if (tile.gameObject.transform.childCount == 0)
            {
                validMoves.Add(territory[i]);
            }
        }
        return validMoves;
    }

    public override int Worth()
    {
        return 200;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
