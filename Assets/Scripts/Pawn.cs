using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override string Name()
    {
        return "Pawn";
    }

    public override List<string> Territory()
    {
        List<string> territory = new List<string>();
        string tilePosition = transform.parent.gameObject.name;
        int leftIndex = IndexOf(tilePosition[0]) - 1;
        int rightIndex = IndexOf(tilePosition[0]) + 1;
        int topIndex = int.Parse("" + tilePosition[1]) + (color*2 - 1);
        //no need to check top index as a pawn should always be between rows 2 and 7 on a chess board
        if(leftIndex >= 0)
        {
            territory.Add(letters[leftIndex] + topIndex);
        }
        //TODO: refactor to use general bounds instead of 7
        if(rightIndex < 7)
        {
            territory.Add(letters[rightIndex] + topIndex);
        }
        return territory;
    }

    public override List<string> ValidMoves()
    {
        //TODO: En Passant, Absolute Pin
        List<string> validMoves = new List<string>();
        
        //Attacking diagonally
        List<string> territory = Territory();
        Tile tile;
        for (int i = 0; i < territory.Count; i++)
        {
            tile = board.GetTile(territory[i]);
            foreach(Transform piece in tile.gameObject.transform)
            {
                if(piece.gameObject.GetComponent<Piece>().color != color)
                {
                    validMoves.Add(territory[i]);
                }
            }
        }

        //Moving forward
        string tilePosition = transform.parent.gameObject.name;
        int rowIndex = int.Parse("" + tilePosition[1]) + color * 2 - 1; //pawn is never on last row
        int colIndex = IndexOf(tilePosition[0]);
        string tileName = letters[colIndex] + rowIndex;
        tile = board.GetTile(tileName);
        if(tile.transform.childCount == 0) //if the tile above the tile this pawn is on is empty
        {
            validMoves.Add(tileName);
        }

        return validMoves;
    }
}
