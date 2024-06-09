using Godot;
using System;
using System.Threading.Tasks;

public partial class Game : Node2D
{
	[Export] ElementGrid elementGrid;
	[Export] TimerBar bar;
	GameTimer gameTimer;
	[Export] Label pointCounter;
	[Export] Label newPointLabel;
	[Export] PotionShelf potionShelf;
	int points;

	public AudioStreamPlayer2D music;
	public AudioStreamPlayer2D bubbles;

    public override void _Ready()
    {
        gameTimer = bar._timer;
		music = GetNode<AudioStreamPlayer2D>("AudioManager/Music");
		bubbles = GetNode<AudioStreamPlayer2D>("AudioManager/Bubbling");
		music.Play();
		bubbles.Play();
    }
    public void Evaluate() {
		int pts = elementGrid.EvaluateBoard();
		if (pts > 0) {
			gameTimer.AddTime((double)pts/15);
			points += pts;
			potionShelf.ClearPotions();
			potionShelf.Populate();
		}
		pointCounter.Text = points.ToString();
		newPointAlert(pts);
		global_vars.score = points;
	}

	private async void newPointAlert(int points)
	{
		if(points != 0){
			newPointLabel.Text = points + " points!";
		}
		await Task.Delay(2000);
		newPointLabel.Text = "";
	}
}
