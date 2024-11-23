using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private int _playerTurn;
    
    // Chessboard 8x8
    private Piece[,] ChessBoard;
    
    private KeyboardState _currentKeyboard;

    private Texture2D _kingWhiteTexture;
    private Texture2D _queenWhiteTexture;
    private Texture2D _bishopWhiteTexture;
    private Texture2D _knightWhiteTexture;
    private Texture2D _rookWhiteTexture;
    private Texture2D _pawnWhiteTexture;
    
    private Texture2D _kingBlackTexture;
    private Texture2D _queenBlackTexture;
    private Texture2D _bishopBlackTexture;
    private Texture2D _knightBlackTexture;
    private Texture2D _rookBlackTexture;
    private Texture2D _pawnBlackTexture;

    private Texture2D _emptyTexture;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _playerTurn = 0;    // 0 = white, 1 = black
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _kingWhiteTexture = Content.Load<Texture2D>("kingWhite");
        _queenWhiteTexture = Content.Load<Texture2D>("queenWhite");
        _bishopWhiteTexture = Content.Load<Texture2D>("bishopWhite");
        _knightWhiteTexture = Content.Load<Texture2D>("knightWhite");
        _rookWhiteTexture = Content.Load<Texture2D>("rookWhite");
        _pawnWhiteTexture = Content.Load<Texture2D>("pawnWhite");
        
        _kingBlackTexture = Content.Load<Texture2D>("kingBlack");
        _queenBlackTexture = Content.Load<Texture2D>("queenBlack");
        _bishopBlackTexture = Content.Load<Texture2D>("bishopBlack");
        _knightBlackTexture = Content.Load<Texture2D>("knightBlack");
        _rookBlackTexture = Content.Load<Texture2D>("rookBlack");
        _pawnBlackTexture = Content.Load<Texture2D>("pawnBlack");

        _emptyTexture = new Texture2D(GraphicsDevice, 1, 1);
        
        ChessBoard = new Piece[,] {
            {
                new Piece("Rook", 1, new Vector2(50, 50), _pawnBlackTexture), 
                new Piece("Knight", 1, new Vector2(150, 50), _knightBlackTexture), 
                new Piece("Bishop", 1, new Vector2(250, 50), _bishopBlackTexture), 
                new Piece("King", 1, new Vector2(350, 50), _kingBlackTexture), 
                new Piece("Queen", 1, new Vector2(450, 50), _queenBlackTexture), 
                new Piece("Bishop", 1, new Vector2(550, 50), _bishopBlackTexture), 
                new Piece("Knight", 1, new Vector2(650, 50), _knightBlackTexture), 
                new Piece("Rook", 1, new Vector2(750, 50), _rookBlackTexture)
            },

            {
                new Piece("Pawn", 1, new Vector2(50, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(150, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(250, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(350, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(450, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(550, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(650, 150), _pawnBlackTexture), 
                new Piece("Pawn", 1, new Vector2(750, 150), _pawnBlackTexture)
            },

            {
                new Piece("", 2, new Vector2(50, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(150, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(250, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(350, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(450, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(550, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(650, 250), _emptyTexture), 
                new Piece("", 2, new Vector2(750, 250), _emptyTexture)
            },

            {
                new Piece("", 2, new Vector2(50,350), _emptyTexture), 
                new Piece("", 2, new Vector2(150, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(250, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(350, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(450, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(550, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(650, 350), _emptyTexture), 
                new Piece("", 2, new Vector2(750, 350), _emptyTexture)
            },

            {
                new Piece("", 2, new Vector2(50, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(150, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(250, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(350, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(450, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(550, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(650, 450), _emptyTexture), 
                new Piece("", 2, new Vector2(750, 450), _emptyTexture)
            },

            {
                new Piece("", 2, new Vector2(50, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(150, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(250, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(350, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(450, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(550, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(650, 550), _emptyTexture), 
                new Piece("", 2, new Vector2(750, 550), _emptyTexture)
            },

            {
                new Piece("Pawn", 0, new Vector2(50, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(150, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(250, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(350, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(450, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(550, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(650, 650), _pawnWhiteTexture), 
                new Piece("Pawn", 0, new Vector2(750, 650), _pawnWhiteTexture)
            },

            {
                new Piece("Rook", 0, new Vector2(50, 750), _rookWhiteTexture), 
                new Piece("Knight", 0, new Vector2(150, 750), _knightWhiteTexture), 
                new Piece("Bishop", 0, new Vector2(250, 750), _bishopWhiteTexture), 
                new Piece("King", 0, new Vector2(350, 750), _kingWhiteTexture), 
                new Piece("Queen", 0, new Vector2(450, 750), _queenWhiteTexture), 
                new Piece("Bishop", 0, new Vector2(550, 750), _bishopWhiteTexture), 
                new Piece("Knight", 0, new Vector2(650, 750), _knightWhiteTexture), 
                new Piece("Rook", 0, new Vector2(750, 750), _rookWhiteTexture)
            }
        };
        
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
    
        _currentKeyboard = Keyboard.GetState();
        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        int x = 0; int y = 0;
        
        for (int i = 7; i >= 0; i--)    // i = řádek
        {
            for (int ii = 7; ii >= 0; ii--)  // ii = sloupec
            {
                ChessBoard[i,ii].DrawSelf(_spriteBatch);
                x += 100;
            }

            y += 100;
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}