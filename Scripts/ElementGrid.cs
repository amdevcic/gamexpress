using Godot;
using System;

public partial class ElementGrid : Control
{
	const int width = 8;
	const int height = 8;
	Slot[,] slots = new Slot[height,width];
	GridContainer grid;
	[Export]
	PackedScene slot;
	[Export] Element element1;

    public override void _Ready()
    {
        grid = GetNode<GridContainer>("PanelContainer/GridContainer");
		grid.Columns = width;
		for (int i=0; i<height; i++) {
			for (int j=0; j<width; j++) {
				Node s = slot.Instantiate();
				grid.AddChild(s);
				slots[i, j] = s as Slot;
			}
		}
		AddElement(element1, 1, 1);
    }
	public void AddElement(Element element, int x, int y) {
		slots[y,x].SetElement(element);
	}
}
