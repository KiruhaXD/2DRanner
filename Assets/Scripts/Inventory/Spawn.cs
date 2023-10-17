using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item; // указываем предмет
    private Transform player; // и позицию нашего игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // получаем эту позицию
    }

    public void SpawnDroppedItem() // функция для появления выкинутого
                                   // объекта из инвенторя на сцене

    {   // насколько далеко относительно игрока будет появляться викинутый предмет  (по X будет смещение на 2 единицы, а по Y на одну единицу)
        Vector2 playerPos = new Vector2(player.position.x + 2, player.position.y - 1);

        // Instantiate() возвращает предмет на локацию (какой предмет, где, Quaternion.identity - сохраняет исходное
        // вращение предмета, чтобы предмет не поворачивался когда будет появляться)
        Instantiate(item, playerPos, Quaternion.identity); 
    } 
}
