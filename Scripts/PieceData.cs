using Godot;
using System;

public partial class PieceData : Resource
{
	[Export]
	public Texture pieceTexture;

	[Export]
	public Shared.Tetromino tetrominoType;

	[Export]
	public Vector2 spawnPosition;
}
