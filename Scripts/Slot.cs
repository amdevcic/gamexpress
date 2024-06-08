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
        return true;
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
		Variant ret = new DragData(this.Element, this);
		
		TextureRect preview = new TextureRect();
		preview.Texture = icon.Texture;
		SetDragPreview(preview);

        return ret;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        DragData d = data.As<DragData>(); 
        if (this.Element == null) {
            // If this slot is empty, just move the element here
            SetElement(d.element);
            d.parent.SetElement(null);
        } else {
            // If this slot has an element, swap the elements
            Element tempElement = this.Element;
            SetElement(d.element);
            d.parent.SetElement(tempElement);
        }
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

    public void SetIncorrect() {
        Color = new Color("ff000069");
    }
    public void ResetColor() {
        Color = new Color("00000069");
    }

    public void ClearSlot() {
        this.Element = null;
        this.icon.Texture = null;
    }
}
