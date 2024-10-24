using System.Collections.Generic;
using Godot;

public class Bioms {
	public static Dictionary<string, Biom> bioms;
	public static Dictionary<string, Biom> biomsColor;

	public static Biom forest, water, water2;

	public static void load() {
		bioms = new Dictionary<string, Biom>();
		biomsColor = new Dictionary<string, Biom>();

		forest = new Biom() {
			speedMultiplier = 2,
			color = "caffff",
			type = "forest",
			atlasPosition = new Vector2I(0, 5)
		}.resources(Items.wood, Items.water, Items.wood).add();

		water = new Biom() {
			speedMultiplier = 1,
			color = "cbffff",
			type = "water",
			atlasPosition = new Vector2I(0, 12)
		}.resources(Items.water).add();
		water2 = new Biom() {
			color = "c8ffff",
			atlasPosition = new Vector2I(0, 12),
			type = "water"
		};
	}
}
