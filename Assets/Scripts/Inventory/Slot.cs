using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory; // ��������� ��� ���������
    public int i; // ��������� ������ ��������, ������� ����� ������ � ����� �����

    private void Start()
    { // �������� ��������� ��������� � ������ ������, �� ���� � ������� � ����� Player
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update() // ������� Update �������� ������ ����, ����� �� �������� � ����
    { 
        if (transform.childCount <= 0) // childCount ��� �������, ������� ��������� ������ ������ �����
            inventory.isFull[i] = false; // ���� �� ���, �� ���� � ��� ������
    }

    public void DropItem() // ��� ������� ����� ����������� �������� �� ������ ���������
    {
        // foreach ������ ��� ������� ������� ��� ����� ������
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem(); // ���������� ��� �� ����
                                                            // ������� ��� ����������� ��������
            GameObject.Destroy(child.gameObject); // ���������� ��� ������ �� ���������
        }
    }
}
