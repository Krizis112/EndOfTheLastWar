using Godot;

public partial class Cell : Panel {
    public Texture2D texture;
    public Label label;

    public override void _Ready()
    {

        label = GetNode<Label>("Label");
    }
    public void changeTexture(Texture2D texture) {
        GetNode<TextureRect>("ColorRect/TextureRect").Texture = texture;
    }
}