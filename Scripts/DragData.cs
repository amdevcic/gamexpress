using Godot;

public partial class DragData : GodotObject
{
    public Element element;
    public Slot parent;

    public DragData(Element element, Slot parent) {
        this.element = element;
        this.parent = parent;
    }
}
