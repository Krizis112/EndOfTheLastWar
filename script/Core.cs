using Godot;

public partial class Core : Node {
	public static TextureAtlas tileAtlas = new TextureAtlas("res://assets/sprites/map/world/tiles/tileAtlas.json");
	
	public static Player player;
	public static TileMapLayer mapLayer;
	public static Biom biom = Bioms.error;
}