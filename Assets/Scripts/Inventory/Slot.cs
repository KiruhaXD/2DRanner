using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory; // указываем наш инвентарь
    public int i; // указываем объект предмета, который будет лежать в нашем слоте

    private void Start()
    { // получаем компонент инвенторя у нашего игрока, то есть у объекта с тегом Player
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update() // функция Update работает каждый кадр, когда мы находися в игре
    { 
        if (transform.childCount <= 0) // childCount это объекты, которые находятся внутри нашего слота
            inventory.isFull[i] = false; // если их нет, то слот у нас пустой
    }

    public void DropItem() // эта функция будет выбрасывать предметы из нашего инвенторя
    {
        // foreach значит для каждого объекта под нашим слотом
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem(); // возвращаем его на нашу
                                                            // локацию при выкидывания предмета
            GameObject.Destroy(child.gameObject); // уничтожаем наш объект из инвенторя
        }
    }
}
