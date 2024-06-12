using Godot;
using System;

public partial class MainMenuAudio : Node
{
	public AudioStreamPlayer2D music;
	public AudioStreamPlayer2D buttonclick;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		music = GetNode<AudioStreamPlayer2D>("Music");
		buttonclick = GetNode<AudioStreamPlayer2D>("ButtonS");

		music.Play();
	}

	public void ButtonClickPlay() {
		buttonclick.Play();
	}
}
