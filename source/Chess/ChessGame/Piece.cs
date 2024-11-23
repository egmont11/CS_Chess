namespace ChessGame;

public class Piece
{
    private string _type;
    private int _team;
    
    public Piece(string type, int team)
    {
        _type = type;
        _team = team;
    }

    public void DrawSelf(int X, int Y)
    {
        
    }

    public bool IsEmpty()
    {
        if (_team == 2){ return false; }
        else return true;
    }
}