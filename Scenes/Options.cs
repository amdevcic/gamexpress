using Godot;

public partial class Options : PanelContainer
{
	public bool Sounds = true;
	public bool Music = true;
	public bool SkipCutscenes = false;

	public void SetSounds(bool on) {
		Sounds = on;
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Sounds"), !Sounds);
	}
	public void SetMusic(bool on) {
		Music = on;
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Music"), !Music);
	}
	public void SetSkipCutscenes(bool on) {
		SkipCutscenes = on;
	}

    public override void _Ready()
    {
        if (!Godot.FileAccess.FileExists("user://settings.cfg")) {
            GD.Print("Settings file does not exist. Creating default settings.");
            SaveSettings();
        }
		LoadSettings();
		GetNode<CheckBox>("MarginContainer/VBoxContainer/GridContainer/Music").ButtonPressed = Music;
		GetNode<CheckBox>("MarginContainer/VBoxContainer/GridContainer/Sounds").ButtonPressed = Sounds;
		GetNode<CheckBox>("MarginContainer/VBoxContainer/GridContainer/Cutscenes").ButtonPressed = SkipCutscenes;

		VisibilityChanged += () => {
			if (Visible) LoadSettings();
			else SaveSettings();
		};
    }

    public void SaveSettings() {
		GD.Print("SaveSettings called");
		var config = new ConfigFile();

		// Store some values.
		config.SetValue("Audio", "MusicEnabled", Music);
		config.SetValue("Audio", "SoundsEnabled", Sounds);
		config.SetValue("Gameplay", "SkipCutscene", SkipCutscenes);

		// Save it to a file (overwrite if already exists).
		Error err = config.Save("user://settings.cfg");
		if (err == Error.Ok) {
			GD.Print("Settings saved successfully.");
		} else {
			GD.Print("Failed to save settings: ", err);
		}
	}

	public void LoadSettings() {
		GD.Print("LoadSettings called");
		var config = new ConfigFile();
		Error err = config.Load("user://settings.cfg");
		if (err != Error.Ok) {
			GD.Print("Failed to load settings: ", err);
			return;
		}

		SetMusic((bool)config.GetValue("Audio", "MusicEnabled", Music));
		SetSounds((bool)config.GetValue("Audio", "SoundsEnabled", Sounds));
		SetSkipCutscenes((bool)config.GetValue("Gameplay", "SkipCutscene", SkipCutscenes));
		GD.Print("Settings loaded: Music=", Music, ", Sounds=", Sounds, ", SkipCutscenes=", SkipCutscenes);
	}
}
