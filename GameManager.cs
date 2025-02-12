using System.Security.Cryptography.X509Certificates;

namespace EIEIE_Project;

public class GameManager
{
    public GameManager()
    {
        InitItem();
    }

    public List<Item> itemList = new List<Item>() // 등급 : 일반 -> 명작 -> 레어 -> 전설 (등급 마다 성급 추가 최대 ★x3개)
    {
         new Weapon{Name = "투박한 롱소드[일반]", ItemID = 1, Price = 500, ItemType = 0, Inform = "매우 흔하디흔한 양산형, 롱소드이다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Atk = 2f},

        new Weapon{Name = "바스타드 소드[일반★]", ItemID = 2, Price = 1150, ItemType = 0, Inform = "대검 반 한 손 검, 롱소드보다 바디의 길이가 더 길며 파괴력이 높고 공방 밸런스가 잘 갖춰졌다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 4f},

        new Weapon{Name = "한손검 글라디우스[일반]", ItemID = 3, Price = 600, ItemType = 0, Inform = "폭 넓은 양날 장검 무거워서 신속하게 사용 힘듬, 방패랑 사용하면 안정적이다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 3f,},

        new Armor{Name = "레더 아머[일반]", ItemID = 4, Price = 500, ItemType = 1, Inform = "가죽을 무질과 간단한 기름칠로 경화처리를 거친, 흔한 가죽 갑옷.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 1f},

        new Armor{Name = "보일드 레더 아머[일반]", ItemID = 5, Price = 1000, ItemType = 1, Inform = "끓여진 파라핀+기름에 뺏다 넣었다 반복해서 만든 가죽 갑옷 끝판왕, 강도는 손으로 안 구부러질 정도다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 3f},

        new Armor{Name = "고블린 찰갑[일반★]", ItemID = 6, Price = 1600, ItemType = 1, Inform = "고블린 뼈로 만든 미늘 조각에 끈으로 연결하여 만든 갑옷, 꽤나 튼튼하고 유지 보수가 쉽다.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 5f},

        new Consumable{Name = "체력 회복 물약", ItemID = 7, Price = 300, ItemType = 2, Inform = "체력을 40~50 회복시켜 줍니다.", ShopFlag = true, MonsterFlag = false, BuffAmount = "40~50"},

        new Consumable{Name = "마나 회복 물약", ItemID = 8, Price = 150, ItemType = 2, Inform = "마나를 20~25 회복시켜 줍니다.", ShopFlag = true, MonsterFlag = false, BuffAmount = "20~25"},
        //테스트 공격력 버프 물약
        new Consumable{Name = "싸움꾼의 물약", ItemID = 9, Price = 50, ItemType = 2, Inform = "3턴 간 공격력을 약간 올려줍니다.(전투 중에만 사용가능)", ShopFlag = true, MonsterFlag = false, BuffAmount = "10"},

        new Weapon{Name = "링 오브 고블린 로드[등급: 전설] ", ItemID = 100, Price = 10000, ItemType = 1, Inform = "고블린 로드가 장착했던 반지, ", //작업중
        IsEquiped = false, ShopFlag = false, MonsterFlag = true, Atk = 3f},

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


    public List<Skil> SkilList = new List<Skil>()
    {
        new Skil { ID = 1, Name = "전사스킬1", Damage = 30 , skilRatiod = 0.5, range = 1, IsHad = false, Cost = 10, type = 1, Description = "스킬설명"},
        new Skil { ID = 2, Name = "전사스킬2", Damage = 20,  skilRatiod = 0.3,range = 3, IsHad = false, Cost = 20 , type = 1, Description = "스킬설명"},
        new Skil { ID = 3, Name = "전사스킬3", Damage = 50, skilRatiod = 1.0, range = 1, IsHad = false , Cost = 50, type = 1, Description = "스킬설명"},
        new Skil { ID = 4, Name = "마법사스킬1", Damage = 20, skilRatiod = 0.5, range = 1, IsHad = false, Cost = 10 , type = 2, Description = "스킬설명"},
        new Skil { ID = 5, Name = "마법사스킬2", Damage = 10, skilRatiod = 0.3, range = 5, IsHad = false, Cost = 20 , type = 2, Description = "스킬설명"},
        new Skil { ID = 6, Name = "마법사스킬3", Damage = 50, skilRatiod = 1.0, range = 1, IsHad = false, Cost = 50 , type = 2, Description = "스킬설명"},
    };

    public List<Skil> mySkils = new List<Skil>();

    public Player player = new Player() { Level = 1, Name = "", MaxHP = 100, NowHP = 100, Atk = 20, Def = 15, Job = "", Gold = 1500, MaxExp = 10, NowExp = 0, MaxMP = 100, NowMP = 10 };

    public List<Equipment> inventoryEquipment = new List<Equipment>();  //인벤토리 리스트
    public List<Consumable> inventoryConsumables = new List<Consumable>(); // 소모품 리스트

    public int killCount = 0;
    public int attackCount = 0;
    public int exitFlag = 0;
    private int turnCount;
    public event Action onChangeTurnCount;
    public int TurnCount
    {
        get
        {
            return turnCount;
        }
        set
        {
            turnCount = value;
            onChangeTurnCount?.Invoke();
        }
    }
}