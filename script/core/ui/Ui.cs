using Godot;

public partial class Ui : CanvasLayer
{
	public Control inventory;
  public InventoryUI inventoryUI;
	public override void _Ready()
	{
		inventory = GetNode<Control>("Inventory");
	  inventoryUI = inventory.GetNode<InventoryUI>("InventoryUI");
		Core.inventory.stackUpdater += (stack) => {
			inventoryUI.updateSlots(stack.ToArray());
		};
	Core.inventory.addItemStack(new ItemStack(ItemTypes.water, 1000));
	}
	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventMouseButton) {
		  Core.inventory.removeItemStack(new ItemStack(ItemTypes.water, 10));
		}
	}
}
