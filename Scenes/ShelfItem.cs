using Godot;

public partial class ShelfItem : Control
{
	public Element Element;
	public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return this.Element == null;
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
		Variant ret = new DragData(this.Element, this);
		
		TextureRect preview = new TextureRect();
		preview.Texture = icon.Texture;
		SetDragPreview(preview);

        return ret;
    }
}
