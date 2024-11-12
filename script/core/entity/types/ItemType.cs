using Godot;

public class ItemType {
    public Texture2D texture2D;
    public bool stackable = false;

    public ItemType(string name) {
        texture2D = Core.itemAtlas.find(name);
    }

}