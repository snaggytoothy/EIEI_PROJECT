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
            Console.WriteLine("[��� ���]");
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.inventoryEquipment[i].ItemType == 0)
                {
                    Console.WriteLine($"- {gameManager.equipment[i].ChangeEquipMark()}{gameManager.equipment[i].Name} | ���ݷ� +{gameManager.equipment[i].GetValue()} | {gameManager.equipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.equipment[i].ChangeEquipMark()}{gameManager.equipment[i].Name} | ���� +{gameManager.equipment[i].GetValue()} | {gameManager.equipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("[�Һ� ������ ���]");
            for (int i = 0; i < gameManager.inventoryConsumables.Count; i++)
            {
                if (gameManager.inventoryConsumables[i].IsHad == true)
                {
                    Console.WriteLine($"- {gameManager.inventoryConsumables[i].Name} | {gameManager.inventoryConsumables[i].Inform} | ���� ���� : {gameManager.inventoryConsumables[i].Count}");
                }        
            }
            Console.WriteLine();
            Console.WriteLine("1. ���� ����");
            Console.WriteLine("2. ������ ���");
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, 2);
            if (input == 0) // 0�� ������ ��� SelectMenu�� �̵�
            {
                break;
            }
            else if (input == 1)
            {
                EquipManagement(gameManager);  //��������â ����
            }
            else if (input == 2)
            {
                //������ ���â ����
            }
        }
    }

    public void EquipManagement(GameManager gameManager) // ���� ���� �޼���
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("�κ��丮");
            Console.WriteLine("���� ���� ��� ���� �� ������ �� �ֽ��ϴ�.");
            Console.WriteLine();
            Console.WriteLine("[��� ���]");
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.equipment[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.equipment[i].ChangeEquipMark()}{gameManager.equipment[i].Name} | ���ݷ� +{gameManager.equipment[i].GetValue()} | {gameManager.equipment[i].Inform}");
                }
                else if (gameManager.equipment[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.equipment[i].ChangeEquipMark()}{gameManager.equipment[i].Name} | ���� +{gameManager.equipment[i].GetValue()} | {gameManager.equipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, gameManager.equipment.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.equipment.Count)
            {
                if (gameManager.inventoryEquipment[input - 1].IsEquiped) //�����Ǿ��ִ� ��� �ִ��� Ȯ��
                {
                    UnEquip(gameManager.player, gameManager.equipment[input - 1]);
                }
                else
                {
                    Equip(gameManager, gameManager.equipment[input - 1]);
                }
            }
        }
    }

    public void ConsumeManagement(GameManager gameManager) // ������ ��� �޼���
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("�κ��丮");
            Console.WriteLine("���� ���� �Һ� �������� ����� �� �ֽ��ϴ�.");
            Console.WriteLine();
            Console.WriteLine("[�Һ� ������ ���]");
            for (int i = 0; i < gameManager.inventoryConsumables.Count; i++)
            {
                if (gameManager.inventoryConsumables[i].IsHad == true)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryConsumables[i].Name} | {gameManager.inventoryConsumables[i].Inform} | ���� ���� : {gameManager.inventoryConsumables[i].Count}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, gameManager.inventoryConsumables.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.inventoryConsumables.Count)
            {
                if (gameManager.inventoryConsumables[input - 1].Count >0) 
                {
                    gameManager.inventoryConsumables[input - 1].Use(gameManager.player); //�ش� ������ ���
                }
                if(gameManager.inventoryConsumables[input - 1].Count == 0)
                {
                    gameManager.inventoryConsumables.Remove(gameManager.inventoryConsumables[input - 1]);
                }
            }
        }
    }

    public void Equip(GameManager gameManager, Equipment item) // ��� ���� �޼���
    {
        List<Equipment> find = gameManager.inventoryEquipment.FindAll(inventoryitem => inventoryitem.IsEquiped == true && inventoryitem.ItemID ==item.ItemID); // ������ ��� �ִ��� Ȯ��
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