public static class InventoryManager
{
    public static int Goldium { get; private set; }
    public static int Spacesonium { get; private set; }
    public static int Steelium { get; private set; }
    public static void addItemToInventory(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Golduim:
                Goldium += amount;
                break;
            case ResourceType.Spacesonium:
                Spacesonium += amount;
                break;
            case ResourceType.Steelium:
                Steelium += amount;
                break;
        }
    }
    public static void removeItemFromInventory(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Golduim:
                Goldium -= amount;
                break;
            case ResourceType.Spacesonium:
                Spacesonium -= amount;
                break;
            case ResourceType.Steelium:
                Steelium -= amount;
                break;
        }
    }
}
public enum ResourceType
{
    Golduim,
    Spacesonium,
    Steelium,

}
