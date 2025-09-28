using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemEquipped ItemEquipped = ItemEquipped.Axe;
    public static bool active = false;
    public static int wood = 0;
    public static int stone = 0;
    public static int metal = 0;
    public static void addItem(ResourceType reosurce, int multiplier){
    if(resource == ResourceType.wood){
        wood+= multiplier;
        
    }
    if(resource == ResourceType.stone){
        stone+= multiplier;
        
    }
    if(resource == ResourceType.ore){
        metal+= multiplier;
        
    }
}
}




public enum ItemEquipped {
    Axe, Pickaxe

}
public enum ResourceType {
    wood, stone, ore    
}