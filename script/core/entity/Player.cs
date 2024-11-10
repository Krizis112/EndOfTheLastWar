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
        previousTilePosition = Core.mapLayer.LocalToMap(Position);
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
