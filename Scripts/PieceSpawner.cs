using Godot;
using System;

public partial class PieceSpawner : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Board board = GetNode("../Board") as Board;

		Array tetrominoArray = Enum.GetValues(typeof(Shared.Tetromino));
		Random random = new Random();
		int tetrominoArrayIndex = random.Next(tetrominoArray.Length);
		Shared.Tetromino currentTetromino = (Shared.Tetromino)tetrominoArray.GetValue(tetrominoArrayIndex);

		board.SpawnTetromino(currentTetromino, false, null);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
