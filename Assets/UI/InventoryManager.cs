using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static int Goldium { get; private set; }
    public static int Spacesonium { get; private set; }
    public static int Copperium { get; private set; }

    private static TMP_Text copperCountTxt;
    private static TMP_Text goldCountTxt;
    private static TMP_Text spaceCountTxt;

    private void Start()
    {
        copperCountTxt = GameObject.Find("copperCount").GetComponent<TMP_Text>();
        goldCountTxt = GameObject.Find("goldCount").GetComponent<TMP_Text>();
        spaceCountTxt = GameObject.Find("spaceCount").GetComponent<TMP_Text>();
        copperCountTxt = GameObject.Find("copperCount").GetComponent<TMP_Text>();
        goldCountTxt = GameObject.Find("goldCount").GetComponent<TMP_Text>();
        spaceCountTxt = GameObject.Find("spaceCount").GetComponent<TMP_Text>();
    }
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
        UpdateResourceCounts();
    }

    private static void UpdateResourceCounts()
    {
        copperCountTxt.SetText(Copperium.ToString());
        goldCountTxt.SetText(Goldium.ToString());
        spaceCountTxt.SetText(Spacesonium.ToString());
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
        UpdateResourceCounts();
    }
}
public enum ResourceType
{
    Golduim,
    Spacesonium,
    Copperium,
    Stone
}
