namespace EIEIE_Project;

public class Start()
{
    private static int restNum = 500; //휴식에 필요한 골드 양
    public static string name = null;
    static void Main(string[] args)
    {
        GameManager gameManager = new(); //게임 매니저 생성
        StartGame(gameManager); //게임 시작
    }

    public static void NameLength(GameManager gameManager) //이름의 길이를 8자로 제한함
    {
        while (true)
        {
            Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.\r\n");
            Console.WriteLine("원하시는 이름을 설정해주세요.");

            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "스파르타"; //값이 없거나 빈 문자열이면 "스파르타"로 설정
            }
            char[] letters = name.ToCharArray();
            if (letters.Length > 8) Console.WriteLine("8글자 내로 입력해주세요.");
            else
            {
                gameManager.player.Name = name; //플레이어 이름 설정
                break;
            }
        }
    }

    public static void StartGame(GameManager gameManager)
    {
        while (true)
        {
            NameLength(gameManager);

            Console.Clear();
            Console.WriteLine($"안녕하세요! {name}님!\n계속해서 이 이름으로 불러 드릴까요?");
            Console.WriteLine("1. 네 \n2. 아니오");

            int namesure = Utility.GetInput(1, 2);
            switch (namesure)
            {
                case 1:
                    Console.Clear();
                    SelectJob(gameManager);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("다시 한 번 입력해주세요.");
                    break;
            }
        }
    }
    public static void SelectJob(GameManager gameManager)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{gameManager.player.Name}님 멋진 이름이군요.");
            Console.WriteLine("그렇다면 당신의 직업은 무엇인가요?");
            Console.WriteLine("\n1. 전사\n2. 마법사\n3. 모험가");
            int input = Utility.GetInput(1, 3);
            switch (input)
            {
                case 1:
                    gameManager.player.Job = "전사";
                    gameManager.mySkils.Add(gameManager.SkilList[0]);
                    break;
                case 2:
                    gameManager.player.Job = "마법사";
                    gameManager.mySkils.Add(gameManager.SkilList[3]);
                    break;
                case 3:
                    gameManager.player.Job = "모험가";
                    gameManager.mySkils.Add(gameManager.SkilList[0]);
                    gameManager.mySkils.Add(gameManager.SkilList[1]);
                    gameManager.mySkils.Add(gameManager.SkilList[2]);
                    gameManager.mySkils.Add(gameManager.SkilList[3]);
                    gameManager.mySkils.Add(gameManager.SkilList[4]);
                    gameManager.mySkils.Add(gameManager.SkilList[5]);
                    break;
            }
            Console.Clear();
            Console.WriteLine("확실한가요? 직업 역시 지금 정하면 이후에 변경할 수 없습니다.");
            Console.WriteLine("1. 네 2. 아니오");

            int jobsure = Utility.GetInput(1, 2);
            switch (jobsure)
            {
                case 1:
                    Console.Clear();
                    SelectMenu(gameManager);
                    break;
                case 2:
                    break;
            }
        }
        
    }

    public static void SelectMenu(GameManager gameManager) //활동 선택
    {
        int act;
        Inventory inventory = new();
        Store store = new();
        Dungeon dungeon = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기 \n2. 인벤토리 \n3. 상점 \n4. 던전 입장 \n5. 휴식하기 \n\n0. 게임종료");

            act = Utility.GetInput(0, 5);
            switch (act)
            {
                case 1:
                    Status(gameManager);
                    break;
                case 2:
                    inventory.InventoryScene(gameManager);
                    break;
                case 3:
                    Console.Clear();
                    store.StoreScreen(gameManager);
                    break;
                case 4:
                    dungeon.DoorDungeon(gameManager);
                    break;
                case 5:
                    RestScreen(gameManager.player);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
    }
    public static void Status(GameManager gameManager)
    {
        Console.Clear();
        Console.WriteLine($"<상태 보기>\n{gameManager.player.Name}님의 캐릭터 정보가 표시됩니다.\r\n");
        Console.WriteLine($"Lv. {gameManager.player.Level}");
        Console.WriteLine($"{gameManager.player.Name} ({gameManager.player.Job})");
        Console.WriteLine($"공격력: {gameManager.player.Atk}");
        Console.WriteLine($"방어력: {gameManager.player.Def}");
        Console.WriteLine($"체력: {gameManager.player.NowHP} / {gameManager.player.MaxHP}");
        Console.WriteLine($"마나: {gameManager.player.NowMP} / {gameManager.player.MaxMP}");
        Console.WriteLine($"Gold: {gameManager.player.Gold} G");
        Console.WriteLine($"경험치: {gameManager.player.NowExp} / {gameManager.player.MaxExp}");
        Console.WriteLine("\r\n0. 나가기");
        int act = Utility.GetInput(0, 0);

        if (act == 0)
        {
            Console.Clear();
            SelectMenu(gameManager);
        }
        Console.Clear();
    }

    public static void RestScreen(Player player)
    {
        Console.Clear();
        Console.WriteLine("당신은 꽤 깔끔해보이는 동굴을 발견했습니다.");
        Console.WriteLine("\"여긴 내 집인데.\" 낯선 늙은이가 말합니다.");
        Console.WriteLine($"\"뭐... 돈을 조금 낸다면 쉬게 해주지. 단돈 {restNum} 골드라고. \"");
        Console.WriteLine($"휴식합니까? 현재 지닌 골드는 {player.Gold} 입니다.");
        Console.WriteLine("1. 휴식하기 \n0.나가기");

        int num = Utility.GetInput(0, 1);
        switch (num)
        {
            case 0:
                break;
            case 1:
                Rest(player);
                break;
        }
    }

    public static void Rest(Player player)
    {
        Console.Clear();
        if (player.NowHP == player.MaxHP) Console.WriteLine("이미 체력이 가득찼습니다.(아무 키나 눌러 확인)");
        //플레이어의 체력이 가득찼을 경우 불필요하게 골드를 소모하지 못하게 막음
        else if (player.Gold < restNum) Console.WriteLine("골드가 부족합니다. \"썩 꺼져.\" 늙은이가 말합니다.(아무 키나 눌러 확인)");
        //골드가 부족하면 휴식하지 못하게 함
        else
        {
            Random ran = new Random();
            int healAmount = ran.Next(30, 51);//힐량은 30~50 랜덤 값
            player.Gold -= restNum;
            player.NowHP += healAmount;
            if (player.NowHP > player.MaxHP)
            {
                player.NowHP = player.MaxHP;//만약 현재 HP 가 최대 HP를 넘어서면 최대 HP로 설정
            }
            Console.WriteLine($"체력이 {healAmount} 회복되었습니다. \"또 오라고.\" 늙은이가 켈켈 웃습니다.(아무 키나 눌러 확인)");
        }
        Console.ReadKey();
    }
}