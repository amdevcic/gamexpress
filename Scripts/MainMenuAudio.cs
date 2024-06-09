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

	public void _on_play_button_pressed() {
		buttonclick.Play();
	}

	public void _on_instructions_button_pressed() {
		buttonclick.Play();
	}

	public void _on_credits_button_pressed() {
		buttonclick.Play();
	}

	public void _on_back_button_pressed() {
		buttonclick.Play();
	}

	public void _on_cred_back_button_pressed() {
		buttonclick.Play();
	}

}
