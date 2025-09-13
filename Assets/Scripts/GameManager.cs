using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static bool allowedMovement = true;

    [SerializeField]
    public Item[] hotbar = new Item[6];
    public Item[] itemlist;
    void Start() { }

    void Update() { }
}
