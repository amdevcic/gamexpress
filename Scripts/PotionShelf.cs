using Godot;
using System;
using System.Collections.Generic;


public partial class PotionShelf : Node
{
    private GridContainer _gridContainer;
    [Export] public Element[] elements;
    [Export] Element defaultElement;
    [Export] PackedScene slot;
    const int width = 3;
    const int height = 5;
    Slot[,] slots = new Slot[height, width];

    public override void _Ready()
    {
        _gridContainer = GetNode<GridContainer>("GridContainer");
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                Slot s = slot.Instantiate() as Slot;
                _gridContainer.AddChild(s);
                slots[i, j] = s;
            }
        }
        Populate();
    }

    public void SpawnItem(Slot s)
    {
        Element element = elements[GD.Randi() % elements.Length];
        s.SetElement(element);
    }

    public void Populate() {
        int count = Math.Abs((int)GD.Randi()) % (width * height - 3) + 3;
        int populated = 0;

        GD.Print($"Populating {count} elements.");

        // Generate a list of all grid positions
        List<(int, int)> gridPositions = new List<(int, int)>();
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                gridPositions.Add((i, j));
            }
        }

        // Shuffle the list of grid positions
        Shuffle(gridPositions);

        // Populate the shuffled grid positions
        foreach (var pos in gridPositions) {
            if (populated >= count) break;

            Slot s = slots[pos.Item1, pos.Item2];
            SpawnItem(s);
            populated++;
        }

        Slot h = slots[0, 0];
        h.SetElement(defaultElement);

        GD.Print($"Populated {populated} elements.");
    }

    // Method to shuffle a list using Fisher-Yates algorithm
    private void Shuffle<T>(List<T> list) {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void ClearPotions() {
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                Slot s = slots[i, j];
                s.ClearSlot();
            }
        }
    }
}
