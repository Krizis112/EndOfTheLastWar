using System.Linq;
using Godot;

public partial class MapManager : Node
{
	[Export]
	public TileMapLayer layer;
	[Export]
	public Player player;
	Vector2I prevTile;
	public Item[] items;

	public override void _Ready()
	{
		prevTile = Vector2I.Zero;
	}

	public override void _Process(double delta)
	{
		Vector2I tilePosition = layer.LocalToMap(player.Position);

		if(tilePosition != prevTile){
			TileData tileData = layer.GetCellTileData(prevTile);
			prevTile = tilePosition;
			if(tileData == null) return;
			Bioms.bioms.TryGetValue(tileData.GetCustomData("type").AsString(), out Biom biom);
			items = biom.res;
			GD.Print(string.Join(", ", items?.Select(item => item.name) ?? new string[] { "Items is null" }), prevTile);
		}
	}
}
