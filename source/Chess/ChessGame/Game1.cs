using System;
using System.Diagnostics;
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
    
    private Piece _currentPickedPiece;
    private int[] _currentPickedPieceCoord;
    
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
        
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _playerTurn = 0;    // 0 = white, 1 = black
        _currentPickedPieceCoord = new int[2];
        _currentPickedPiece = new Piece("King", 3, Vector2.Zero, new Texture2D(GraphicsDevice, 1, 1));
        
        _kingWhiteTexture = Content.Load<Texture2D>("KingWhite");
        _queenWhiteTexture = Content.Load<Texture2D>("QueenWhite");
        _bishopWhiteTexture = Content.Load<Texture2D>("BishopWhite");
        _knightWhiteTexture = Content.Load<Texture2D>("KnightWhite");
        _rookWhiteTexture = Content.Load<Texture2D>("CastleWhite");
        _pawnWhiteTexture = Content.Load<Texture2D>("PawnWhite");
        
        _kingBlackTexture = Content.Load<Texture2D>("KingBlack");
        _queenBlackTexture = Content.Load<Texture2D>("QueenBlack");
        _bishopBlackTexture = Content.Load<Texture2D>("BishopBlack");
        _knightBlackTexture = Content.Load<Texture2D>("KnightBlack");
        _rookBlackTexture = Content.Load<Texture2D>("CastleBlack");
        _pawnBlackTexture = Content.Load<Texture2D>("PawnBlack");

        _emptyTexture = new Texture2D(GraphicsDevice, 32, 32);
        
        ChessBoard = new Piece[,] {
            {
                new Piece("Rook", 1, new Vector2(50, 50), _rookBlackTexture), 
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
        
        var mouseState = Mouse.GetState(); 
        ;
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            for (int i = 7; i >= 0; i--)    // i = řádek
            {
                for (int ii = 7; ii >= 0; ii--)  // ii = sloupec
                {
                    if (ChessBoard[i, ii].ClickedOn(mouseState.X, mouseState.Y))
                    {
                        if (_currentPickedPiece.getTeam() != 3)
                        {
                            if (ChessBoard[i, ii] != _currentPickedPiece)
                            {
                                _currentPickedPiece.replacePiece(ChessBoard[i, ii]);
                                ChessBoard[i, ii] = _currentPickedPiece;
                                _currentPickedPiece = new Piece("King", 3, Vector2.Zero, new Texture2D(GraphicsDevice, 1, 1));
                                _currentPickedPieceCoord = new int[2];
                                Console.WriteLine(_currentPickedPieceCoord[0]);
                            }
                            else
                            {
                                Console.WriteLine("You clicked the chessboard");
                                _currentPickedPiece = ChessBoard[i, ii];
                                _currentPickedPieceCoord[0] = i;
                                _currentPickedPieceCoord[1] = ii;

                                Console.WriteLine(
                                    $"You picked piece on {_currentPickedPieceCoord[0] + 1};{_currentPickedPieceCoord[1] + 1}");
                                Console.WriteLine(
                                    $"You picked piece with list coordinates {_currentPickedPieceCoord[0]};{_currentPickedPieceCoord[1]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You clicked the chessboard");
                            _currentPickedPiece = ChessBoard[i, ii];
                            _currentPickedPieceCoord[0] = i;
                            _currentPickedPieceCoord[1] = ii;

                            Console.WriteLine(
                                $"You picked piece on {_currentPickedPieceCoord[0] + 1};{_currentPickedPieceCoord[1] + 1}");
                            Console.WriteLine(
                                $"You picked piece with list coordinates {_currentPickedPieceCoord[0]};{_currentPickedPieceCoord[1]}");
                        }
                    }
                }
            }
        }
        
        
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