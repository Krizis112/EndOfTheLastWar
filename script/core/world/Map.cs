using Godot;

[Tool]
public partial class Map : TileMapLayer
{
	[Export]
	public Texture2D atlas;

	public override void _Ready()
	{
		Clear();
		loadFragment(GD.Load<Texture2D>("res://assets/sprites/map/world/1_1x1.png"));
		Core.mapLayer = this; 
	}

	private void loadFragment(Texture2D mapFragment) 
	{
		Image image = mapFragment.GetImage();
		int width = mapFragment.GetWidth();
		int height = mapFragment.GetHeight();

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector2I position = new Vector2I(x, y);
				Color color = image.GetPixel(x, y);
				Biom biom = Bioms.getBiomWithColor(color.ToHtml(false));
				if(biom == null) continue;
				SetCell(position, 0, biom.tiles[color.ToHtml(false)].atlasRegion);
				GetCellTileData(new Vector2I(x, y)).SetCustomData("name", biom.name);
			}
		}
	}
}
