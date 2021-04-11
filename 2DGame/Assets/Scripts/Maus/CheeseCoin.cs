using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCoin : MonoBehaviour
{
    private bool cheeseCoinCollected;

    public GameObject cheeseCoin;
     
    public Image cheeseCoinImage;
    public Sprite collectedCheeseCoin;
    public Sprite missingCheeseCoin;

    // Update is called once per frame
    void Update()
    {
        if (cheeseCoinCollected == true)
        {
            cheeseCoinImage.sprite = collectedCheeseCoin;
        }
        else
        {
            //gibt eine NullReferenceException aus, wahrscheinlich weil das Image zum Canvas geh�rt, auf den die Maus keinen Zugriff hat
            cheeseCoinImage.sprite = missingCheeseCoin;
        }

        cheeseCoin.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CheeseCoin"))
        {
            cheeseCoinCollected = true;
            collision.gameObject.SetActive(false);
        }
    }
}
