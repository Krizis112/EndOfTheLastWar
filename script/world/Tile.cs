using Godot;

public partial class Tile : Area2D {

	private Texture2D imageTexture;
	private string name;

	public Tile(string name) {
		imageTexture = GD.Load<CompressedTexture2D>("res://assets/sprites/map/world/tiles/" + name + ".png");
		this.name = name;
	}

	public override void _Ready()
	{
	}


	public override void _Draw()
	{
		DrawTexture(imageTexture, Vector2.Zero);
	}

	public string _GetName() {
		return name;
	}
}
