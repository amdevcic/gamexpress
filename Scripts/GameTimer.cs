using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GameTimer : Timer
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	// Adds specified time to timer
	public void AddTime(double time)
	{
		//WaitTime = (TimeLeft + time);
		Start(TimeLeft + time);
		GD.Print("added ", time);
		//Timer.
	}
	
}

