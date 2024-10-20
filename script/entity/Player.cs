using Godot;

public partial class Player : Sprite2D 
{
	private Vector2 targetPosition;

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
	}
	public void _Entered() {
		GD.Print("Entered");
	}
}
