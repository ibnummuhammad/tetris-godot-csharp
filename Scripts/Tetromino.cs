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
		bounds = new Dictionary<string, int>()
		{
			{"min_x", -216}, {"max_x", 216}, {"max_y",457}
		};
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
			Move(Vector2.Right);
		else if (Input.IsActionJustPressed("down"))
			Move(Vector2.Down);
		else if (Input.IsActionJustPressed("hard_drop"))
			GD.Print("pencethard_drop");
		else if (Input.IsActionJustPressed("rotate_left"))
			GD.Print("pencetrotate_left");
		else if (Input.IsActionJustPressed("rotate_right"))
			GD.Print("pencetrotate_right");
	}

	private bool Move(Vector2 direction)
	{
		Nullable<Vector2> newPosition = CalculateGlobalPosition(direction, GlobalPosition);
		if (newPosition != null)
		{
			Vector2 globalPosition = (Vector2)newPosition;
			if (direction != Vector2.Down)
				return true;
		}
		return false;
	}

	private Vector2? CalculateGlobalPosition(Vector2 direction, Vector2 startingGlobalPosition)
	{
		GD.Print(IsCollidingWithOtherTetrominos(direction, startingGlobalPosition));
		if (IsCollidingWithOtherTetrominos(direction, startingGlobalPosition) is true)
			return null;
		if (!IsWithinGameBounds(direction, startingGlobalPosition))
			return null;
		return startingGlobalPosition + direction * pieces[0].GetSize().X;
	}

	private bool IsWithinGameBounds(Vector2 direction, Vector2 startingGlobalPosition)
	{
		foreach (Piece piece in pieces)
		{
			Vector2 newPosition = piece.Position + startingGlobalPosition + direction * piece.GetSize();
			if (newPosition.X < bounds["min_x"] || newPosition.X > bounds["max_x"] || newPosition.Y >= bounds["max_y"])
				return false;
		}
		return true;
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
