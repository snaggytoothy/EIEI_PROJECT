using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Inventory
{
    
    List<Item> inventory = new List<Item>();

    public void InventoryScene(Player player) // 인벤토리씬 띄우기
    {
        Console.Clear();
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ItemType == 1)
            {
                Console.WriteLine($"- {inventory[i].ChangeEquipMark()}{inventory[i].Name} | 공격력 +{inventory[i].GetValue()} | {inventory[i].Inform}");
            }
            else if (inventory[i].ItemType == 2)
            {
                Console.WriteLine($"- {inventory[i].ChangeEquipMark()}{inventory[i].Name} | 방어력 +{inventory[i].GetValue()} | {inventory[i].Inform}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        int input = Utility.GetInput(0, 1);
        switch (input)
        {
            case 0:
                //메인 씬 불러오기
                break;
            case 1:
                EquipManagement(player);
                break;
            default:
                break;
        }
    }

    public void EquipManagement(Player player) // 장착 관리 메서드
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {inventory[i].ChangeEquipMark()}{inventory[i].Name} | 공격력 +{inventory[i].GetValue()} | {inventory[i].Inform}");
                }
                else if (inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {inventory[i].ChangeEquipMark()}{inventory[i].Name} | 방어력 +{inventory[i].GetValue()} | {inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            int input = Utility.GetInput(0, inventory.Count);
            if (input == 0)
            {
                InventoryScene(player);
            }
            else if (input > 0 && input <= inventory.Count)
            {

                //inventory[input-1]을 장착
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
        if (item.ItemType == 1) //무기
        {            
            player.Atk += item.GetValue();
        }
        else if(item.ItemType == 2)//방어구
        {
            player.Def += item.GetValue();
        }
    }

    public void UnEquip(Player player, Item item)
    {
        item.IsEquiped = false;
        if (item.ItemType == 1) //무기
        {
            player.Atk -= item.GetValue();
        }
        else if (item.ItemType == 2)//방어구
        {
            player.Def -= item.GetValue();
        }
    }

    
}