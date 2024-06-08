using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GameTimer : Timer
{	
	// Adds specified time to timer
	public void AddTime(double time)
	{
		//WaitTime = (TimeLeft + time);
		Start(TimeLeft + time);
		GD.Print("added ", time);
		//Timer.
	}
	
}

