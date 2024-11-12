public class FoodItemType : ItemType
{
    public int recoveryFood = 30;
    public int recoveryWater = 30;
    public int heal = 10;
    
    public FoodItemType(string name) : base(name)
    {

    }
}