public class ItemStack {
    public int count;
    public Item item;

    public ItemStack(Item item, int count) {
        this.item = item;
        this.count = count;
    }
}