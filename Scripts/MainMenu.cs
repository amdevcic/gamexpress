using Godot;
using System;

public partial class MainMenu : Control
{

	[Export] public Container mainContainer;
	[Export] public Container instructionsContainer;
	[Export] public Container creditsContainer;
	

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
		GetTree().ChangeSceneToFile("res://Scenes/cutscene.tscn");
	}

	public void _on_instructions_button_pressed()
	{
		mainContainer.Visible = false;
		instructionsContainer.Visible = true; 
	}

		public void _on_credits_button_pressed()
	{
		mainContainer.Visible = false;
		creditsContainer.Visible = true; 
	}

	public void _on_back_button_pressed()
	{
		mainContainer.Visible = true;
		instructionsContainer.Visible = false;
	}

	public void _on_cred_back_button_pressed()
	{
		mainContainer.Visible = true;
		creditsContainer.Visible = false;
	}

}
