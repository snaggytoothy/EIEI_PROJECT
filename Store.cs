using System.IO;
using System.Numerics;

namespace EIEIE_Project;

public class Store
{
    //플레이어 직업에 따라 살 수 있는 스킬 제한
    bool IsSellOrBuy = false; //구매, 또는 판매 중일 때 true가 됨
    List<Skil> warriorSkills = new List<Skil>();
    List<Skil> magicianSkills = new List<Skil>();
    public void PrintItem(GameManager gm) //아이템 목록을 출력함
    {
        int consumableNum = 0;
        string strNum = " - "; //strNum 값을 " - "로 초기화
        Utility.ColorWrite("==장비=============\n", ConsoleColor.DarkYellow);
        for (int i = 0; i < gm.equipments.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - ";  //상점 창에서 아이템 번호 대신 " - "를 출력함
            else //구매 또는 판매 중일 때
            {
                int number = i + 1; //아이템 번호 값에 1을 더해 1번부터 시작하게 함
                strNum = number.ToString() + "."; //아이템 번호를 문자열로 변환해 strNum에 저장
            }
            Equipment item = gm.equipments[i]; //장비 아이템을 item에 저장
            string str = item.ItemType == 0 || item.ItemType == 5 ? "공격력: " : "방어력: "; //아이템의 아이템 타입에 따라 공격력 또는 방어력으로 출력

            //해당 아이템이 인벤토리에 있는지 확인
            if (gm.inventoryEquipment.FindAll(x => x.ItemID == item.ItemID).Count >= 1) //해당 아이템이 1개 이상이라면
            {
                item.IsBought = true; //구매 완료 상태로 변경
            }
            string strPrice = item.IsBought ? "소지 중" : $"{item.Price} G"; //아이템이 인벤토리에 있는가의 여부에 따라 소지 중 또는 가격을 출력
            if (item.ShopFlag)
            {
                Console.Write($" {strNum}{item.ChangeEquipMark()} {item.Name} | {str} +{item.GetValue()}| {item.Inform} | ");
                if(strPrice == "소지 중")
                {
                    Utility.ColorWrite(strPrice, ConsoleColor.Green);
                }
                else
                {
                    Utility.ColorWrite(strPrice, ConsoleColor.Yellow);
                }
                Console.WriteLine();
                consumableNum += 1;
            }
            //아이템 순번, 아이템 장착 여부, 아이템 이름, 아이템 타입, 아이템 스탯 증가/감소 수치, 아이템 정보, 아이템 가격 출력
        }

        Console.WriteLine();
        Utility.ColorWrite("==소비=============\n", ConsoleColor.DarkYellow);
        for (int i = 0; i < gm.consumables.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - "; //상점 창에서 아이템 번호 대신 " - "를 출력함
            else
            {
                consumableNum++;
                strNum = consumableNum.ToString() + "."; //소모품 번호를 string 값으로 변환 후 마침표 찍어주기
            }
            Consumable item = gm.consumables[i];
            string str = "버프: ";
            Console.Write($" {strNum} {item.Name} | {str} +{item.BuffAmount} | {item.Inform} | ");
            Utility.ColorWrite($"{item.Price}G", ConsoleColor.Yellow);
            Console.WriteLine($" | 보유 개수: {item.Count}");
            //아이템 순번, 이름, 버프 + 버프 수치, 아이템 정보, 아이템 가격, 보유 개수 출력
        }
        Console.WriteLine();
        Utility.ColorWrite("==스킬=============\n", ConsoleColor.DarkYellow);
        warriorSkills.Clear();
        magicianSkills.Clear();
        for (int i = 0; i < gm.SkilList.Count; i++) //모든 스킬을 type에 따라 다른 목록으로 추가
        {
            if (gm.SkilList[i].type == 1)
            {
                warriorSkills.Add(gm.SkilList[i]);
            }
            else
            {
                magicianSkills.Add(gm.SkilList[i]);
            }
        }

        switch (gm.player.Job)
        {
            case "팔라딘":
                PrintSkill(gm, warriorSkills);
                break;
            case "마검사":
                PrintSkill(gm, magicianSkills);
                break;
            case "GM":
                PrintSkill(gm, gm.SkilList);
                break;
        }
        Console.WriteLine();
    }

    public void PrintSkill(GameManager gm, List<Skil> skills)
    {
        string str = "";
        int consumableNum = gm.itemList.Count;
        string strNum = "";
        for (int i = 0; i < gm.itemList.Count; i++)
        {
            if (!gm.itemList[i].ShopFlag)
            {
                consumableNum--;
            }
        }

        for (int i = 0; i < skills.Count; i++)
        {
            if (!IsSellOrBuy) strNum = " - "; //상점 창에서 아이템 번호 대신 " - "를 출력함
            else
            {
                consumableNum++;
                strNum = consumableNum.ToString() + "."; //소모품 번호를 string 값으로 변환 후 마침표 찍어주기
            }
            Skil ownedSkill = gm.mySkils.Find(x => x.Name == skills[i].Name);
            Skil item = skills[i];
            item.IsHad = ownedSkill != null; //보유한 스킬인지 확인
            string strPrice = item.IsHad ? "소지 중" : $"{item.Price} G"; //아이템이 인벤토리에 있는가의 여부에 따라 소지 중 또는 가격을 출력

            Console.Write($" {strNum} {item.Name} | 공격력: {item.Damage} | 공격 계수: {item.skilRatiod} | 공격 범위: {item.range}마리 | 마나 소모량: {item.Cost} | 스킬 타입: {item.type} | {item.Description} | ");
            if (item.IsHad)
            {
                Utility.ColorWrite(strPrice, ConsoleColor.Green);
            }
            else
            {
                Utility.ColorWrite(strPrice, ConsoleColor.Yellow);
            }
            Console.WriteLine();
        }
    }

    public void StoreScreen(GameManager gm) //상점 창 열람
    {
        while (true)
        {
            IsSellOrBuy = false; //이 창이 열리면 구매 또는 판매 중이 아님
            Utility.ColorWrite("<상점>", ConsoleColor.Cyan);
            Console.WriteLine("\n필요한 물건을 사고 팔 수 있는 곳입니다.\n");
            Console.Write($"[보유 골드] : ");
            Utility.ColorWrite($"{gm.player.Gold}G \n\n", ConsoleColor.Yellow);
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(gm); //아이템 목록 출력

            Console.WriteLine("1. 아이템 구매 \n2. 아이템 판매 \n");
            Utility.ColorWrite("0. 나가기\n\n", ConsoleColor.Red);
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
            Utility.ColorWrite("<상점>", ConsoleColor.Cyan);
            Console.WriteLine(" - 아이템 구매 \n아이템을 구매할 수 있습니다. \n");
            Console.Write($"[보유 골드] : ");
            Utility.ColorWrite($"{gm.player.Gold}G \n\n", ConsoleColor.Yellow);
            Console.WriteLine("[아이템 목록] \n");

            PrintItem(gm); //아이템 목록 출력

            Console.WriteLine("구매할 아이템의 번호를 누르세요.");
            Utility.ColorWrite("0. 나가기\n\n", ConsoleColor.Red);

            List<Item> buyable = new List<Item>();
            for (int i = 0; i < gm.itemList.Count; i++)
            {
                if (gm.itemList[i].ShopFlag)
                {
                    buyable.Add(gm.itemList[i]);
                }
            }

            List<Skil> currentSkills = new List<Skil>();
            if (gm.player.Job == "팔라딘") currentSkills = warriorSkills;
            else if (gm.player.Job == "마검사") currentSkills = magicianSkills;
            else currentSkills = gm.SkilList;

            int num = Utility.GetInput(0, buyable.Count + currentSkills.Count); //0부터 아이템 개수까지의 입력 가능

            if (num != 0) //0이 아닌 숫자를 기입함
            {
                num--; //아이템 번호를 0부터 시작하게 함
                //조건문 수정, 구매시 스킬 중복 출력되는 현상 확인

                //num 입력시 buyable에 있는 걸 선택한 건지 확인
                bool isBuyable = num < buyable.Count;
                if (isBuyable && buyable[num].ItemType != 2)
                {
                    Equipment item = (Equipment)buyable[num];
                    if (item.IsBought) //이미 있는 상품이라면
                    {
                        Console.Clear();
                        Utility.ColorWrite("이미 있는 아이템입니다.\n\n", ConsoleColor.Green);
                    }
                    else if (gm.player.Gold >= item.Price)
                    {
                        item.IsBought = true; //구매 완료 상태로 변경
                        gm.inventoryEquipment.Add(item); //인벤토리에 아이템 추가
                        gm.player.Gold -= item.Price; //골드 차감
                        Console.Clear();
                        Utility.ColorWrite($"==={item.Name} 아이템을 구매했습니다.===\n\n", ConsoleColor.Green);
                    }
                    else
                    {
                        Console.Clear();
                        Utility.ColorWrite($"{item.Name} 아이템을 사기에 골드가 부족합니다.\n\n", ConsoleColor.Red);
                    }
                    break;
                }
                else if (isBuyable)
                {
                    Consumable item = (Consumable)gm.itemList[num];
                    if (item.Count < item.MaxCount)
                    {
                        if (gm.player.Gold >= item.Price) //소모품은 계속 구매 가능
                        {
                            if (item.Count == 0) gm.inventoryConsumables.Add(item); //인벤토리에 아이템 추가
                            gm.player.Gold -= item.Price; //골드 차감
                            item.Count++; //소모품 개수 1 증가
                            Console.Clear();
                            Utility.ColorWrite($"==={item.Name} 아이템을 구매했습니다.===\n\n", ConsoleColor.Green);
                        }
                        else
                        {
                            Console.Clear();
                            Utility.ColorWrite("골드가 부족합니다.\n\n", ConsoleColor.Red);
                        }
                        break;
                    }
                    else
                    {
                        Utility.ColorWrite("보유한도를 초과했습니다.\n\n", ConsoleColor.Red);
                    }
                }
                else
                {
                    int skillNum = num - buyable.Count;
                    Skil item = currentSkills[skillNum];
                    if (item.IsHad)
                    {
                        Console.Clear();
                        Console.WriteLine("이미 있는 스킬입니다.\n\n", ConsoleColor.Red);
                    }
                    else if (item.Price > gm.player.Gold)
                    {
                        Console.Clear();
                        Utility.ColorWrite("해당 스킬을 구매하기에 골드가 부족합니다.\n\n", ConsoleColor.Red);
                    }
                    else
                    {
                        gm.SkilList[skillNum].IsHad = true;
                        gm.mySkils.Add(item);
                        gm.player.Gold -= item.Price;
                        Console.Clear();
                        Utility.ColorWrite($"{gm.SkilList[skillNum].Name} 스킬을 추가했습니다.\n\n", ConsoleColor.Green);
                    }
                }
            }
            else //나가기를 누름
            {
                Console.Clear();
                IsSellOrBuy = false;
                break;
            }
        }
    }

    public void SellItem(GameManager gm)
    {
        while (true)
        {
            int consumableNum = 0;
            IsSellOrBuy = true;
            Console.Clear();
            Utility.ColorWrite("<상점>", ConsoleColor.Cyan);
            Console.WriteLine(" - 아이템 판매 \n아이템을 판매할 수 있습니다. \n");
            Console.Write($"[보유 골드] : ");
            Utility.ColorWrite($"{gm.player.Gold}G \n\n", ConsoleColor.Yellow);
            Console.WriteLine("[아이템 목록] \n");

            Utility.ColorWrite("==장비=============\n", ConsoleColor.DarkYellow);

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
                string str = equipItem.ItemType == 0 || equipItem.ItemType == 5 ? "공격력: " : "방어력: "; //아이템의 아이템 타입에 따라 공격력 또는 방어력으로 출력
                float sellNum = equipItem.Price * 0.85f; //판매 가격 설정
                string sellPrice = sellNum.ToString("N0"); //판매 가격을 소수점 위로 출력되게 함
                Console.Write($" {strNum}{equipItem.ChangeEquipMark()} {equipItem.Name} | {str} +{equipItem.GetValue()}| {equipItem.Inform} | ");
                Utility.ColorWrite($"{sellPrice} G", ConsoleColor.Yellow);
                consumableNum += 1;
            }

            Utility.ColorWrite("==소비=============\n", ConsoleColor.DarkYellow);
            for (int i = 0; i < gm.inventoryConsumables.Count; i++)
            {
                if (!IsSellOrBuy) strNum = " - ";
                else
                {
                    consumableNum++;
                    strNum = consumableNum.ToString() + ".";
                }
                Consumable consumeItem = gm.inventoryConsumables[i];
                string str = "버프: ";
                float sellNum = consumeItem.Price * 0.85f; //판매 가격 설정
                string sellPrice = sellNum.ToString("N0"); //판매 가격을 소수점 위로 출력되게 함
                Console.Write($" {strNum} {consumeItem.Name} | {str} +{consumeItem.BuffAmount} | {consumeItem.Inform} | ");
                Utility.ColorWrite($"{sellPrice} G", ConsoleColor.Yellow );
                Console.WriteLine($" | 보유 개수: {consumeItem.Count}");
            }
            Console.WriteLine();
            Console.WriteLine("판매할 아이템의 번호를 누르세요.");
            Utility.ColorWrite("0. 나가기\n\n",ConsoleColor.Red);

            int num = Utility.GetInput(0, gm.inventoryEquipment.Count + gm.inventoryConsumables.Count); //0에서 인벤토리 아이템 개수까지
            if (num != 0)
            {
                num--;
                if (num < gm.inventoryEquipment.Count) //아이템이 장비일 때
                {
                    Equipment equipItem = gm.inventoryEquipment[num];
                    
                    equipItem.IsBought = false; //구매 상태를 false로 변경
                    int equipID = equipItem.ItemID; //선택된 아이템의 itemID를 반환함
                    if (equipItem.IsEquiped) equipItem.UnEquip(gm.player); //장착 중이었다면 해제함
                    float sellPrice = equipItem.Price * 0.85f;
                    gm.player.Gold += (int)sellPrice; //플레이어 골드에 판매 가격 추가
                    gm.inventoryEquipment.Remove(equipItem); //해당 아이템을 inventory에서 제거
                    Console.Clear();
                    Utility.ColorWrite($"==={equipItem.Name} 아이템을 판매했습니다.===\n\n",ConsoleColor.Green);
                    //반지 판매 
                }
                else //아이템이 소모품일 때
                {
                    Consumable consumable = gm.inventoryConsumables[num - gm.inventoryEquipment.Count];
                    int consumeID = consumable.ItemID;
                    float sellPrice = consumable.Price * 0.85f; //판매 가격 설정
                    gm.player.Gold += (int)sellPrice; //플레이어 골드에 판매 가격 추가
                    if (consumable.Count > 0) consumable.Count--; //아이템 개수 차감
                    if (consumable.Count == 0) gm.inventoryConsumables.Remove(consumable); //아이템 개수가 0이면 인벤토리에서 제거
                    Console.Clear();
                    Utility.ColorWrite($"==={gm.itemList[consumeID - 1].Name} 아이템을 판매했습니다.===\n\n",ConsoleColor.Green);
                }
                break;
            }
            else //나가기를 누름
            {
                IsSellOrBuy = false;
                Console.Clear();
                break;
            }
        }
    }
}