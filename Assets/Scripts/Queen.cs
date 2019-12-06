using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{

    public override string Name()
    {
        return "Queen";
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
        for (int i = 1; tileY + i < 8; i++)
        {
            tileName = letters[tileX] + (tileY + i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //down
        for (int i = 1; tileY - i >= 0; i++)
        {
            tileName = letters[tileX] + (tileY - i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
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
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //right
        for (int i = 1; tileX + i < letters.Length; i++)
        {
            tileName = letters[tileX + i] + tileY;
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //up-right
        for (int i = 1; tileY + i < 8 && tileX + i <= 8; i++)
        {
            tileName = letters[tileX + i] + (tileY + i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //up-left
        for (int i = 1; tileY + i < 8 && tileX - i > 0; i++)
        {
            tileName = letters[tileX - i] + (tileY + i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //down-right
        for (int i = 1; tileY - i < 0 && tileX + i >= 8; i++)
        {
            tileName = letters[tileX + i] + (tileY - i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        //down-left
        for (int i = 1; tileY - i < 0 && tileX + i < 0; i++)
        {
            tileName = letters[tileX + i] + (tileY - i);
            territory.Add(tileName);
            Debug.Log(Name() + " " + tileName);
            tile = board.GetTile(tileName);
            if (tile.gameObject.transform.childCount == 1)
            {
                break;
            }
        }
        return territory;
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
