namespace EIEIE_Project;

public class Store
{
    GameManager gm;
    Player player;
    List<Item> inventory;
    bool IsSellOrBuy = false;

    public void PrintItem(Player player, List<Item> inventory)
    {
        string strNum = " - ";
        Console.WriteLine("==장비=============");
        for (int i = 0; i < gm.itemList.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - ";
            else strNum = i + 1.ToString();
            Equipment item = (Equipment)gm.itemList[i];
            string str = item.ItemType == 0 ? "공격력: " : "방어력: ";
            string strPrice = item.IsBought ? "구매완료" : $"{item.Price} G";
            Console.WriteLine($" {strNum} {item.ChangeEquipMark()} {item.Name} | {item.ItemType} +{item.GetValue()}| {item.Inform} | {strPrice}");
        }

        Console.WriteLine("==소모품=============");
        for (int i = 0; i < gm.itemList.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - ";
            else strNum = i + 1.ToString();
            Consumable item = (Consumable)gm.itemList[i];
            string str = "버프: ";
            Console.WriteLine($"{strNum}. {item.Name} | {str} +{item.BuffAmount} | {item.Inform} | {item.Price} | 보유 개수: {item.Count}");
        }
    }
    public void StoreScreen(Player player, List<Item> inventory)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 \n필요한 물건을 사고 팔 수 있는 곳입니다. 상점이다!!!!!!!!!!\n");
            Console.WriteLine($"[보유 골드] : {player.Gold}G \n");
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(player, inventory);

            Console.WriteLine("1. 아이템 구매 \n2. 아이템 판매 \n0.나가기");

            //입력한 값이 숫자가 맞는지 확인
            int num = Utility.GetInput(0, 2);
            if (num == 1) BuyItem(player, inventory);
            else if (num == 2) SellItem(player, inventory);
            else break;
        }
    }

    public void BuyItem(Player player, List<Item> inventory)
    {
        while (true)
        {
            IsSellOrBuy = true;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매 \n아이템을 구매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            Console.WriteLine("==장비=============");

            PrintItem(player, inventory);

            Console.WriteLine("구매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, gm.itemList.Count); //0부터 아이템 개수까지의 입력 가능

            if (num != 0)
            {
                num--; //표면상 아이템이 1번부터 출력되지만 실제 리스트는 0번부터 시작하므로 1을 뺌
                if (gm.itemList[num].ItemType != 2) //소모품이 아닐 경우
                {
                    Equipment item = (Equipment)gm.itemList[num];
                    if (item.IsBought) //이미 구매한 상품이라면
                    {
                        Console.Clear();
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= gm.itemList[num].Price)
                    {
                        item.IsBought = true; //구매 완료 상태로 변경
                        inventory.Add(gm.itemList[num]); //인벤토리에 해당 아이템 추가
                        player.Gold -= gm.itemList[num].Price; //골드 차감
                        Console.Clear();
                        Console.WriteLine($"{gm.itemList[num].Name} 아이템을 구매했습니다.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    BuyItem(player, inventory);
                }
                else //소모품일 경우
                {
                    Consumable item = (Consumable)gm.itemList[num];
                    if (player.Gold >= gm.itemList[num].Price) //소모품은 계속 구매 가능
                    {
                        inventory.Add(gm.itemList[num]); //인벤토리에 아이템 추가
                        player.Gold -= gm.itemList[num].Price; //골드 차감
                        item.Count++; //소모품 개수 1 증가
                        Console.Clear();
                        Console.WriteLine($"{gm.itemList[num].Name} 아이템을 구매했습니다.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    BuyItem(player, inventory);
                }
            }
            else //나가기를 누름
            {
                IsSellOrBuy = false;
                break;
            }
        }
    }

    public void SellItem(Player player, List<Item> inventory)
    {
        while (true)
        {
            IsSellOrBuy = true;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매 \n아이템을 판매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(player, inventory);

            Console.WriteLine("판매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, inventory.Count); //0에서 인벤토리 아이템 개수까지
            if (num != 0)
            {
                num--;
                if (inventory[num].ItemType != 2) //아이템이 장비일 때
                {
                    Equipment item = (Equipment)inventory[num]; //아이템 순번이 1부터 시작하므로 input에서 1을 뺀 값을 임시 item에 추가
                    int itemID = item.ItemID; //선택된 아이템의 itemID를 반환함
                    if (item.IsEquiped) item.IsEquiped = false; //장착 중이었다면 해제함
                    float sellNum = inventory[num].Price * 0.85f; //판매 가격 설정
                    player.Gold += (int)sellNum; //플레이어 골드에 판매 가격 추가
                    inventory.Remove(inventory[num]); //해당 아이템을 inventory에서 제거
                    Console.Clear();
                    Console.WriteLine($"{gm.itemList[itemID].Name} 아이템을 판매했습니다.");
                }
                else //아이템이 소모품일 때
                {
                    Consumable consumable = (Consumable)inventory[num];
                    int itemID = consumable.ItemID;
                    float sellNum = inventory[num].Price * 0.85f; //판매 가격 설정
                    player.Gold += (int)sellNum; //플레이어 골드에 판매 가격 추가
                    if (consumable.Count <= 0) inventory.Remove(inventory[num]); //아이템 개수가 0이 되면 인벤토리에서 제거
                    else consumable.Count--; //아이템 개수 차감
                    Console.Clear();
                    Console.WriteLine($"{gm.itemList[itemID].Name} 아이템을 판매했습니다.");
                }
                SellItem(player, inventory);
            }
            else //나가기를 누름
            {
                IsSellOrBuy = false;
                break;
            }
        }
    }
}