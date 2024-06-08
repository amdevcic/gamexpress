using Godot;
using System;

public partial class TimerBar : ProgressBar
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
		// GD.Print(_timer.TimeLeft / _timer.WaitTime);
		this.Value = (float)(_timer.TimeLeft);
	}
}
