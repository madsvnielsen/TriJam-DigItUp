using UnityEngine;

public static class InventoryManager
{
    public static int Goldium { get; private set; }
    public static int Spacesonium { get; private set; }
    public static int Copperium { get; private set; }
    public static void Reset()
    {
        Goldium = 0;
        Spacesonium = 0;
        Copperium = 0;
    }
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
            case ResourceType.Copperium:
                Copperium += amount;
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
            case ResourceType.Copperium:
                Copperium -= amount;
                break;
        }
    }
}
public enum ResourceType
{
    Golduim,
    Spacesonium,
    Copperium,
    Stone

}
