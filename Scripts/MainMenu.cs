using Godot;
using System;

public partial class MainMenu : Control
{

	[Export] public Container mainContainer;
	[Export] public Container instructionsContainer;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_play_button_pressed()
	{
		GD.Print("play pressed");
		GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
	}

	public void _on_instructions_button_pressed()
	{
		mainContainer.Visible = false;
		instructionsContainer.Visible = true; 
	}

	public void _on_back_button_pressed()
	{
		mainContainer.Visible = true;
		instructionsContainer.Visible = false;
	}

}
