using Godot;
using System;

public partial class PieceSpawner : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Array tetrominoArray = Enum.GetValues(typeof(Shared.Tetromino));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
