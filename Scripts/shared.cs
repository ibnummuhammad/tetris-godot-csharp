using Godot;
using System;
using System.Collections.Generic;

public partial class shared : Node
{
	enum Tetromino
	{
		I, O, T, J, L, S
	}

	private Dictionary<Tetromino, List<Vector2>> cells = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Dictionary<string, string> cities = new Dictionary<string, string>(){
			{"UK", "London, Manchester, Birmingham"},
			{"USA", "Chicago, New York, Washington"},
			{"India", "Mumbai, New Delhi, Pune"}
		};
		GD.Print("disiniff");
		GD.Print(cities.GetType());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
