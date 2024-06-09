using Godot;
using System;

public partial class BubbleTextureChanger : CpuParticles2D
{	[Export] public Texture2D bubbleTex1;
	[Export] public Texture2D bubbleTex2;
	[Export] public Texture2D bubbleTex3;

	private int state = 1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void changeTex(int num)
	{
		if (num != state)
		{
			state = num;

			switch(num){
				case 1:
					Amount = 10;
					Texture = bubbleTex1;
					break;

				case 2:
					Amount = 30;
					Texture = bubbleTex2;
					break;

				case 3:
					Amount = 50;
					Texture = bubbleTex3;
					break;

				default:
					Amount = 10;
					Texture = bubbleTex1;
					break;
			}
		}
	}
}
