using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

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
    [Export] public AudioStreamPlayer2D good;
    [Export] public AudioStreamPlayer2D bad;
    [Export] public AudioStreamPlayer2D splash;

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

    public int EvaluateBoard() {
        int pts = 0;
        List<Slot> correct = new List<Slot>();
        List<Slot> incorrect = new List<Slot>();
        List<(int x, int y)> carbonPositions = new List<(int x, int y)>();

        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                Element elem = slots[j, i].Element;
                slots[j,i].ResetColor();
                if (elem == null) continue;

                int neighbors = CountNeighbors(i, j);
                // GD.Print($"Slot ({i},{j}) - Element: {elem.elementName}, Neighbors: {neighbors}, Required: {elem.numNeighbors}");

                // Check conditions
                if (elem.elementName == "Carbon") {
                    carbonPositions.Add((i, j));
                }
                else if (elem.elementName == "Sulphur") {
                    int oxygenNeighbors = CountSpecificNeighbors(i, j, "Oxygen");
                    int hydrogenNeighbors = CountSpecificNeighbors(i, j, "Hydrogen");
                    if (oxygenNeighbors == 2 || hydrogenNeighbors == 2) {
                        pts += elem.points;
                        correct.Add(slots[j, i]);
                    } else {
                        incorrect.Add(slots[j, i]);
                    }
                } else if (elem.elementName == "Iron") {
                    int oxygenNeighbors = CountSpecificNeighbors(i, j, "Oxygen");
                    int sulphurNeighbors = CountSpecificNeighbors(i, j, "Sulphur");
                    int carbonNeighbors = CountSpecificNeighbors(i, j, "Carbon");

                    if (oxygenNeighbors == 0 && sulphurNeighbors == 0 && carbonNeighbors >= 1) {
                        pts += elem.points;
                        correct.Add(slots[j, i]);
                    } else {
                        incorrect.Add(slots[j, i]);
                    }
                } else if (elem.numNeighbors > 0 && neighbors == elem.numNeighbors) {
                    pts += elem.points;
                    correct.Add(slots[j, i]);
                } 
                else if (elem.numNeighbors == 0) {
                    pts += elem.points * (1 + neighbors);
                    correct.Add(slots[j, i]);
                }
                else {
                    incorrect.Add(slots[j, i]);
                }
            }
        }

        // Check if all carbons are in the same row or column
        if (carbonPositions.Count > 0) {
            bool sameRow = true;
            bool sameColumn = true;

            int firstRow = carbonPositions[0].y;
            int firstColumn = carbonPositions[0].x;

            foreach (var pos in carbonPositions) {
                if (pos.y != firstRow) {
                    sameRow = false;
                }
                if (pos.x != firstColumn) {
                    sameColumn = false;
                }
            }

            if (!sameRow && !sameColumn) {
                pts = 0;
                foreach (var pos in carbonPositions) {
                    slots[pos.y, pos.x].SetIncorrect();
                }
            } else {
                foreach (var pos in carbonPositions) {
                    correct.Add(slots[pos.y, pos.x]);
                    pts += 10; //carbon points
                }
            }
        }

        if (incorrect.Count > 0) {
            pts = 0;
            bad.Play();
            foreach (Slot s in incorrect) {
                s.SetIncorrect();
            }
        } else {
            good.Play();
            splash.Play();
            foreach (Slot s in correct) {
                s.ClearSlot();
            }   
            GD.Print($"Total Points: {pts}");
        }

        return pts;
    }

    private int CountSpecificNeighbors(int x, int y, string elementName) {
        int count = 0;
        int[,] directions = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        for (int i = 0; i < directions.GetLength(0); i++) {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];

            if (newX >= 0 && newX < width && newY >= 0 && newY < height) {
                Element neighborElem = slots[newY, newX].Element;
                if (neighborElem != null && neighborElem.elementName == elementName) {
                    count++;
                }
            }
        }

        return count;
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
        
        return count;
    }
}
