namespace EIEIE_Project;

public class Store
{
    bool IsSellOrBuy = false; //구매, 또는 판매 중일 때 true가 됨

    public void PrintItem(GameManager gm) //아이템 목록을 출력함
    {
        string strNum = " - "; //strNum 값을 " - "로 초기화
        Console.WriteLine("==장비=============");
        for (int i = 0; i < gm.equipments.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - ";  //상점 창에서 아이템 번호 대신 " - "를 출력함
            else //구매 또는 판매 중일 때
            {
                int number = i + 1; //아이템 번호 값에 1을 더해 1번부터 시작하게 함
                strNum = number.ToString() + "."; //아이템 번호를 문자열로 변환해 strNum에 저장
            }
            Equipment item = gm.equipments[i]; //장비 아이템을 item에 저장
            string str = item.ItemType == 0 ? "공격력: " : "방어력: "; //아이템의 아이템 타입에 따라, 0이면 공격력이고 아니라면 방어력으로 출력
            string strPrice = item.IsBought ? "구매완료" : $"{item.Price} G"; //아이템을 이미 구매했는가의 여부에 따라 구매완료 또는 가격을 출력
            Console.WriteLine($" {strNum}{item.ChangeEquipMark()} {item.Name} | {str} +{item.GetValue()}| {item.Inform} | {strPrice}");
            //아이템 순번, 아이템 장착 여부, 아이템 이름, 아이템 타입, 아이템 스탯 증가/감소 수치, 아이템 정보, 아이템 가격 출력
        }

        int consumableNum = gm.equipments.Count + 1;//소모품 번호는 장비 개수보다 1 많게 지정

        Console.WriteLine("==소모품=============");
        for (int i = 0; i < gm.consumables.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - "; //상점 창에서 아이템 번호 대신 " - "를 출력함
            else
            {
                strNum = consumableNum.ToString() + "."; //소모품 번호를 string 값으로 변환 후 마침표 찍어주기
            }
            Consumable item = gm.consumables[i];
            string str = "버프: ";
            Console.WriteLine($" {strNum} {item.Name} | {str} +{item.BuffAmount} | {item.Inform} | {item.Price}G | 보유 개수: {item.Count}");
            //아이템 순번, 이름, 버프 + 버프 수치, 아이템 정보, 아이템 가격, 보유 개수 출력
        }
    }
    public void StoreScreen(GameManager gm) //상점 창 열람
    {
        while (true)
        {
            IsSellOrBuy = false; //이 창이 열리면 구매 또는 판매 중이 아님
            Console.WriteLine("상점 \n필요한 물건을 사고 팔 수 있는 곳입니다.\n");
            Console.WriteLine($"[보유 골드] : {gm.player.Gold}G \n");
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(gm); //아이템 목록 출력

            Console.WriteLine("1. 아이템 구매 \n2. 아이템 판매 \n0. 나가기");
            int num = Utility.GetInput(0, 2); //0~2 사이 입력 가능
            if (num == 1)
            {
                Console.Clear();
                BuyItem(gm); //1을 입력하면 아이템 구매
            }
            else if (num == 2)
            {
                Console.Clear();
                SellItem(gm); //2를 입력하면 아이템 판매
            }
            else break;
        }
    }

    public void BuyItem(GameManager gm) //아이템 구매
    {
        while (true)
        {
            IsSellOrBuy = true; //구매 또는 판매 중임으로 변경
            Console.WriteLine("상점 - 아이템 구매 \n아이템을 구매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {gm.player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(gm); //아이템 목록 출력

            Console.WriteLine("구매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, gm.itemList.Count); //0부터 아이템 개수까지의 입력 가능

            if (num != 0)
            {
                num--; //아이템 목록은 1번부터 출력되지만 실제 아이템 리스트는 0번부터 시작하므로 1을 차감함
                if (gm.itemList[num].ItemType != 2) //장비 또는 방어구일 때
                {
                    Equipment item = (Equipment)gm.itemList[num];
                    if (item.IsBought) //이미 구매한 상품이라면
                    {
                        Console.Clear();
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (gm.player.Gold >= item.Price)
                    {
                        item.IsBought = true; //구매 완료 상태로 변경
                        gm.inventoryEquipment.Add(item); //인벤토리에 아이템 추가
                        gm.player.Gold -= item.Price; //골드 차감
                        Console.Clear();
                        Console.WriteLine($"==={item.Name} 아이템을 구매했습니다.===\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;
                }
                else //소모품일 경우
                {
                    Consumable item = (Consumable)gm.itemList[num];
                    if(item.Count < item.MaxCount)
                    {
                        if (gm.player.Gold >= item.Price) //소모품은 계속 구매 가능
                        {
                            gm.inventoryConsumables.Add(item); //인벤토리에 아이템 추가
                            gm.player.Gold -= item.Price; //골드 차감
                            item.Count++; //소모품 개수 1 증가
                            Console.Clear();
                            Console.WriteLine($"==={item.Name} 아이템을 구매했습니다.===\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("보유 한도를 초과했습니다.");
                    }                
                }
            }
            else //나가기를 누름
            {
                IsSellOrBuy = false;
                break;
            }
        }
    }

    public void SellItem(GameManager gm)
    {
        while (true)
        {
            IsSellOrBuy = true;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매 \n아이템을 판매할 수 있습니다. \n");
            Console.WriteLine($"[보유 골드] : {gm.player.Gold} G \n");
            Console.WriteLine("[아이템 목록] \n");

            Console.WriteLine("==장비=============");

            string strNum = " - ";
            for (int i = 0; i < gm.inventoryEquipment.Count; i++)
            {
                if (!IsSellOrBuy) strNum = " - ";
                else
                {
                    int number = i + 1;
                    strNum = number.ToString() + ".";
                }
                Equipment equipItem = gm.inventoryEquipment[i];
                string str = equipItem.ItemType == 0 ? "공격력: " : "방어력: ";
                float sellNum = equipItem.Price * 0.85f; //판매 가격 설정
                string sellPrice = sellNum.ToString("N0"); //판매 가격을 소수점 위로 출력되게 함
                Console.WriteLine($" {strNum}{equipItem.ChangeEquipMark()} {equipItem.Name} | {str} +{equipItem.GetValue()}| {equipItem.Inform} | {sellPrice} G");
            }
            int consumableNum = gm.inventoryEquipment.Count + 1;

            Console.WriteLine("==소모품=============");
            for (int i = 0; i < gm.inventoryConsumables.Count; i++)
            {
                if (!IsSellOrBuy) strNum = " - ";
                else
                {
                    strNum = consumableNum.ToString() + ".";
                }
                Consumable consumeItem = gm.inventoryConsumables[i];
                string str = "버프: ";
                float sellNum = consumeItem.Price * 0.85f; //판매 가격 설정
                string sellPrice = sellNum.ToString("N0"); //판매 가격을 소수점 위로 출력되게 함
                Console.WriteLine($" {strNum} {consumeItem.Name} | {str} +{consumeItem.BuffAmount} | {consumeItem.Inform} | {sellPrice} G | 보유 개수: {consumeItem.Count}");
            }

            Console.WriteLine("판매할 아이템의 번호를 누르세요.");
            Console.WriteLine("0. 나가기");

            int num = Utility.GetInput(0, gm.inventoryEquipment.Count + gm.inventoryConsumables.Count); //0에서 인벤토리 아이템 개수까지
            if (num != 0)
            {
                num--;
                if (num < gm.inventoryEquipment.Count) //아이템이 장비일 때
                {
                    Equipment equipItem = gm.inventoryEquipment[num];
                    equipItem.IsBought = false; //구매 상태를 false로 변경
                    int equipID = equipItem.ItemID; //선택된 아이템의 itemID를 반환함
                    if (equipItem.IsEquiped) equipItem.IsEquiped = false; //장착 중이었다면 해제함
                    float sellPrice = equipItem.Price * 0.85f;
                    gm.player.Gold += (int)sellPrice; //플레이어 골드에 판매 가격 추가
                    gm.inventoryEquipment.Remove(equipItem); //해당 아이템을 inventory에서 제거
                    Console.Clear();
                    Console.WriteLine($"==={gm.itemList[equipID].Name} 아이템을 판매했습니다.===\n");
                }
                else //아이템이 소모품일 때
                {
                    Consumable consumable = gm.inventoryConsumables[num - gm.inventoryEquipment.Count];
                    int consumeID = consumable.ItemID;
                    float sellPrice = consumable.Price * 0.85f; //판매 가격 설정
                    gm.player.Gold += (int)sellPrice; //플레이어 골드에 판매 가격 추가
                    if (consumable.Count > 0) consumable.Count--; //아이템 개수 차감
                    Console.Clear();
                    Console.WriteLine($"==={gm.itemList[consumeID - 1].Name} 아이템을 판매했습니다.===\n");
                }
                break;
            }
            else //나가기를 누름
            {
                IsSellOrBuy = false;
                break;
            }
        }
    }
}