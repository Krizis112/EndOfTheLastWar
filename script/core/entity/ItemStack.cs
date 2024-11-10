public class ItemStack {
    public int count;
    public ItemType type;

    public ItemStack(ItemType itemType, int count) {
        type = itemType;
        this.count = count;
    }
}