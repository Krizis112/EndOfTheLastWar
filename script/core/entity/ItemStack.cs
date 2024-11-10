public class ItemStack {
    public int count;
    public ItemType item;

    public ItemStack(ItemType itemType, int count) {
        this.item = itemType;
        this.count = count;
    }
}