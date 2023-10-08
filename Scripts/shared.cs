using Godot;
using System.Collections.Generic;

public partial class shared : Node
{
	enum Tetromino
	{
		I, O, T, J, L, S
	}

	private Dictionary<Tetromino, List<Vector2>> cells;
	Dictionary<Tetromino, string> citiesq;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// cells = new Dictionary<Tetromino, List<Vector2>>(){
		// 	{Tetromino.I,List}
		// }
		citiesq = new Dictionary<Tetromino, string>(){
			{Tetromino.I, "London, Manchester, Birmingham"},
			{Tetromino.O, "Chicago, New York, Washington"},
			{Tetromino.T, "Mumbai, New Delhi, Pune"}
		};
		var bigCities = new List<Vector2>()
		{
			new Vector2(-1,0),
			new Vector2(0,0),
			new Vector2(1,0),
			new Vector2(2,0)
		};
		GD.Print("baru11");
		GD.Print(bigCities.GetType());
		GD.Print(bigCities);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
