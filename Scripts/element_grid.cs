using Godot;
using System;

public partial class element_grid : Control
{
	Element[][] elements;
	public void AddElement(Element element, int x, int y) {
		elements[y][x] = element;
	}
}
