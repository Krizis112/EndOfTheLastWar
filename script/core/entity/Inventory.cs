using System.Collections.Generic;
using Godot;

public partial class Inventory : Node {
	private List<ItemStack> items;
	public int Length;

	public override void _Ready() {
		load();
	}

	public void load() {
		items = new List<ItemStack>();
		Core.inventory = this;
	}

	public void addItem(params ItemStack[] itemStacks) {
		foreach (ItemStack stack in itemStacks) {
			bool itemFound = false;
			for (int i = 0; i < items.Count; i++) {
				if (items[i].item.itemType == stack.item.itemType) {
					if (stack.item.itemType.stackable) {
						items[i].count += stack.count;
						itemFound = true;
					}
					break;
				}
			}

			if (!itemFound) {
				items.Add(stack);
				Length += itemStacks.Length;
			}
		}
	}

	public void removeItem(params ItemStack[] itemStacks) {
		GD.Print(items[0].count);
		foreach (ItemStack stack in itemStacks) {
			for (int i = 0; i < items.Count; i++) {
				if (items[i].item.itemType == stack.item.itemType) {
					if (stack.item.itemType.stackable) {
						if (items[i].count >= stack.count) {
							items[i].count -= stack.count;
							if (items[i].count == 0) {
								items.RemoveAt(i);
								Length -= 1;
							}
							return;
						} else {
							GD.Print("Not enough items to remove: " + stack.count);
							return;
						}
					}
				}
			}
		}
	}
}
