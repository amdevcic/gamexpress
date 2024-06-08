using Godot;
using System;

public partial class TimerBar : ProgressBar
{
	
	private Timer _timer;
	[Export] public Cauldron cauldronSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
		//cauldronSprite = GetNode<Cauldron>("CanvasLayer/UI/HBoxContainer/VBoxContainer/Cauldron");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print(_timer.TimeLeft / _timer.WaitTime);
		this.Value = (float)(_timer.TimeLeft);

		if((_timer.TimeLeft / 100) > 0.6f)
		{
			cauldronSprite.ChangeState(1);
		} else if((_timer.TimeLeft / 100) > 0.3f)
		{
			cauldronSprite.ChangeState(2);
		} else
		{
			cauldronSprite.ChangeState(3);
		}


	}


}
