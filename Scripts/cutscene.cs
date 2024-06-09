using Godot;
using System;
using System.Collections;

public partial class cutscene : Node2D
{
	private Timer timer;
	private HBoxContainer textbox;
	private TextureRect portrait;
	private Label text;
	private int currentLine = 1;

	[Export] public Texture2D portrait1;
	[Export] public Texture2D portrait2;

	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		textbox = GetNode<HBoxContainer>("CanvasLayer/HBoxContainer");
		portrait = GetNode<TextureRect>("CanvasLayer/HBoxContainer/NinePatchRect/MarginContainer/TextureRect");
		text = GetNode<Label>("CanvasLayer/HBoxContainer/NinePatchRect2/MarginContainer/Label");

		AdvanceText(currentLine);
		currentLine += 1;
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override async void _Process(double delta)
	// {
	// 	// if(Input.IsAnythingPressed())
	// 	// {
	// 	// 	AdvanceText(currentLine);
	// 	// 	currentLine += 1;
	// 	// 	await ToSignal(GetTree().CreateTimer(0.2f), SceneTreeTimer.SignalName.Timeout);
	// 	// }
	// }

	public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed)
            {
                AdvanceText(currentLine);
				currentLine += 1;
            }
        } else if (@event is InputEventMouseButton eventMouseButton)
        {
            if (eventMouseButton.Pressed)
            {
                AdvanceText(currentLine);
				currentLine += 1;
            }
        }
    }

	private void AdvanceText(int line)
	{
		switch(line)
		{
			case 1:
				text.Text ="Apprentice. I'm going out.";
				break;
			case 2:
				text.Text = "Don't touch anything.";
				break;
			case 3:
				portrait.Texture = portrait1;
				text.Text = "Yes, grand master alchemist!";
				break;
			case 4:
				textbox.Visible = false;
				break;
			case 5:
				textbox.Visible = true;
				text.Text = "I'm sure nothing will happen if I just...";
				break;
			case 6:
				textbox.Visible = false;
				break;
			case 7:
				textbox.Visible = true;
				text.Text = "Oh no.";
				break;
			case 8:
				textbox.Visible = true;
				text.Text = "Um... I'm sure I can stabilize it somehow!";
				break;
			case 9:
				GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
				break;
			default:
				break;
		}
	}

}
