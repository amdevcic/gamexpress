using Godot;
using System;

public partial class Slot : ColorRect
{
	public Element Element;
	public TextureRect icon;
    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
    }
    public void SetElement(Element element) {
		this.Element = element;
		icon.Texture = this.Element.image;
	}
}
