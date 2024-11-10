using Godot;

public partial class Player : Sprite2D 
{
	public Vector2I tilePosition;
	private Vector2 targetPosition;
	private Vector2I previousTilePosition;

	public override void _Ready()
	{
		targetPosition = Position;
		Core.player = this;
		Core.inventory.addItem(new ItemStack(ItemTypes.water, 1000));
		previousTilePosition = Core.mapLayer.LocalToMap(Position);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.IsPressed())
		{
			targetPosition = GetGlobalMousePosition();
			Core.inventory.removeItem(new ItemStack(ItemTypes.water, 10));
			Core.inventory.inventoryUpdater += (items) => {
				GD.Print(items[0].count);
			};
		}
	}

	public override void _Process(double delta)
	{
		if (Position != targetPosition) 
		{
			Position = Position.MoveToward(targetPosition, (float)(100 * delta));
		}

		tilePosition = Core.mapLayer.LocalToMap(Position);
		if (tilePosition != previousTilePosition) 
		{
			updateTilePosition();
			previousTilePosition = tilePosition;
		}
	}

	public void updateTilePosition() 
	{
		Core.biom = Bioms.bioms[Core.mapLayer.GetCellTileData(tilePosition).GetCustomData("name").AsString()];
	}
}
