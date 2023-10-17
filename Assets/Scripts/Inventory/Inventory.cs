using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull; // ������ ������ ����� ��������� �������� �� ��� ���������
    public GameObject[] slots; // � ��� ������ ��������, �� ���� ���� �����

    // ������ ��� ���� ������� ���������, �� ���� ��� ������� �� ������ �� ����� ����������� ��� �����������
    public GameObject inventory;
    public bool inventoreOn; // ������ �� ���������

    private void Start()
    {
        inventoreOn = false;
    }

    public void Chest()
    {
        if (inventoreOn == false) // ���� ������ ������, �� ��������� � ��������
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
