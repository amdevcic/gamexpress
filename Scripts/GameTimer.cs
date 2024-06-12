using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GameTimer : Timer
{
	double maxTime = 100;	
	public void AddTime(double time)
	{
		double newTime = Math.Min(TimeLeft+time, maxTime);
		Start(newTime);
		GD.Print("added ", time, " seconds.");
	}
	
}

