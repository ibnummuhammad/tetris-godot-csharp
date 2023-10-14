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

	public void SpawnTetromino(Shared.Tetromino type)
	{
		Resource tetrominoData = new Shared().data[type];
	}
}
