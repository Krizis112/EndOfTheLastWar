public static class Items {
    public static Item wood, water;

    public static void load() {
        wood = new Item() {
            name = "wood"
        };
        water = new Item() {
            name = "water"
        };
    }

}