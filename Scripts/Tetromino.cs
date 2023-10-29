using Godot;
using System;
using System.Collections.Generic;

public partial class Tetromino : Node2D
{
	private int rotationIndex = 0;

	private Dictionary<String, int> bounds;
	private List<Piece> pieces = new List<Piece>() { };
	private List<Piece> otherTetrominoesPieces = new List<Piece>() { };
	List<List<Vector2>> wallKicks;

	public PieceData tetrominoData;
	private Shared shared;
	public bool isNextPiece;
	private PackedScene pieceScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pieceScene = (PackedScene)GD.Load("res://Scenes/piece.tscn");

		shared = GetNode<Shared>("/root/Shared");
		List<Vector2> tetrominoCells = shared.cells[(Shared.Tetromino)(int)tetrominoData.Get("tetrominoType")];

		foreach (Vector2 cell in tetrominoCells)
		{
			Piece piece = pieceScene.Instantiate() as Piece;
			pieces.Add(piece);
			AddChild(piece);
			piece.SetTexture((Texture2D)tetrominoData.pieceTexture);
			piece.Position = cell * piece.GetSize();
		}

		if (isNextPiece == false)
		{
			Vector2 position = tetrominoData.spawnPosition;
			if (tetrominoData.tetrominoType == Shared.Tetromino.I)
				wallKicks = shared.wallKicksI;
			else
				wallKicks = shared.wallKicksJlostz;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("left"))
			Move(Vector2.Left);
		else if (Input.IsActionJustPressed("right"))
			GD.Print("pencetright");
		else if (Input.IsActionJustPressed("down"))
			GD.Print("pencetdown");
		else if (Input.IsActionJustPressed("hard_drop"))
			GD.Print("pencethard_drop");
		else if (Input.IsActionJustPressed("rotate_left"))
			GD.Print("pencetrotate_left");
		else if (Input.IsActionJustPressed("rotate_right"))
			GD.Print("pencetrotate_right");
	}

	private void Move(Vector2 direction)
	{
		CalculateGlobalPosition(direction, GlobalPosition);
	}

	private void CalculateGlobalPosition(Vector2 direction, Vector2 startingGlobalPosition)
	{
		GD.Print(IsCollidingWithOtherTetrominos(direction, startingGlobalPosition));
	}

	private bool IsCollidingWithOtherTetrominos(Vector2 direction, Vector2 startingGlobalPosition)
	{
		foreach (Piece tetrominoPiece in otherTetrominoesPieces)
			foreach (Piece piece in pieces)
				if (startingGlobalPosition + piece.Position + direction * piece.GetSize() == tetrominoPiece.GlobalPosition)
					return true;
		return false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
