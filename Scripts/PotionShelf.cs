using Godot;
using System;
using System.Collections.Generic;

public partial class PotionShelf : Node
{
    private GridContainer _gridContainer;
    [Export] public Element[] elements;
    [Export] PackedScene slot;

    public override void _Ready()
    {
        _gridContainer = GetNode<GridContainer>("GridContainer");
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 3; j++) {
                Slot s = slot.Instantiate() as Slot;
                _gridContainer.AddChild(s);
                SpawnItem(s);
            }
        }
    }

    public void SpawnItem(Slot s)
    {
        Element element = elements[GD.Randi() % elements.Length];
        s.SetElement(element);
    }

}
