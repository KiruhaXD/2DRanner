using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // это нужно для сохранения
public class Dialogue 
{
    public string name;
    [TextArea(3, 10)] // минимальное колчиество строк: 3, максимальное: 10
    public string[] sentences;
}
