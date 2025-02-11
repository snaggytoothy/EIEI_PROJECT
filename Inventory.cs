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
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���ݷ� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("[�Һ� ������ ���]");
            for (int i = 0; i < gameManager.inventoryConsumables.Count; i++)
            {
                if (gameManager.inventoryConsumables[i].Count > 0)
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
                ConsumeManagement(gameManager); // ������ ���â ����
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
                if (gameManager.inventoryEquipment[i].ItemType == 0)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | ���ݷ� +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 1)
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
                if (gameManager.inventoryEquipment[input - 1].IsEquiped) //��� �����Ǿ��ִ��� Ȯ��
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
                if (gameManager.inventoryConsumables[i].Count > 0)
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
                if (gameManager.inventoryConsumables[input - 1].Count > 0)
                {
                    gameManager.inventoryConsumables[input - 1].Use(gameManager.player); //�ش� ������ ���
                }
            }
        }
    }

    public void Equip(GameManager gameManager, Equipment item) // ��� ���� �޼���
    {
        List<Equipment> find = gameManager.inventoryEquipment.FindAll(inventoryitem => inventoryitem.IsEquiped == true && inventoryitem.ItemType == item.ItemType);//������ ��� �ִ��� Ȯ��
        //foreach(Equipment equipment in gameManager.inventoryEquipment)
        //{
        //    Console.WriteLine($"{equipment.ItemID},{equipment.IsEquiped},{equipment.Name}");
        //}
        //Console.ReadKey();
        foreach (Equipment Equipeditem in find) //������ ��� ����
        {
            Equipeditem.UnEquip(gameManager.player);
            //UnEquip(gameManager.player, Equipeditem);
        }
        item.Equip(gameManager.player);
        //item.IsEquiped = true;
        //if (item.ItemType == 0) //����
        //{
        //    gameManager.player.Atk += item.GetValue();
        //}
        //else if (item.ItemType == 1)//��
        //{
        //    gameManager.player.Def += item.GetValue();
        //}
    }

    public void UnEquip(Player player, Equipment item) // ��� ���� �޼���
    {
        item.UnEquip(player);
        //item.IsEquiped = false;
        //if (item.ItemType == 0) //����
        //{
        //    player.Atk -= item.GetValue();
        //}
        //else if (item.ItemType == 1)//��
        //{
        //    player.Def -= item.GetValue();
        //}
    }



}