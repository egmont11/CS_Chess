using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private int _playerTurn;
    
    // chessboard = 8x8
    private Piece[,] ChessBoard = {
        {new Piece("Tower"), new Piece("Knight"), new Piece("Bishop"), new Piece("Queen"), new Piece("King"), new Piece("Bishop"), new Piece("Knight"), new Piece("Tower")}, 
        {new Piece("Pawn"), new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn")}, 
        {}, 
        {}, 
        {}, 
        {}, 
        {new Piece("Pawn"), new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn") ,new Piece("Pawn")},
        {new Piece("Tower"), new Piece("Knight"), new Piece("Bishop"), new Piece("King"), new Piece("Queen"), new Piece("Bishop"), new Piece("Knight"), new Piece("Tower")}
    } ;
    
    private KeyboardState _currentKeyboard;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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