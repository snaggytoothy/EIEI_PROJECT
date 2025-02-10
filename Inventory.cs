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
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | 공격력 +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 2)
                {
                    Console.WriteLine($"- {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | 방어력 +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            int input = Utility.GetInput(0, 1);
            if (input == 0) // 0을 눌렀을 대는 SelectMenu로 이동
            {
                break;
            }
            else if (input == 1)
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
            for (int i = 0; i < gameManager.inventoryEquipment.Count; i++)
            {
                if (gameManager.inventoryEquipment[i].ItemType == 1)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | 공격력 +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
                else if (gameManager.inventoryEquipment[i].ItemType == 2)
                {
                    Console.WriteLine($"-{i + 1}. {gameManager.inventoryEquipment[i].ChangeEquipMark()}{gameManager.inventoryEquipment[i].Name} | 방어력 +{gameManager.inventoryEquipment[i].GetValue()} | {gameManager.inventoryEquipment[i].Inform}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            int input = Utility.GetInput(0, gameManager.inventoryEquipment.Count);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= gameManager.inventoryEquipment.Count)
            {

                //inventory[input-1]을 장착
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

    public void Equip(GameManager gameManager, Equipment item) // 장비 장착 메서드
    {
        List<Equipment> find = gameManager.inventoryEquipment.FindAll(inventoryitem => inventoryitem.IsEquiped == true); // 장착된 장비가 있는지 확인
        foreach (Equipment Equipeditem in find) //장착된 장비 해제
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

    public void UnEquip(Player player, Equipment item) // 장비 해제 메서드
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