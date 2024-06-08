using Godot;
using System;

public partial class Game : Node2D
{
	[Export] ElementGrid elementGrid;
	[Export] TimerBar bar;
	GameTimer gameTimer;
	[Export] Label pointCounter;
	[Export] PotionShelf potionShelf;
	int points;

    public override void _Ready()
    {
        gameTimer = bar._timer;
    }
    public void Evaluate() {
		int pts = elementGrid.EvaluateBoard();
		if (pts > 0) {
			gameTimer.AddTime((double)pts/10);
			points += pts;
			potionShelf.ClearPotions();
			potionShelf.Populate();
		}
		pointCounter.Text = points.ToString("D10");
	}
}
