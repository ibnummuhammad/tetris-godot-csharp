using Godot;
using System.Collections.Generic;

public partial class shared : Node
{
	enum Tetromino
	{
		I, O, T, J, L, S
	}

	private Dictionary<Tetromino, List<Vector2>> cells;
	Dictionary<string, string> citiesq;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// cells = new Dictionary<Tetromino, List<Vector2>>(){
		// 	{Tetromino.I,List}
		// }
		citiesq = new Dictionary<string, string>(){
			{"UK", "London, Manchester, Birmingham"},
			{"USA", "Chicago, New York, Washington"},
			{"India", "Mumbai, New Delhi, Pune"}
		};
		var bigCities = new List<string>()
		{
			"New York",
			"London",
			"Mumbai",
			"Chicago"
		};
		GD.Print("disitu");
		GD.Print(bigCities.GetType());
		GD.Print(bigCities);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
