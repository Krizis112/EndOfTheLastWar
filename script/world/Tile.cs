using Godot;
using Godot.Collections;

public partial class Tile : Area2D {

	private Texture2D imageTexture;

	private CollisionShape2D collisionShape2D;
	private RectangleShape2D rectangleShape2D;
	private string name;

	private Array<Entity> loot;

	public Tile(string name) {
		imageTexture = GD.Load<CompressedTexture2D>("res://assets/sprites/map/world/tiles/" + name + ".png");
		this.name = name;
	}

	public override void _Ready()
	{
		rectangleShape2D = new RectangleShape2D();
		rectangleShape2D.Size = new Vector2(Vars.TILE_SIZE, Vars.TILE_SIZE);

		collisionShape2D = new CollisionShape2D();
		collisionShape2D.Shape = rectangleShape2D;

		AddChild(collisionShape2D);

		Connect("area_entered", new Callable(this, nameof(_OnAreaEntered)));
		Connect("area_exited", new Callable(this, nameof(_OnAreaExit)));

		loot = new Array<Entity>();

	}

	public void _OnAreaEntered(Area2D area2D) {
		if(area2D is not Tile) {
			GD.Print("Enter");
		}
	}

	public void _OnAreaExit(Area2D area2D) {
		GD.Print("Exit");
	}

    public override void _Draw()
	{
		DrawTexture(imageTexture, Vector2.Zero);
		DrawRect(new Rect2(Vector2.Zero, rectangleShape2D.Size), Colors.Red);
	}

	public string _GetName() {
		return name;
	}
}
