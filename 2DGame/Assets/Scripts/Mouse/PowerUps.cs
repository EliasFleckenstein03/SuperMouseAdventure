using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool mouseIsGardener;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GardenCheese"))
        {
            mouseIsGardener = true;
            collision.gameObject.SetActive(false);
        }
    }
}
