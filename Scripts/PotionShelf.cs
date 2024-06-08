using Godot;
using System;

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

    for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
            if (populated >= count) break;

            Slot s = slots[i, j];
            SpawnItem(s);
            populated++;
        }
        if (populated >= count) break;
    }
    Slot h = slots[0, 0];
    h.SetElement(defaultElement);

    GD.Print($"Populated {populated} elements.");
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
