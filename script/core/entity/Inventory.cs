using System;
using System.Collections.Generic;
using Godot;

public partial class Inventory : Node {
	private List<ItemStack> items;
	public int Length;
	public event Action<List<ItemStack>> inventoryUpdater;

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
				if (items[i].item == stack.item) {
					if (stack.item.stackable) {
						items[i].count += stack.count;
						itemFound = true;
					}
					break;
				}
			}

			if (!itemFound) {
				items.Add(stack);
				Length += 1;
			}
		}
		inventoryUpdate(items);
	}

	public void removeItem(params ItemStack[] itemStacks) {
		foreach (ItemStack stack in itemStacks) {
			for (int i = 0; i < items.Count; i++) {
				if (items[i].item == stack.item) {
					if (stack.item.stackable) {
						if (items[i].count >= stack.count) {
							items[i].count -= stack.count;
							if (items[i].count == 0) {
								items.RemoveAt(i);
								Length -= 1;
							}
							inventoryUpdate(items);
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
	protected virtual void inventoryUpdate(List<ItemStack> items) {
		inventoryUpdater?.Invoke(items);
	}
}
