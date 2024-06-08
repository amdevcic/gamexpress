using Godot;
using System;

public partial class game_timer : ProgressBar
{
	
	private Timer _timer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.print(_timer.TimeLeft);
		this.Value = (float)(_timer.TimeLeft / _timer.WaitTime);
	}
}
