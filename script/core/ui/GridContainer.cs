using Godot;

public partial class GridContainer : Godot.GridContainer
{
	private const int cellsCount = 32;
	public Cell[] cells = new Cell[cellsCount];

	public override void _Ready()
	{
		ItemTypes.load();
		for(int i = 0; i < cellsCount; i++) {
			cells[i] = GetChild<Cell>(i);
		}
	}
	public void updateSlots(params ItemStack[] items) {
		for(int i = 0; i < items.Length; i++) {
			ItemType itemType = items[i].item.itemType;
			cells[i].changeTexture(items[i].item.itemType.texture2D);
			if(itemType.stackable) {
				cells[i].label.Text = items[i].count.ToString();
			} else {
				cells[i].label.Visible = false;
			}
		}
	}
}
