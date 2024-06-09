using Godot;
using System;
using System.Collections;

public partial class cutscene2 : Node2D
{
	private Timer timer;
	private HBoxContainer textbox;
	private TextureRect portrait;
	private Label text;
	private int currentLine = 1;

	[Export] public Texture2D portrait1;
	[Export] public Texture2D portrait2;

	[ExportGroup("audio")]
	[Export] AudioStreamPlayer2D voice1;
	[Export] AudioStreamPlayer2D voice2;
	[Export] AudioStreamPlayer2D boom;
	


	

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
				textbox.Visible = false;
				boom.Play();
				break;
			case 2:
				textbox.Visible = true;
				portrait.Texture = portrait1;
				voice1.Play();
				text.Text = "...";
				break;
			case 3:
				voice1.Play();
				text.Text = "Oops.";
				break;
			case 4:
				GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
				break;
			default:
				break;
		}
	}

}
