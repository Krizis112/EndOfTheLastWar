using Godot;
using static Bioms;

[Tool]
public partial class Map : TileMapLayer
{
	public override void _Ready()
	{
		Clear();
		loadFragment(Textures.map);
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
				setTile(color, position);
			}
		}
	}

	private void setTile(Color color, Vector2I position) {
		GD.Print(color.ToHtml(false));
		biomsColor.TryGetValue(color.ToHtml(false), out Biom biom);
		if(biom == null) return;
		SetCell(position, 1, biom.atlasPosition);
		GetCellTileData(position).SetCustomData("type", biom.type);
	}
}
