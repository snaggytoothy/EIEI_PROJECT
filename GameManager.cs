namespace EIEIE_Project;

public class GameManager
{
    public GameManager()
    {
        InitItem();
    }

    public List<Item> itemList = new List<Item>()
    {
        new Weapon{Name = "낡은 검", ItemID = 1, Price = 100, ItemType = 0, Inform = "오랫동안 방치된 듯 보이는 검입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Atk = 5f},
        new Weapon{Name = "예리한 검", ItemID = 2, Price = 250, ItemType = 0, Inform = "예리하게 벼려진 검입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 8f},
        new Weapon{Name = "심상치 않은 검", ItemID = 3, Price = 500, ItemType = 0, Inform = "심상치 않은 기운이 느껴지는 검입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 10f},
        new Armor{Name = "무쇠 갑옷", ItemID = 4, Price = 100, ItemType = 1, Inform = "흔히 구할 수 있는 갑옷입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 5f},
        new Armor{Name = "단단한 갑옷", ItemID = 5, Price = 300, ItemType = 1, Inform = "아주 단단한 갑옷입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 8f},
        new Armor{Name = "심상치 않은 갑옷", ItemID = 6, Price = 700, ItemType = 1, Inform = "심상치 않은 기운이 느껴지는 갑옷입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 12f},
        new Consumable{Name = "회복 물약", ItemID = 7, Price = 50, ItemType = 2, Inform = "체력을 50 회복시켜 줍니다.", ShopFlag = true, MonsterFlag = false, BuffAmount = 50}
    };
    public List<Equipment> equipments = new List<Equipment>();
    public List<Consumable> consumables = new List<Consumable>();
    public void InitItem()
    {
        foreach (Item nowitem in itemList)
        {
            if (nowitem is Equipment equipment)
            {
                equipments.Add(equipment);
            }
            else if (nowitem is Consumable consumable)
            {
                consumables.Add(consumable);
            }
        }
    }







    public Player player = new Player() { Level = 1, Name = "", MaxHP = 100, NowHP = 100, Atk = 20, Def = 15, Job = "", Gold = 1500, MaxExp = 10, NowExp = 0, MaxMP = 100, NowMP = 10 };

    public List<Equipment> inventoryEquipment = new List<Equipment>();  //인벤토리 리스트
    public List<Consumable> inventoryConsumables = new List<Consumable>(); // 소모품 리스트

    public int killCount = 0;
    public int attackCount = 0;
    public int exitFlag = 0;
}