namespace EIEIE_Project;

public class Store
{
    GameManager gm = new GameManager();

    public void StoreScreen(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("상점 \n필요한 물건을 사고 팔 수 있는 곳입니다. \n");
        Console.WriteLine($"[보유 골드] : {player.Gold}G \n"); //이따 플레이어 골드 여기에 넣어야 함
        Console.WriteLine("[아이템 목록] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            Console.WriteLine($" - {i}. {item.Name} | {item.Inform} | {item.Price}");
        }

        Console.WriteLine("1. 아이템 구매 \n0.나가기");
        
        //입력한 값이 숫자가 맞는지 확인
        bool isNum = int.TryParse(Console.ReadLine(), out int input);
        if (isNum)
        {
            switch (input)
            {
                case 1:
                    BuyItem(player, inventory);
                    break;
                case 0:
                    break;
            }
        }
        else
        {
            WrongInput();
        }
    }

    public void BuyItem(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("상점 - 아이템 구매 \n필요한 물건을 구매합니다. \n");
        Console.WriteLine($"[보유 골드] : {player.Gold} G \n"); //이따 플레이어 골드 여기에 넣어야 함
        Console.WriteLine("[아이템 목록] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            string str = item.ItemType == 1 ? "공격력: " : "방어력: ";
            //ItemType에 따라 bool로 정한 것이므로 추후 아이템 타입이 추가될 경우 변경해야함
            Console.WriteLine($"{i}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {item.Price}");
        }

        Console.WriteLine("구매할 아이템의 번호를 누르세요.");
        Console.WriteLine("0. 나가기");

        Utility.GetInput(0, gm.itemList.Count);
        bool input = int.TryParse(Console.ReadLine(), out int num);
        if (input)
        {
            if (gm.itemList[num].IsBought)
            {
                Console.Clear();
                Console.WriteLine("이미 구매한 아이템입니다.");
                BuyItem(player, inventory);
            }
            else if (player.Gold >= gm.itemList[num].Price)
            {
                gm.itemList[num].IsBought = true;
                inventory.Add(gm.itemList[num]);
                Console.Clear();
                Console.WriteLine($"{gm.itemList[num].Name}을 구매했습니다.");
            }
        }
        Console.WriteLine("");
    }

    public void WrongInput()
    {
        Console.WriteLine("잘못된 입력입니다.");
    }
}