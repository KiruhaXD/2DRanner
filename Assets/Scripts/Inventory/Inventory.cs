using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull; // данный массив будет проверять заполнен ли наш инвентарь
    public GameObject[] slots; // и сам массив объектов, то есть наши слоты

    // теперь нам надо закрыть инвентарь, то есть при нажатии на сундук он будет открываться или закрываться
    public GameObject inventory;
    public bool inventoreOn; // открыт ли инвентарь

    private void Start()
    {
        inventoreOn = false;
    }

    public void Chest()
    {
        if (inventoreOn == false) // если сундук закрыт, то открываем и наоборот
        {
            inventoreOn = true;
            inventory.SetActive(true);
        }
        else if (inventoreOn == true) 
        {
            inventoreOn = false;
            inventory.SetActive(false);
        }
            

    }
}
