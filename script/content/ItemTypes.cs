public class ItemTypes {
    public static ItemType water, wood;

    public static void load() {
        water = new ItemType("water") {
            stackable = true
        };
        wood = new ItemType("wood") {
            stackable = true
        };
    }
}