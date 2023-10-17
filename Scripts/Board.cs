using Godot;
using System.Collections.Generic;

public partial class Board : Node
{
	[Export]
	private PackedScene tetrominoScene;

	private int columnCount = 10;
	private int rowCount = 20;
	private Shared.Tetromino nextTetromino;
	private List<Shared.Tetromino> tetrominos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SpawnTetromino(Shared.Tetromino type, bool isNextPiece, Vector2? spawnPosition)
	{
		Resource tetrominoData = GetNode<Shared>("/root/Shared").data[type];
		Tetromino tetromino = tetrominoScene.Instantiate() as Tetromino;

		tetromino.tetrominoData = tetrominoData;
		tetromino.isNextPiece = isNextPiece;

		if (isNextPiece == false)
		{
			tetromino.Position = (Vector2)tetrominoData.Get("spawnPosition");
			AddChild(tetromino);
		}
		else
		{
			tetromino.Scale = new Vector2((float)0.5, (float)0.5);
		}
	}
}
