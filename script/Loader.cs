using Godot;
using System;

public partial class Loader : Node
{
	public override void _Ready()
	{
		Items.load();
		Bioms.load();
	}
}
