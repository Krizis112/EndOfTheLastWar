public class ItemTypes {
    public static ItemType water, wood;

    public static void load() {
        water = new FoodItemType("water") {
            stackable = true,
            recoveryFood = 0,
            recoveryWater = 35,
            heal = 0
        };
        wood = new ItemType("wood") {
            stackable = true
        };
    }
}