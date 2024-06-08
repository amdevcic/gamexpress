using Godot;
using System;

public partial class TimerBar : TextureProgressBar
{
	
	public GameTimer _timer;
	[Export] public Cauldron cauldronSprite;
	[Export] public BubbleTextureChanger bubbles;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetNode<GameTimer>("Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Value = (float)_timer.TimeLeft;

		if((_timer.TimeLeft / 100) > 0.6f)
		{
			cauldronSprite.ChangeState(1);
			bubbles.changeTex(1);
		} else if((_timer.TimeLeft / 100) > 0.3f)
		{
			cauldronSprite.ChangeState(2);
			bubbles.changeTex(2);
		} else
		{
			cauldronSprite.ChangeState(3);
			bubbles.changeTex(3);
		}
	}


}
