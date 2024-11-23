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
    private Piece[,] ChessBoard = {
        {new Piece("Rook", 1), new Piece("Knight", 1), new Piece("Bishop", 1), new Piece("King", 1), new Piece("Queen", 1), new Piece("Bishop", 1), new Piece("Knight", 1), new Piece("Rook", 1)}, 
        {new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1), new Piece("Pawn", 1)}, 
        {new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2)}, 
        {new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2)}, 
        {new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2)},
        {new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2), new Piece("", 2)}, 
        {new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0), new Piece("Pawn", 0)},
        {new Piece("Rook", 0), new Piece("Knight", 0), new Piece("Bishop", 0), new Piece("King", 0), new Piece("Queen", 0), new Piece("Bishop", 0), new Piece("Knight", 0), new Piece("Rook", 0)}
    };
    
    private KeyboardState _currentKeyboard;
    
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
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}