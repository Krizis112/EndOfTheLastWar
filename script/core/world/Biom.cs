using System.Collections.Generic;
using Godot;

public class Biom 
{
	public string name { get; set; }
	public int radiation { get; set; } = 10;
	public int speedMultiplier { get; set; } = 1;
	public Dictionary<string, TextureRegion> tiles { get; private set; }
	public string[] colorsArray { get; set; }
	public ItemType[] resourcesOnLocation { get; set; }

	public Biom(string name) 
	{
		this.name = name;
		tiles = new Dictionary<string, TextureRegion>();
	}

	public Biom resources(params ItemType[] items) 
	{
		resourcesOnLocation = items;
		return this;
	}

	public Biom colors(params string[] colors) 
	{
		colorsArray = colors;
		if (colors.Length == 0) return this;

		for (int i = 0; i < colors.Length; i++) 
		{
			string key = colors.Length == 1 ? colors[0] : colors[i];
			if (!tiles.ContainsKey(key)) 
			{
				tiles.Add(key, Core.tileAtlas.find(name + (colors.Length == 1 ? "" : "-" + i)));
			}
		}
		return this;
	}

	public Biom add() 
	{
		if (colorsArray == null && !tiles.ContainsKey("999999")) 
		{
			tiles.Add("999999", Core.tileAtlas.find("error"));
		}
		Bioms.bioms.Add(name, this);
		return this;
	}
}
