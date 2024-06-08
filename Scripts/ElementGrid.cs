using Godot;
using System;

public partial class ElementGrid : Control
{
    const int width = 8;
    const int height = 8;
    Slot[,] slots = new Slot[height, width];
    GridContainer grid;
    [Export]
    PackedScene slot;
    [Export]
    Element element1;

    public int EvaluateBoard() {
        int pts = 0;
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                Element elem = slots[j, i].Element;
                if (elem == null) continue;

                int neighbors = CountNeighbors(i, j);
                // GD.Print($"Slot ({i},{j}) - Element: {elem.elementName}, Neighbors: {neighbors}, Required: {elem.numNeighbors}");

                if (elem.numNeighbors > 0 && neighbors == elem.numNeighbors) {
                    pts += elem.points;
                }
            }
        }
        GD.Print($"Total Points: {pts}");
        return pts;
    }

    public override void _Ready() {
        grid = GetNode<GridContainer>("PanelContainer/GridContainer");
        grid.Columns = width;
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                Node s = slot.Instantiate();
                grid.AddChild(s);
                slots[i, j] = s as Slot;
            }
        }
        AddElement((Element)element1.Duplicate(), 1, 1);
        AddElement((Element)element1.Duplicate(), 1, 2);
        AddElement((Element)element1.Duplicate(), 1, 3);
    }

    public void AddElement(Element element, int x, int y) {
        slots[y, x].SetElement(element);
    }

    public int CountNeighbors(int x, int y) {
        int count = 0;
        if (x > 0 && slots[y, x - 1].Element != null) { count++; }
        if (x < width - 1 && slots[y, x + 1].Element != null) { count++; }
        if (y > 0 && slots[y - 1, x].Element != null) { count++; }
        if (y < height - 1 && slots[y + 1, x].Element != null) { count++; }

		// if (x > 0 && slots[y, x - 1].Element != null) { count++; GD.Print($"({x},{y}) has left neighbor"); }
        // if (x < width - 1 && slots[y, x + 1].Element != null) { count++; GD.Print($"({x},{y}) has right neighbor"); }
        // if (y > 0 && slots[y - 1, x].Element != null) { count++; GD.Print($"({x},{y}) has top neighbor"); }
        // if (y < height - 1 && slots[y + 1, x].Element != null) { count++; GD.Print($"({x},{y}) has bottom neighbor"); }
        // GD.Print($"CountNeighbors({x},{y}) = {count}");
        return count;
    }
}
