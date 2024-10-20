using Godot;
using Godot.Collections;

public class MapUtils {
	public static Array<Tile> GetTiles(CompressedTexture2D compressedTexture2D, Color color, string textureName) {
		Array<Tile> tiles = new Array<Tile>();
		Image image = compressedTexture2D.GetImage();

		for(int i = 0; i < compressedTexture2D.GetWidth(); i++) {
			for(int j = 0; j < compressedTexture2D.GetHeight(); j++) {
				if(image.GetPixel(i, j) == color) {
					Tile tile = new Tile(textureName);
					tile.Position = new Vector2(i * 64, j * 64);
					tiles.Add(tile);
				} else if (image.GetPixel(i, j) == Color.Color8(203, 255, 255)) {
					Tile tile = new Tile("sea");
					tile.Position = new Vector2(i * 64, j * 64);
					tiles.Add(tile);
				} 
			}
		}

		return tiles;
	}
}
