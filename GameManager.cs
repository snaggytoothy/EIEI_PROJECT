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
        //-------------테스트용
        new Armor{Name = "테스트용 그리브[일반]", ItemID = 10, Price = 100, ItemType = 3, Inform = "테스트하나",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 1f},
        new Armor{Name = "테스트용 헬멧[일반]", ItemID = 11, Price = 100, ItemType = 4, Inform = "테스트둘",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 1f},
        new Weapon{Name = "공격 반지[일반]", ItemID = 12, Price = 100, ItemType = 5, Inform = "테스트셋",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Atk = 2f},
        new Armor{Name = "방어 반지[일반]", ItemID = 13, Price = 100, ItemType = 6, Inform = "테스트넷",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 1f},
        //-------------------------------
        new Consumable{Name = "체력 회복 물약", ItemID = 7, Price = 300, ItemType = 2, Inform = "체력을 40~50 회복시켜 줍니다.", ShopFlag = true, MonsterFlag = false, BuffAmount = "40~50"},

        new Consumable{Name = "마나 회복 물약", ItemID = 8, Price = 150, ItemType = 2, Inform = "마나를 20~25 회복시켜 줍니다.", ShopFlag = true, MonsterFlag = false, BuffAmount = "20~25"},
        
        new Consumable{Name = "싸움꾼의 물약", ItemID = 9, Price = 50, ItemType = 2, Inform = "3턴 간 공격력을 약간 올려줍니다.(전투 중에만 사용가능)", ShopFlag = true, MonsterFlag = false, BuffAmount = "10"},

        new Weapon{Name = "와일드보어 보일드 레더 그리브[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "와일드 보어 가죽으로 끓여진 파라핀+기름에 뺏다 넣었다 반복해서 만든 그리브 밖은 강철같이 튼튼하며 내부는 유연하여 충격에도 강하다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "와일드보어 보일드 레더 갑옷[등급: 일반★★★] ", ItemID = 100, Price = 2500, ItemType = 1, Inform = "와일드 보어 가죽으로 끓여진 파라핀+기름에 뺏다 넣었다 반복해서 만든 갑옷 밖은 강철같이 튼튼하며 내부는 유연하여 충격에도 강하다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "와일드보어 보일드 레더 투구[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 4, Inform = "와일드 보어 가죽으로 끓여진 파라핀+기름에 뺏다 넣었다 반복해서 만든 투구 밖은 강철같이 튼튼하며 내부는 유연하여 충격에도 강하다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "고블린 보석[등급: 일반] ", ItemID = 100, Price = 700, ItemType = 5, Inform = "고블린 뼈에서 만들어지는 고블린 보석이다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "고블린 해골[등급: 일반] ", ItemID = 100, Price = 2000, ItemType = 5, Inform = "징그러운 고블린 해골 상점에 팔면된다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "튜터의 잃어버린 밥그릇[등급: 세트] ", ItemID = 100, Price = 2000, ItemType = 5, Inform = "튜터의 밥그릇이다 튜터중 누군가 밥을 못먹고 있는것이 틀림없다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "튜터의 잃어버린 왼쪽 부츠[등급: 세트] ", ItemID = 100, Price = 2000, ItemType = 5, Inform = "어쩌다 잃어버린걸까.. 알수없다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

        new Weapon{Name = "은빛늑대 츠바이헨더[등급: 명작★★] ", ItemID = 100, Price = , ItemType = 0, Inform = "명장이 정화된 은을 첨가하여 만든 대검이다 칼자루 끝에 검은늑대 머리 형상이 있으며 가격은 상당히 비싸다.\r\n ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "검은늑대방패[등급: 명작★] ", ItemID = 100, Price = , ItemType = 6, Inform = "본체는 나무이며 검은 청동 철판을 덮은 지름 1미터 원형 방패 방패 중간에 검은늑대 머리가 각인되어 있다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "옥구슬[등급: 일반★] ", ItemID = 100, Price = 2000, ItemType = 5, Inform = "금속으로 만들어졌으며 센터에 품질좋은 옥구슬이 박혀있다, 장착하면 보호받는 기분이 든다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "푸바오 목각인형[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "대상을 그리워하는 마음으로 조각한거 같다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "검은 판금 그리브[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "흑철을 사용해서 만든 그리브 이다. 흑철은 마법의 저항력과 강철보다 높은 내구성을 가지고있다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "검은 경번갑 갑옷[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "사슬 갑옷에 철판을 유기적으로 결합시킨 갑옷이다 재료는 흑철이 들어가서 검은색을 띈다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "부셔진 옥구슬[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "부셔져 버린 상태는 상품 가치가 낮다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "튜터의 회고록[등급: 일반★★★] ", ItemID = 100, Price = 2000, ItemType = 3, Inform = "누군가의 회고록이다 무슨 내용인지 모르겠다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "튜터의 목검[등급: 일반★★★] ", ItemID = 100, Price = , ItemType = 3, Inform = "튜터라는 전사가 쓰던 목검이다 생각보다 튼튼해서 쓸만하다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "EIEI 목걸이[등급: 일반★★★] ", ItemID = 100, Price = , ItemType = 3, Inform = "유명한 길드 이름의 은목걸이 누구나 가입하고 싶어 하는 길드다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, NRareFlag = true  ,Atk = 4.5f},//Normal

        new Weapon{Name = "란세어[등급: 일반★★★] ", ItemID = , Price = , ItemType = , Inform = "만들기가 어려운 창이다, 생긴 모양은 양옆 블레이드가 크고 갈고리처럼 휘어있으며 창 중앙에 길고 뾰족한 50cm 창날이 있다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard

        new Weapon{Name = "천산 어린갑[등급: 일반★★★] ", ItemID = , Price = , ItemType = , Inform = "천산갑이라는 동물의 비늘을 겹겹이 쌓아서 안감과 연결해서 만들었다 천산갑의 비늘은 상당히 고가이며 내구성도 매우 높아 부르는 게 값이다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard

        new Weapon{Name = "역전의 마티네 목걸이[등급: 일반★★★] ", ItemID = , Price = , ItemType = , Inform = "쌍검이 크로스로 겹쳐있는 모양이 달려있는 황금 목걸이다, 착용하면 힘이 솟아난다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard

        new Weapon{Name = "붉은루비[등급: 일반★★★] ", ItemID = , Price = , ItemType = , Inform = "붉은 빛이 매혹적이다 값 비싸게 판매가 가능하다.  ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard


        new Weapon{Name = "본 엘더 헬름투구[등급: 전설] ", ItemID = , Price = , ItemType = , Inform = "본 엘더리치가 소유하고있던 어느 전사의 전리품이다 외부는 검은색 뼈 내부는 강철로 만들어진 헬름투구이다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard

        new Weapon{Name = "자하드가가의 플라멘슈베르트[등급: 전설] ", ItemID = , Price = , ItemType = , Inform = "양손대검이다, 검날이 불꽃의 형태를띄고 이 검으로 베이면 살점이 떨어져 나간다. 숙련도가 많이 필요한 검이다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, HRareFlag = true  ,Atk = 4.5f},//Hard

        new Weapon{Name = "링 오브 고블린 로드[등급: 전설] ", ItemID = 100, Price = 10000, ItemType = 5, Inform = "고블린 로드가 장착했던 반지이다, 청동으로 만들었으며 센터에 옥이 박혀있는형태 바디 부분에 룬 문자가 새겨져다. ",
        IsEquiped = false, ShopFlag = false, MonsterFlag = false, ERareFlag = true  ,Atk = 4.5f},//Easy

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
        new Skil { ID = 1, Name = "신성 가르기", Damage = 30 , skilRatiod = 0.5, range = 1, IsHad = false, Cost = 10, type = 1, Description = "수련으로 단련된 강한 신성력을 응집시켜 상대에게 검기의 형태로 날립니다.", Price = 1000},
        new Skil { ID = 2, Name = "퍼지는 태양 불길", Damage = 20,  skilRatiod = 0.3,range = 3, IsHad = false, Cost = 20 , type = 1, Description = "태양원판으로 빛을 산개하여 여러 명의 적에게 피해를 입힙니다.", Price = 1000},
        new Skil { ID = 3, Name = "거대한 여신의 심판", Damage = 50, skilRatiod = 1.0, range = 1, IsHad = false , Cost = 50, type = 1, Description = "여신의 권능을 빌려 상대에게 심판을 내립니다. 팔라딘 중에서도 극히 일부만이 여신의 권능에 다가설 수 있습니다.", Price = 1000},
        new Skil { ID = 4, Name = "그림자 꿰뚫기", Damage = 20, skilRatiod = 0.5, range = 1, IsHad = false, Cost = 10 , type = 2, Description = "음침한 어둠의 기운을 검에 둘러 상대를 찌릅니다. 꿰뚫린 상처에선 검은색 피가 흐릅니다.", Price = 1000},
        new Skil { ID = 5, Name = "깊은 숲의 저주", Damage = 10, skilRatiod = 0.3, range = 5, IsHad = false, Cost = 20 , type = 2, Description = "금지된 숲에서 비롯되는 강한 원념을 이용하여 주변에 무차별적으로 저주를 퍼붓습니다.", Price = 1000},
        new Skil { ID = 6, Name = "고대 용술사의 재림", Damage = 50, skilRatiod = 1.0, range = 1, IsHad = false, Cost = 50 , type = 2, Description = "용의 마력을 온몸으로 흘려보내 강력한 용언마법을 구사할 수 있게됩니다.", Price = 1000},
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