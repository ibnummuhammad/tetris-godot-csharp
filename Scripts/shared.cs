using Godot;
using System.Collections.Generic;

public partial class shared : Node
{
	enum Tetromino
	{
		I, O, T, J, L, S, Z
	}

	private Dictionary<Tetromino, List<Vector2>> cells;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cells = new Dictionary<Tetromino, List<Vector2>>(){
			{Tetromino.I,new List<Vector2>(){new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0),new Vector2(2,0)}},
			{Tetromino.J,new List<Vector2>(){new Vector2(-1,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.L,new List<Vector2>(){new Vector2(1,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.O,new List<Vector2>(){new Vector2(0,1),new Vector2(1,1),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.S,new List<Vector2>(){new Vector2(0,1),new Vector2(1,1),new Vector2(-1,0),new Vector2(0,0)}},
			{Tetromino.T,new List<Vector2>(){new Vector2(0,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.Z,new List<Vector2>(){new Vector2(-1,1),new Vector2(0,1),new Vector2(0,0),new Vector2(1,0)}}
		};
		GD.Print("baru11");
		GD.Print(cells.GetType());
		GD.Print(cells);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
