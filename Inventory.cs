using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Inventory
{
    public void InventoryScene(GameManager gameManager) // 인벤토리씬 띄우기
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < gameManager.inventory.Count; i++)
            {
                if (gameManager.inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | 공격력 +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
                else if (gameManager.inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"- {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | 방어력 +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            int input = Utility.GetInput(0, 1);
            if(input == 0) // 0을 눌렀을 대는 SelectMenu로 이동
            {
                break;
            }
            else if(input == 1)
            {
                EquipManagement(gameManager);  //장착관리 띄우기
            }
        }       
    }

    public void EquipManagement(GameManager gameManager) // 장착 관리 메서드
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < gameManager.inventory.Count; i++)
            {
                if (gameManager.inventory[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | 공격력 +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
                else if (gameManager.inventory[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventory[i].ChangeEquipMark()}{gameManager.inventory[i].Name} | 방어력 +{gameManager.inventory[i].GetValue()} | {gameManager.inventory[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            int input = Utility.GetInput(0, gameManager.inventory.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.inventory.Count)
            {

                //inventory[input-1]을 장착
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

    public void Equip(GameManager gameManager, Item item) // 아이템 장착 메서드
    {
        List<Item> find = gameManager.inventory.FindAll(inventoryitem => inventoryitem.IsEquiped == true); // 장착된 장비가 있는지 확인
        foreach (Item Equipeditem in find) //장착된 장비 해제
        {
            UnEquip(gameManager.player, Equipeditem);
        }
        item.IsEquiped = true;
        if (item.ItemType == 1) //무기
        {
            gameManager.player.Atk += item.GetValue();
        }
        else if (item.ItemType == 2)//방어구
        {
            gameManager.player.Def += item.GetValue();
        }
    }

    public void UnEquip(Player player, Item item) // 아이템 해제 메서드
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