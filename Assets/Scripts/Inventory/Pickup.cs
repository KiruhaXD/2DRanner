using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory; // указываем наш инвентарь
    public GameObject slotButton; // указываем объект предмета, который будет лежать в нашем слоте

    private void Start()
    { // получаем компонент иинвенторя у нашего игрока, то есть у объекта с тегом Player
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Данный метод будет работать тогда, когда игрок будет взаимодействовать с предметом,
    // который отправится в инвентарь
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // Данный цикл будет проверять на заполненность нашего инвенторя,
            // чтобы в одном слоте не было кучи всякого хлама
            for (int i = 0; i < inventory.slots.Length; i++) 
            {
                if (inventory.isFull[i] == false) // если слот пустой
                {
                    inventory.isFull[i] = true; // то мы его заполняем

                    // создаем объект в нашем слоте(какой именно объект, в каком именно слоте)
                    Instantiate(slotButton, inventory.slots[i].transform);

                    // мы подобрали объект и у нас он теперь в слоте, затем мы его удаляем из обычной локации
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
