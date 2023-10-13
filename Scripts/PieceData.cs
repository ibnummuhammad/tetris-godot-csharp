using Godot;
using System;

public partial class PieceData : Resource
{
	[Export]
	private Texture pieceTexture;

	[Export]
	private Shared.Tetromino tetrominoType;

	[Export]
	private Vector2 spawnPosition;
}
