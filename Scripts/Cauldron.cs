using Godot;
using System;

public partial class Cauldron : AnimatedSprite2D
{
	private int state;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Play("green");
	}

	public void ChangeState(int newState)
	{
		switch (newState){
			case 1:
				Play("green");
				break;
			case 2:
				Play("orange");
				break;
			case 3:
				Play("red");
				break;
			default:
				break;
		}
	}
}
