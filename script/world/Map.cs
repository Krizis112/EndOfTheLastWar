using Godot;
using Godot.Collections;

public partial class Map : Node
{
	private Array<Image> images;
	private CompressedTexture2D texture2D;
	Array<Tile> tiles;

	public override void _Ready()
	{
		images = new Array<Image>();
		texture2D = GD.Load<CompressedTexture2D>("res://assets/sprites/map/world/1_1x1.png");
		tiles = MapUtils.GetTiles(texture2D, Color.Color8(28, 255, 255), "forest");
		foreach(Tile tile in tiles) {
			AddChild(tile);
			//Hui
		}
	}


}
