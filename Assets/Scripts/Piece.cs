using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    protected Board board;
    protected string[] letters;
    public int color;
    public abstract List<string> Territory();
    public virtual List<string> ValidMoves()
    {
        //TODO: Absolute Pin
        List<string> validMoves = new List<string>();
        List<string> territory = Territory();
        Tile tile;
        for (int i = 0; i < territory.Count; i++)
        {
            tile = board.GetTile(territory[i]);
            foreach (Transform piece in tile.gameObject.transform)
            {
                if (piece.gameObject.GetComponent<Piece>().color != color)
                {
                    validMoves.Add(territory[i]);
                }
            }
            if(tile.gameObject.transform.childCount == 0)
            {
                validMoves.Add(territory[i]);
            }
        }
        return validMoves;
    }
    public virtual void Move(string position)
    {
        bool positionIsValid = false;
        foreach(string p in ValidMoves())
        {
            if (p.Equals(position))
            {
                positionIsValid = true;
            }
        }
        if (positionIsValid)
        {
            int i = IndexOf(position[0]);
            transform.parent = board.board[i][int.Parse("" + position[1]) - 1].transform;
        }
        transform.localPosition = new Vector3(0, 0, 0);
    }
    public abstract string Name();
    public void SetBoard(Board board)
    {
        this.board = board;
        letters = board.Letters();
    }
    protected int IndexOf(char letter)
    {
        int i = 0;
        for (; i < letters.Length; i++)
        {
            if (letters[i].Equals("" + letter))
            {
                break;
            }
        }
        return i;
    }

}
