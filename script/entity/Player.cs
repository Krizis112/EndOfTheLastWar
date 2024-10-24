using Godot;

public partial class Player : Sprite2D 
{
	private Vector2 targetPosition;
	[Export]
	TileMapLayer tileMapLayer {get; set;}

	public override void _Ready()
	{
		targetPosition = Position;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.IsPressed())
		{
			targetPosition = GetGlobalMousePosition();
		}
	}

	public override void _Process(double delta)
	{
		if(Position != targetPosition) {
			Position = Position.MoveToward(targetPosition, (float)(100 * delta));
		}
		Vector2I vector2I = tileMapLayer.LocalToMap(Position);
		TileData tileData = tileMapLayer.GetCellTileData(vector2I);
		if(tileData != null){
			Bioms.bioms.TryGetValue(tileData.GetCustomData("type").AsString(), out Biom biom);
			if(biom != null) GD.Print(biom.res[0].name);
		}
	}
}
