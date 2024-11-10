using Godot;
using System;

public partial class TileAtlas : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Bioms.load();
		GD.Print(Bioms.forest.tiles["cbffff"].getAtlasRegion().ToString());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
