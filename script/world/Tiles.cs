using System.Collections.Generic;
using Godot;

public static class Tiles {
    public static Tile forest, water;
    
    private static Dictionary<Color, Tile> tiles;

    public static void load() {
        tiles = new Dictionary<Color, Tile>();

        forest = new Tile("forest") {
            loot = new Godot.Collections.Array<Entity>(){},
            color = Color.Color8(28, 255, 255),
            radiation = 5f,
            speedMultiplier = 10f
        };
        tiles.Add(forest.color, forest);

        water = new Tile("water") {
            loot = new Godot.Collections.Array<Entity>() {},
            color = Color.Color8(205, 255, 255),
            radiation = 1f,
            speedMultiplier = 3f
        };
    }

    public static Tile GetTileByColor(Color color) {
        tiles.TryGetValue(color, out Tile tile);
        return tile;
    }
}