using Godot;
using System.Collections.Generic;

public partial class Shared : Node
{
	public enum Tetromino
	{
		I, O, T, J, L, S, Z
	}

	private Dictionary<Tetromino, List<Vector2>> cells;
	private Dictionary<Tetromino, Resource> data;
	private List<List<Vector2>> wallKicksI;
	private List<List<Vector2>> wallKicksJlostz;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cells = new Dictionary<Tetromino, List<Vector2>>()
		{
			{Tetromino.I,new List<Vector2>(){new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0),new Vector2(2,0)}},
			{Tetromino.J,new List<Vector2>(){new Vector2(-1,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.L,new List<Vector2>(){new Vector2(1,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.O,new List<Vector2>(){new Vector2(0,1),new Vector2(1,1),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.S,new List<Vector2>(){new Vector2(0,1),new Vector2(1,1),new Vector2(-1,0),new Vector2(0,0)}},
			{Tetromino.T,new List<Vector2>(){new Vector2(0,1),new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0)}},
			{Tetromino.Z,new List<Vector2>(){new Vector2(-1,1),new Vector2(0,1),new Vector2(0,0),new Vector2(1,0)}}
		};
		wallKicksI = new List<List<Vector2>>()
		{
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-2,0),new Vector2(1,0),new Vector2(-2,-1),new Vector2(1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(2,0),new Vector2(-1,0),new Vector2(2,1),new Vector2(-1,-2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(2,0),new Vector2(-1,2),new Vector2(2,-1)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(1,0),new Vector2(-2,0),new Vector2(1,-2),new Vector2(-2,1)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(2,0),new Vector2(-1,0),new Vector2(2,1),new Vector2(-1,-2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-2,0),new Vector2(1,0),new Vector2(-2,-1),new Vector2(1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(1,0),new Vector2(-2,0),new Vector2(1,-2),new Vector2(-2,1)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(2,0),new Vector2(-1,2),new Vector2(2,-1)}},
		};
		wallKicksJlostz = new List<List<Vector2>>()
		{
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(-1,1),new Vector2(0,-2),new Vector2(-1,-2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(1,0),new Vector2(-1,-1),new Vector2(0,2),new Vector2(1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(1,0),new Vector2(1,-1),new Vector2(0,2),new Vector2(1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(-1,1),new Vector2(0,-2),new Vector2(-1,-2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(1,0),new Vector2(1,1),new Vector2(0,-2),new Vector2(1,-2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(-1,-1),new Vector2(0,2),new Vector2(-1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(-1,-1),new Vector2(0,2),new Vector2(-1,2)}},
			{new List<Vector2>(){new Vector2(0,0),new Vector2(-1,0),new Vector2(1,1),new Vector2(0,-2),new Vector2(1,-2)}},
		};

		data = new Dictionary<Tetromino, Resource>()
		{
			{Tetromino.I, GD.Load("res://Resources/i_piece_data.tres")},
			{Tetromino.J, GD.Load("res://Resources/j_piece_data.tres")},
			{Tetromino.L, GD.Load("res://Resources/l_piece_data.tres")},
			{Tetromino.O, GD.Load("res://Resources/o_piece_data.tres")},
			{Tetromino.S, GD.Load("res://Resources/s_piece_data.tres")},
			{Tetromino.T, GD.Load("res://Resources/t_piece_data.tres")},
			{Tetromino.Z, GD.Load("res://Resources/z_piece_data.tres")},
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
