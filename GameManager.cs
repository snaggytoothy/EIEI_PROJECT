namespace EIEIE_Project;

public class GameManager
{
    public List<Item> itemList = new List<Item>()
    {
        new Weapon{Name = "기본 검", ItemID = 1, Price = 100, ItemType = 0, Inform = "기본 검입니다. 특별한 점은 없습니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Atk = 5f},
        new Weapon{Name = "날카로운 검", ItemID = 2, Price = 250, ItemType = 0, Inform = "날이 잘 벼려진 검입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 8f},
        new Weapon{Name = "신비로운 검", ItemID = 3, Price = 500, ItemType = 0, Inform = "비밀이 많아보이는 검입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 10f},
        new Armor{Name = "기본 갑옷", ItemID = 4, Price = 100, ItemType = 1, Inform = "기본 갑옷입니다. 특별한 점은 없습니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 5f},
        new Armor{Name = "반짝이는 갑옷", ItemID = 5, Price = 300, ItemType = 1, Inform = "잘 닦아서 반짝이는 갑옷입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 8f},
        new Armor{Name = "신비로운 갑옷", ItemID = 6, Price = 700, ItemType = 1, Inform = "비밀이 많아보이는 갑옷입니다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 12f},
    };
}