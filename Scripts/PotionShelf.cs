using Godot;
using System;
using System.Collections.Generic;

public partial class PotionShelf : Node
{
    [Export]
    public NodePath GridContainerPath { get; set; }

    private GridContainer _gridContainer;
    [Export] public Element[] elements;

    public override void _Ready()
    {
        // Initialize the reference to the GridContainer
        _gridContainer = GetNode<GridContainer>(GridContainerPath);
        
        // Example of spawning an item on ready
        for (int i = 0; i < 3 * 5; i++) // Spawn initial 15 items
        {
            SpawnItem();
        }
    }

    public void SpawnItem()
    {
        // if (PotionElementScene != null)
        // {
        //     var potionElementInstance = PotionElementScene.Instantiate<Control>();
        //     potionElementInstance.Set("rect_min_size", new Vector2(32, 32)); // Ensure the size is 32x32

        //     _gridContainer.AddChild(potionElementInstance);
        // }
        // else
        // {
        //     GD.PrintErr("PotionElementScene is not set.");
        // }
    }

    // Optional: Call SpawnItem() for testing via input
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.Enter)
        {
            SpawnItem();
        }
    }
}
