using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Inventory
{
    public void InventoryScene(GameManager gameManager) // �κ��丮�� ����
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("�κ��丮");
            Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
            Console.WriteLine();
            Console.WriteLine("[������ ���]");
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���ݷ� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 2)
                {
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. ���� ����");
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, 1);
            if (input == 0) // 0�� ������ ��� SelectMenu�� �̵�
            {
                break;
            }
            else if (input == 1)
            {
                EquipManagement(gameManager);  //�������� ����
            }
        }
    }

    public void EquipManagement(GameManager gameManager) // ���� ���� �޼���
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("�κ��丮");
            Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
            Console.WriteLine();
            Console.WriteLine("[������ ���]");
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���ݷ� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, gameManager.inventoryEquipment.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.inventoryEquipment.Count)
            {

                //inventory[input-1]�� ����
                if (gameManager.inventoryEquipment[input - 1].IsEquiped)
                {
                    UnEquip(gameManager.player, gameManager.inventoryEquipment[input - 1]);
                }
                else
                {
                    Equip(gameManager, gameManager.inventoryEquipment[input - 1]);
                }
            }
        }
    }

    public void Equip(GameManager gameManager, Equipment item) // ��� ���� �޼���
    {
        List<Equipment> find = gameManager.inventoryEquipment.FindAll(inventoryitem => inventoryitem.IsEquiped == true); // ������ ��� �ִ��� Ȯ��
        foreach (Equipment Equipeditem in find) //������ ��� ����
        {
            UnEquip(gameManager.player, Equipeditem);
        }
        item.IsEquiped = true;
        if (item.ItemType == 1) //����
        {
            gameManager.player.Atk += item.GetValue();
        }
        else if (item.ItemType == 2)//��
        {
            gameManager.player.Def += item.GetValue();
        }
    }

    public void UnEquip(Player player, Equipment item) // ��� ���� �޼���
    {
        item.IsEquiped = false;
        if (item.ItemType == 1) //����
        {
            player.Atk -= item.GetValue();
        }
        else if (item.ItemType == 2)//��
        {
            player.Def -= item.GetValue();
        }
    }



}