using Godot;

public class ItemType {
    public Texture2D texture2D;
    public bool stackable = false;

    public ItemType(string name) {
        texture2D = GD.Load<Texture2D>("res://assets/sprites/items/" + name + ".png");
    }

}