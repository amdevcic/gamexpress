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
    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return this.Element == null;
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        GD.Print("aaa");
		Variant ret = new DragData(this.Element, this);
		
		TextureRect preview = new TextureRect();
		preview.Texture = icon.Texture;
		SetDragPreview(preview);

        return ret;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        DragData d = data.As<DragData>(); 
        SetElement(d.element);
        d.parent.SetElement(null);
    }

    public void SetElement(Element element) {
		if (element == null) {
			this.Element=null;
			icon.Texture = null;
            return;
		}
		this.Element = element;
		icon.Texture = this.Element.image;
	}
}
