using Godot;

public partial class MainMenu : Control
{

	[Export] public Container mainContainer;
	[Export] public Container instructionsContainer;
	[Export] public Container creditsContainer;
	
	public void ExitGame() {
		GetTree().Quit();
	}

	public void _on_play_button_pressed()
	{
		bool skip = GetNode<Options>("CanvasLayer/OptionsMenu").SkipCutscenes;
		if (skip) {
			GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
		} else {
			GetTree().ChangeSceneToFile("res://Scenes/cutscene.tscn");
		}
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

	public void Back()
	{
		mainContainer.Visible = true;
		instructionsContainer.Visible = false;
		creditsContainer.Visible = false;
	}

}
