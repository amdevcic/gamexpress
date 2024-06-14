using Godot;
using System;

public partial class Options : PanelContainer
{
	public static bool Sounds = true;
	public static bool Music = true;
	public static bool SkipCutscenes = false;

	public static void SetSounds(bool on) {
		Sounds = on;
	}
	public static void SetMusic(bool on) {
		Music = on;
	}
	public static void SetSkipCutscenes(bool on) {
		SkipCutscenes = on;
	}
}
