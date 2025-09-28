using UnityEngine;
using System.Collections;
public class Tree : MonoBehaviour
{
    public Animator animator;
    public int health = 10;
    bool damaged = false;
    public int multiplier = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Axe")){
            if(ItemManager.active && !damaged){
                StartCoroutine(StartShake());
            }
        }
    }
    IEnumerator StartShake()
    {
        animator.play("Shake");
        damaged = true;
        health--;
        ItemManager.addItem(ResourceType.wood, 1);
        yield return new WaitForSeconds(1.2F);
        damaged = false;
    }
}
