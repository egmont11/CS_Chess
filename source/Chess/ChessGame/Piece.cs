using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame;

public class Piece
{
    private string _type;
    private int _team;

    private Texture2D _texture;
    private Vector2 _vector2;
    
    private Vector2 _vector2Offset;

    private Rectangle _pieceRectangle;
    
    public Piece(string type, int team, Vector2 vector2, Texture2D texture)
    {
        _type = type;
        _team = team;
        _vector2 = vector2;
        _texture = texture;
        
        _vector2Offset = _vector2 - new Vector2(_texture.Width / 2, _texture.Height / 2);
        
        _pieceRectangle = new Rectangle((int)_vector2Offset.X, (int)_vector2Offset.Y, _texture.Width, _texture.Height);
    }
    
    public void DrawSelf(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _vector2Offset, Color.White);
    }

    public bool IsEmpty()
    {
        if (_team == 2) { return false; }
        else return true;
    }

    public void replacePiece(Piece toReplacePiece)
    {
        _vector2 = toReplacePiece.getVector2();
        
        _vector2Offset = _vector2 - new Vector2(_texture.Width / 2, _texture.Height / 2);
        _pieceRectangle = new Rectangle((int)_vector2Offset.X, (int)_vector2Offset.Y, _texture.Width, _texture.Height);
    }

    public Vector2 getVector2()
    {
        return _vector2;
    }

    public bool ClickedOn(int x, int y)
    {
        
        if (_pieceRectangle.Contains(new Vector2(x, y)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}