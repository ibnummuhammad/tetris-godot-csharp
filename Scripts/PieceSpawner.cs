using Godot;
using System;

public partial class PieceSpawner : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node board = GetNode("../Board") as Board;

		Array tetrominoArray = Enum.GetValues(typeof(Shared.Tetromino));
		Random random = new Random();
		int tetrominoArrayIndex = random.Next(tetrominoArray.Length);
		Object currentTetromino = tetrominoArray.GetValue(tetrominoArrayIndex);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
