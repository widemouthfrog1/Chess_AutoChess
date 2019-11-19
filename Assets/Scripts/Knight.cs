using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public int color;
    public override int Color()
    {
        return color;
    }

    public override string Name()
    {
        return "Knight";
    }

    public override List<string> Territory()
    {
        List<string> territory = new List<string>();
        string tilePosition = transform.parent.gameObject.name;
        int tileY = int.Parse("" + tilePosition[1]);
        int tileX = IndexOf(tilePosition[0]);
        Tile tile;
        string tileName;
        for(int i = 0; i < 8; i++)
        {

            //Complicated Maths Explaination

            //tileX + i/4 + i/2 - 2:
            //  tileX: the x position of the piece
            //  i/4: move right if past the center
            //  i/2: move right every second i
            //  -2: start two to the left of the piece

            //tileY + ((i%2)*2-1)*(i < 3 || i > 5 ? 1 : 2):
            //  tileY: the y position of the piece
            //  (i%2)*2-1: alternate between above and below
            //  i < 3 || i > 5 ? 1 : 2: go out two if in the middle, one otherwise
            if (tileX + i / 4 + i / 2 - 2 < 0 
                || tileX + i / 4 + i / 2 - 2 >= letters.Length
                || tileY + ((i % 2) * 2 - 1) * (i < 3 || i > 5 ? 1 : 2) < 0
                || tileY + ((i % 2) * 2 - 1) * (i < 3 || i > 5 ? 1 : 2) >= 8)
            {
                continue;
            }

            tileName = letters[tileX + i/4 + i / 2 - 2] + (tileY + ((i%2)*2-1)*(i < 3 || i > 5 ? 1 : 2));
            territory.Add(tileName);
            tile = board.GetTile(tileName);
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
