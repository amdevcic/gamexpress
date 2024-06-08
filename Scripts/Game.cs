using Godot;
using System;

public partial class Game : Node2D
{
	[Export] ElementGrid elementGrid;
	[Export] TimerBar bar;
	GameTimer gameTimer;
	[Export] Label pointCounter;
	int points;

    public override void _Ready()
    {
        gameTimer = bar._timer;
    }
    public void Evaluate() {
		int pts = elementGrid.EvaluateBoard();
		gameTimer.AddTime((double)pts/10);
		points += pts;
		pointCounter.Text = points.ToString("D10");
	}
}
