using Godot;
using Godot.Collections;

public partial class TextureAtlas
{
	private CompressedTexture2D texture;
	private Json json;
	private Dictionary<string, Array> jsonData;
	private Dictionary<string, TextureRegion> regions;

	public int atlasRegionSize = 64;

	public TextureAtlas(string path)
	{
		loadTexture(path);
		loadJson(path);
		loadAtlas();
	}

	private void loadTexture(string path)
	{
		string texturePath = path.Substring(0, path.Length - 4) + "png";
		texture = GD.Load<CompressedTexture2D>(texturePath);

		if (texture == null)
		{
			GD.PushError($"Failed to load texture from {texturePath}");
		}
	}

	private void loadJson(string path)
	{
		json = new Json();
		var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		if (file == null)
		{
			GD.PushError($"Failed to open file: {path}");
			return;
		}

		json.Parse(file.GetAsText());
		jsonData = (Dictionary<string, Array>)json.Data;
	}

	private void loadAtlas()
	{
		if (!jsonData.TryGetValue("frames", out Array frames))
		{
			GD.PushError("No frames found in JSON data.");
			return;
		}

		regions = new Dictionary<string, TextureRegion>();
		foreach (Dictionary<string, Variant> regionData in frames)
		{
			string name = regionData["filename"].AsString().Substring(0, regionData["filename"].AsString().Length - 4);
			Dictionary<string, Variant> frameData = (Dictionary<string, Variant>)regionData["frame"];

			Region region = new Region(name, (int)frameData["x"], (int)frameData["y"], (int)frameData["w"], (int)frameData["h"]);
			addRegion(region);
		}
	}

	public TextureRegion find(string name)
	{
		if (!regions.TryGetValue(name, out TextureRegion textureRegion))
		{
			GD.PushError($"Region with name: {name} not found.");
			return regions["error"];
		}
		return textureRegion;
	}

	private void addRegion(Region region)
	{
		regions[region.Name] = createRegion(region.Rectangle);
	}

	private TextureRegion createRegion(Rect2I rect)
	{
		TextureRegion region = new TextureRegion();
		region.atlasRegion = new Vector2I(rect.Position.X / atlasRegionSize, rect.Position.Y / atlasRegionSize);
		region.SetImage(TextureRegion.CreateFromImage(texture.GetImage().GetRegion(rect)).GetImage());
		return region;
	}
}
