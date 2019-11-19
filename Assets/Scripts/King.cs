using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public int color;
    public override int Color()
    {
        return color;
    }

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
        tileName = letters[tileX] + (tileY + 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //down
        tileName = letters[tileX] + (tileY - 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //left
        tileName = letters[tileX - 1] + tileY;
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //right
        tileName = letters[tileX + 1] + tileY;
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //up-right
        tileName = letters[tileX + 1] + (tileY + 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //up-left
        tileName = letters[tileX - 1] + (tileY + 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //down-right
        tileName = letters[tileX + 1] + (tileY - 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);
        //down-left
        tileName = letters[tileX + 1] + (tileY - 1);
        territory.Add(tileName);
        tile = board.GetTile(tileName);

        return territory;
    }

    public override List<string> ValidMoves()
    {
        throw new System.NotImplementedException();
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
