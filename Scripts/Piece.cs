using Godot;
using System;

public partial class Piece : Area2D
{
	private Sprite2D sprite2D;
	private CollisionShape2D collisionShape2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite2D = GetNode<Sprite2D>("Sprite2D");
		collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
