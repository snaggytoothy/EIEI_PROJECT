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
            for (int i = 0; i < gameManager.inventory.Count; i++)
            {
                if (gameManager.inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | ���ݷ� +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
                else if (gameManager.inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"- {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | ���� +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. ���� ����");
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, 1);
            if(input == 0) // 0�� ������ ��� SelectMenu�� �̵�
            {
                break;
            }
            else if(input == 1)
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
            for (int i = 0; i < gameManager.inventory.Count; i++)
            {
                if (gameManager.inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | ���ݷ� +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
                else if (gameManager.inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | ���� +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. ������");
            int input = Utility.GetInput(0, gameManager.inventory.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.inventory.Count)
            {

                //inventory[input-1]�� ����
                if (gameManager.inventory[input - 1].IsEquiped)
                {
                    UnEquip(gameManager.player, gameManager.inventory[input - 1]);
                }
                else
                {
                    Equip(gameManager, gameManager.inventory[input - 1]);
                }
            }
        }
    }

    public void Equip(GameManager gameManager, Item item) // ������ ���� �޼���
    {
        List<Item> find = gameManager.inventory.FindAll(inventoryitem => inventoryitem.IsEquiped == true); // ������ ��� �ִ��� Ȯ��
        foreach (Item Equipeditem in find) //������ ��� ����
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

    public void UnEquip(Player player, Item item) // ������ ���� �޼���
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