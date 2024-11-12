using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Inventory : Node {
	private Dictionary<ItemType, ItemStack> itemStacks;
	private List<Item> items;

	public int length => itemStacks.Count + items.Count;

	public event Action<List<ItemStack>> stackUpdater;
	public event Action<List<Item>> itemUpdater;

	public override void _Ready() {
		load();
	}

	public void load() {
		itemStacks = new Dictionary<ItemType, ItemStack>();
		items = new List<Item>();
		Core.inventory = this;
	}

	public void addItemStack(params ItemStack[] itemStacksToAdd) {
		foreach (ItemStack stack in itemStacksToAdd) {
			if (itemStacks.TryGetValue(stack.type, out var existingStack)) {
				if (stack.type.stackable) {
					existingStack.count += stack.count;
				}
			} else {
				itemStacks[stack.type] = stack;
			}
		}
		inventoryUpdateStacks();
	}

	public void removeItemStack(params ItemStack[] itemStacksToRemove) {
		foreach (ItemStack stack in itemStacksToRemove) {
			if (itemStacks.TryGetValue(stack.type, out ItemStack existingStack)) {
				if (stack.type.stackable) {
					if (existingStack.count >= stack.count) {
						existingStack.count -= stack.count;

						if (existingStack.count == 0) {
							itemStacks.Remove(stack.type);
						}
					} else {
						Item item = new Item();
						item.itemType = itemStacksToRemove[itemStacksToRemove.Length].type;
						addItem(item);
					}
				}
			}
		}
		inventoryUpdateStacks();
	}

	public ItemStack getItemStack(ItemType type) {
		itemStacks.TryGetValue(type, out ItemStack itemStack);
		return itemStack;
	}

	public void addItem(Item item) {
		items.Add(item);
		inventoryUpdateItems();
	}

	public void removeItem(Item item) {
		items.Remove(item);
		inventoryUpdateItems();
	}

	public List<Item> getItems() {
		return items;
	}

	protected virtual void inventoryUpdateStacks() {
		stackUpdater?.Invoke(itemStacks.Values.ToList());
	}

	protected virtual void inventoryUpdateItems() {
		itemUpdater?.Invoke(items);
	}
}
