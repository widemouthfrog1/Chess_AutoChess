using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject[][] board;
    

    [SerializeField]
    private int width = 8;
    [SerializeField]
    private int height = 8;
    [SerializeField]
    private float size = 1;

    [SerializeField]
    private Sprite square = null;
    [SerializeField]
    private Sprite whitePawn = null;
    [SerializeField]
    private Sprite blackPawn = null;
    [SerializeField]
    private Sprite whiteRook = null;
    [SerializeField]
    private Sprite blackRook = null;
    [SerializeField]
    private Sprite whiteKnight = null;
    [SerializeField]
    private Sprite blackKnight = null;
    [SerializeField]
    private Sprite whiteBishop = null;
    [SerializeField]
    private Sprite blackBishop = null;
    [SerializeField]
    private Sprite whiteQueen = null;
    [SerializeField]
    private Sprite blackQueen = null;
    [SerializeField]
    private Sprite whiteKing = null;
    [SerializeField]
    private Sprite blackKing = null;

    [SerializeField]
    private GameObject graveyard;

    private string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private Tile selectedTile = null;
    private List<Piece> piecesOnBoard = new List<Piece>();
    private List<Piece> takenPieces = new List<Piece>();

    // Start is called before the first frame update
    void Start()
    {
        
        board = new GameObject[width][];
        for(int x = 0; x < board.Length; x++)
        {
            board[x] = new GameObject[height];
            for (int y = 0; y < board[x].Length; y++)
            {
                board[x][y] = new GameObject();
                GameObject o = board[x][y];
                o.name = letters[x] + (y + 1);
                o.transform.parent = transform;
                o.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                o.AddComponent<SpriteRenderer>();
                o.AddComponent<Tile>();
                SpriteRenderer r = o.GetComponent<SpriteRenderer>();
                r.sprite = square;
                if((x + y) % 2 == 0)
                {
                    r.color = new Color(0.6f, 0.3f, 0);
                }
                else
                {
                    r.color = new Color(1, 0.6f, 0.3f);
                }
                
                if(y == 1 || y == 6)
                {
                    GameObject p = new GameObject {name = "Pawn"};
                    p.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                    p.transform.localScale = new Vector2(0.1f, 0.1f);
                    p.AddComponent<Pawn>();
                    p.AddComponent<SpriteRenderer>();
                    SpriteRenderer pr = p.GetComponent<SpriteRenderer>();
                    if(y > 3)
                    {
                        pr.sprite = GetComponent<Board>().blackPawn;
                    }
                    else
                    {
                        pr.sprite = GetComponent<Board>().whitePawn;
                    }

                    pr.sortingOrder = 1;
                    Pawn pawn = p.GetComponent<Pawn>();
                    pawn.transform.parent = o.transform;
                    pawn.SetBoard(GetComponent<Board>());
                    if (y > 3)
                    {
                        pawn.color = 0;
                    }
                    else
                    {
                        pawn.color = 1;
                    }
                    piecesOnBoard.Add(pawn);
                }
                else
                {
                    if((x == 0 || x == 7) && (y == 0 || y == 7))
                    {
                        GameObject ro = new GameObject { name = "Rook" };
                        ro.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                        ro.transform.localScale = new Vector2(0.1f, 0.1f);
                        ro.AddComponent<Rook>();
                        ro.AddComponent<SpriteRenderer>();
                        SpriteRenderer rr = ro.GetComponent<SpriteRenderer>();
                        if (y > 3)
                        {
                            rr.sprite = GetComponent<Board>().blackRook;
                        }
                        else
                        {
                            rr.sprite = GetComponent<Board>().whiteRook;
                        }

                        rr.sortingOrder = 1;
                        Rook rook = ro.GetComponent<Rook>();
                        rook.transform.parent = o.transform;
                        rook.SetBoard(GetComponent<Board>());
                        if (y > 3)
                        {
                            rook.color = 0;
                        }
                        else
                        {
                            rook.color = 1;
                        }
                        piecesOnBoard.Add(rook);
                    }
                    if ((x == 1 || x == 6) && (y == 0 || y == 7))
                    {
                        GameObject kn = new GameObject { name = "Knight" };
                        kn.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                        kn.transform.localScale = new Vector2(0.1f, 0.1f);
                        kn.AddComponent<Knight>();
                        kn.AddComponent<SpriteRenderer>();
                        SpriteRenderer knr = kn.GetComponent<SpriteRenderer>();
                        if (y > 3)
                        {
                            knr.sprite =  GetComponent<Board>().blackKnight;
                        }
                        else
                        {
                            knr.sprite =  GetComponent<Board>().whiteKnight;
                        }

                        knr.sortingOrder = 1;
                        Knight knight = kn.GetComponent<Knight>();
                        knight.transform.parent = o.transform;
                        knight.SetBoard(GetComponent<Board>());
                        if (y > 3)
                        {
                            knight.color = 0;
                        }
                        else
                        {
                            knight.color = 1;
                        }
                        piecesOnBoard.Add(knight);
                    }
                    if ((x == 2 || x == 5) && (y == 0 || y == 7))
                    {
                        GameObject b = new GameObject { name = "Bishop" };
                        b.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                        b.transform.localScale = new Vector2(0.1f, 0.1f);
                        b.AddComponent<Bishop>();
                        b.AddComponent<SpriteRenderer>();
                        SpriteRenderer br = b.GetComponent<SpriteRenderer>();
                        if (y > 3)
                        {
                            br.sprite =  GetComponent<Board>().blackBishop;
                        }
                        else
                        {
                            br.sprite =  GetComponent<Board>().whiteBishop;
                        }

                        br.sortingOrder = 1;
                        Bishop bishop = b.GetComponent<Bishop>();
                        bishop.transform.parent = o.transform;
                        bishop.SetBoard(GetComponent<Board>());
                        if (y > 3)
                        {
                            bishop.color = 0;
                        }
                        else
                        {
                            bishop.color = 1;
                        }
                        piecesOnBoard.Add(bishop);
                    }
                    if ((x == 3) && (y == 0 || y == 7))
                    {
                        GameObject q = new GameObject { name = "Queen" };
                        q.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                        q.transform.localScale = new Vector2(0.1f, 0.1f);
                        q.AddComponent<Queen>();
                        q.AddComponent<SpriteRenderer>();
                        SpriteRenderer qr = q.GetComponent<SpriteRenderer>();
                        if (y > 3)
                        {
                            qr.sprite =  GetComponent<Board>().blackQueen;
                        }
                        else
                        {
                            qr.sprite =  GetComponent<Board>().whiteQueen;
                        }

                        qr.sortingOrder = 1;
                        Queen queen = q.GetComponent<Queen>();
                        queen.transform.parent = o.transform;
                        queen.SetBoard(GetComponent<Board>());
                        if (y > 3)
                        {
                            queen.color = 0;
                        }
                        else
                        {
                            queen.color = 1;
                        }
                        piecesOnBoard.Add(queen);
                    }
                    if ((x == 4) && (y == 0 || y == 7))
                    {
                        GameObject k = new GameObject { name = "King" };
                        k.transform.position = new Vector2(transform.position.x + x * size, transform.position.y + y * size);
                        k.transform.localScale = new Vector2(0.1f, 0.1f);
                        k.AddComponent<King>();
                        k.AddComponent<SpriteRenderer>();
                        SpriteRenderer kr = k.GetComponent<SpriteRenderer>();
                        if (y > 3)
                        {
                            kr.sprite =  GetComponent<Board>().blackKing;
                        }
                        else
                        {
                            kr.sprite =  GetComponent<Board>().whiteKing;
                        }

                        kr.sortingOrder = 1;
                        King king = k.GetComponent<King>();
                        king.transform.parent = o.transform;
                        king.SetBoard(GetComponent<Board>());
                        if (y > 3)
                        {
                            king.color = 0;
                        }
                        else
                        {
                            king.color = 1;
                        }
                        piecesOnBoard.Add(king);
                    }
                }
            }
        }
        
        /*foreach (Transform piece in board[4][1].transform)
        {
            piece.gameObject.GetComponent<Piece>().Move("E4");
        }*/

        foreach (Piece piece in piecesOnBoard)
        {
            Debug.Log(piece.Name());
            foreach (string tileName in piece.Territory())
            {
                Debug.Log(tileName);
                Tile tile = GetTile(tileName);
                tile.SetTerritory(piece.color == 1); //color equals white
            }
        }
    }

    public Tile GetTile(string tileName)
    {
        return board[IndexOf(tileName[0])][int.Parse("" + tileName[1]) - 1].GetComponent<Tile>();
    }

    private Tile GetTile(int col, int row)
    {
        return board[col][row].GetComponent<Tile>();
    }

    private GameObject GetTileObject(Vector3 mousePosition)
    {
        int x;
        int y;
        if(mousePosition.x > 0)
        {
            x = (int)(mousePosition.x - 0.1) + 4;
        }
        else
        {
            x = (int)(mousePosition.x - 0.1) + 3;
        }
        if (mousePosition.y > 0)
        {
            y = (int)(mousePosition.y - 0.1) + 4;
        }
        else
        {
            y = (int)(mousePosition.y - 0.1) + 3;
        }
        //TODO: Make work with any board size
        if(x < 0 || x > 7 || y < 0 || y > 7)
        {
            return null;
        }
        return board[x][y];
    }

    void SelectTile(Tile tile)
    {
        if (selectedTile != null)
        {
            selectedTile.state = Tile.STATE.INACTIVE;
        }
        tile.state = Tile.STATE.SELECTED;
        selectedTile = tile;
    }

    void DeselectTile()
    {
        if (selectedTile != null)
        {
            selectedTile.state = Tile.STATE.INACTIVE;
            selectedTile = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Tile tile = GetTileObject(mousePosition).GetComponent<Tile>();
            if (tile != null)
            {
                if (tile.transform.childCount == 1)
                {
                    SelectTile(tile);
                }
                else
                {
                    DeselectTile();
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (selectedTile != null)
            {
                foreach (Transform piece in selectedTile.transform)
                {
                    piece.position = new Vector2(mousePosition.x, mousePosition.y);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Tile tile = GetTileObject(mousePosition).GetComponent<Tile>();
            if(tile != null && selectedTile != null)
            {
                if (!tile.gameObject.name.Equals(selectedTile.gameObject.name))
                {
                    foreach (Transform piece in selectedTile.gameObject.transform)
                    {
                        Piece taken = piece.gameObject.GetComponent<Piece>().Move(tile.gameObject.name);
                        if(taken != null)
                        {
                            piecesOnBoard.Remove(taken);
                            takenPieces.Add(taken);
                            foreach(Transform child in tile.gameObject.transform)
                            {
                                if (child.gameObject.GetComponent<Piece>().Equals(taken))
                                {
                                    child.parent = graveyard.transform;
                                    child.localPosition = new Vector2(0, 0);
                                }
                            }
                        }
                        DeselectTile();
                    }
                }
            }
            if (selectedTile != null && (tile == null|| tile.gameObject.name.Equals(selectedTile.gameObject.name)))
            {
                foreach (Transform piece in selectedTile.gameObject.transform)
                {
                    piece.localPosition = new Vector2(0, 0);
                }
            }

        }
    }

    public string[] Letters()
    {
        return letters;
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
