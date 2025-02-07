using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Inventory
{
    
    List<Item> inventory = new List<Item>();

    public void InventoryScene(Player player) // �κ��丮�� ����
    {
        Console.Clear();
        Console.WriteLine("�κ��丮");
        Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
        Console.WriteLine();
        Console.WriteLine("[������ ���]");
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ItemType == 1)
            {
                Console.WriteLine($"- {inventory[i].ChangeEquipMark()}{inventory[i].Name} | ���ݷ� +{inventory[i].GetValue()} | {inventory[i].Inform}");
            }
            else if (inventory[i].ItemType == 2)
            {
                Console.WriteLine($"- {inventory[i].ChangeEquipMark()}{inventory[i].Name} | ���� +{inventory[i].GetValue()} | {inventory[i].Inform}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("1. ���� ����");
        Console.WriteLine("0. ������");
        int input = Utility.GetInput(0, 1);
        switch (input)
        {
            case 0:
                //���� �� �ҷ�����
                break;
            case 1:
                EquipManagement(player);
                break;
            default:
                break;
        }
    }

    public void EquipManagement(Player player) // ���� ���� �޼���
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("�κ��丮");
            Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
            Console.WriteLine();
            Console.WriteLine("[������ ���]");
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {inventory[i].ChangeEquipMark()}{inventory[i].Name} | ���ݷ� +{inventory[i].GetValue()} | {inventory[i].Inform}");
                }
                else if (inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {inventory[i].ChangeEquipMark()}{inventory[i].Name} | ���� +{inventory[i].GetValue()} | {inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, inventory.Count);
            if (input == 0)
            {
                InventoryScene(player);
            }
            else if (input > 0 && input <= inventory.Count)
            {

                //inventory[input-1]�� ����
                if(inventory[input - 1].IsEquiped)                   
                {
                    UnEquip(player, inventory[input - 1]);                    
                }
                else
                {                   
                    Equip(player, inventory[input - 1]);
                }
                EquipManagement(player);
            }
        }
    }

    public void Equip(Player player, Item item)
    {
        List<Item> find = inventory.FindAll(inventoryitem => inventoryitem.IsEquiped == true);
        foreach(Item Equipeditem in find)
        {
            UnEquip(player, Equipeditem);
        }
        item.IsEquiped = true;
        if (item.ItemType == 1) //����
        {            
            player.Atk += item.GetValue();
        }
        else if(item.ItemType == 2)//��
        {
            player.Def += item.GetValue();
        }
    }

    public void UnEquip(Player player, Item item)
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