namespace EIEIE_Project;

public class Store
{
    GameManager gm;
    public void StoreScreen(Player player, List<Item> inventory)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 \n필요한 물건을 사고 팔 수 있는 곳입니다. 상점이다!!!!!!!!!!\n");
            Console.WriteLine($"[보유 골드] : {player.Gold}G \n");
            Console.WriteLine("[아이템 목록] \n");

            for (int i = 0; i < gm.itemList.Count; i++)
            {
                Item item = gm.itemList[i];
                string str = item.ItemType == 1 ? "공격력: " : "방어력: ";
                string strPrice = gm.itemList[i].IsBought ? "구매완료" : $"{item.Price} G";
                Console.WriteLine($" - {item.ChangeEquipMark()} {item.Name} | {item.ItemType} +{item.GetValue()}| {item.Inform} | {strPrice}");
            }

            Console.WriteLine("1. 아이템 구매 \n2. 아이템 판매 \n0. 나가기");

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
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매 \n아이템을 구매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            for (int i = 0; i < gm.itemList.Count; i++)
            {
                Item item = gm.itemList[i];
                string str = item.ItemType == 1 ? "공격력: " : "방어력: ";
                string strPrice = gm.itemList[i].IsBought ? "구매완료" : $"{item.Price} G";
                //ItemType에 따라 bool로 정한 것이므로 추후 아이템 타입이 추가될 경우 변경해야함
                Console.WriteLine($"{i + 1}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {strPrice}");
            }

            Console.WriteLine("구매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, gm.itemList.Count);

            if (num != 0)
            {
                num++;
                if (gm.itemList[num].IsBought)
                {
                    Console.Clear();
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (player.Gold >= gm.itemList[num].Price)
                {
                    gm.itemList[num].IsBought = true;
                    inventory.Add(gm.itemList[num]);
                    player.Gold -= gm.itemList[num].Price;
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
            else
            {
                break;
            }
        }
    }

    public void SellItem(Player player, List<Item> inventory)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매 \n아이템을 판매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            for (int i = 0; i < inventory.Count; i++)//인벤토리 아이템 만큼
            {
                Item item = inventory[i];
                float sellNum = (float)item.Price * 0.85f;
                string str = item.ItemType == 1 ? "공격력: " : "방어력: ";

                //ItemType에 따라 bool로 정한 것이므로 추후 아이템 타입이 추가될 경우 변경해야함
                //소지 중인 아이템의 번호가 아이템ID와 관계 없이 순차적으로 표시됨
                Console.WriteLine($"{i + 1}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {sellNum.ToString("N0")}");
            }
            Console.WriteLine("판매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, inventory.Count); //0에서 인벤토리 아이템 개수까지
            if (num != 0)
            {
                Item item = inventory[num - 1]; //아이템 순번이 1부터 시작하므로 input에서 1을 뺀 값을 임시 item에 추가
                int itemID = item.ItemID; //선택된 아이템의 itemID를 반환함
                if (item.IsEquiped) item.IsEquiped = false; //장착 중이었다면 해제함
                float sellNum = inventory[num - 1].Price * 0.85f; //판매 가격 설정
                player.Gold += (int)sellNum; //플레이어 골드에 판매 가격 추가
                inventory.Remove(inventory[num - 1]); //해당 아이템을 inventory에서 제거
                Console.Clear();
                Console.WriteLine($"{gm.itemList[itemID - 1].Name} 아이템을 판매했습니다.");
                SellItem(player, inventory);
            }
            else
            {
                break;
            }

        }
    }
}