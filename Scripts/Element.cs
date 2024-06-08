using Godot;

[GlobalClass]
public partial class Element : Resource
{
    [Export] public string elementName;
    [Export] public Texture2D image;
    [Export] public int numNeighbors;
    [Export] public int points;
    [Export] public string tooltip;
}
