using Godot;
using System;

public partial class TimerBar : TextureProgressBar
{
	
	public GameTimer _timer;
	[Export] public Cauldron cauldronSprite;
	[Export] public BubbleTextureChanger bubbles;
	public AudioStreamPlayer2D alert;
	private bool danger = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetNode<GameTimer>("Timer");
		alert = GetNode<AudioStreamPlayer2D>("Alert");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Value = (float)_timer.TimeLeft;
		if(Value <= 0)
		{
			GetTree().ChangeSceneToFile("res://Scenes/gameOver.tscn");
		}

		if((_timer.TimeLeft / 100) > 0.6f)
		{
			cauldronSprite.ChangeState(1);
			bubbles.changeTex(1);
			danger = false;
		} else if((_timer.TimeLeft / 100) > 0.3f)
		{
			cauldronSprite.ChangeState(2);
			bubbles.changeTex(2);
			danger = false;
		} else
		{
			cauldronSprite.ChangeState(3);
			bubbles.changeTex(3);
			danger = true;
		}
	}

	public void _on_sound_timer_timeout()
	{
		if(danger)
		{
			alert.Play();
		}
	}


}
