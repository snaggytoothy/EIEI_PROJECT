using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
namespace EIEIE_Project;

//휴식 수정해야함
public class Start()
{
    private static int restNum = 500;


    static void Main(string[] args)
    {
        GameManager gameManager = new();


        StartGame(gameManager);
    }

    public static void StartGame(GameManager gameManager)
    {
        while (true)
        {
            Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.\r\n");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            string str = Console.ReadLine() ?? "기본값";
            gameManager.player.Name = str;

            Console.Clear();
            Console.WriteLine($"안녕하세요! {gameManager.player.Name}님!\n계속해서 이 이름으로 불러 드릴까요?");
            Console.WriteLine("1. 네 2. 아니오");

            int namesure = Utility.GetInput(1, 2);
            switch (namesure)
            {
                case 1:
                    Console.Clear();
                    SelectMenu(gameManager);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("이름을 바꿀 수 있는 기회는 지금 밖에 없습니다. 신중히 입력해주세요!");
                    continue; //다시 물어보기.
            }
        }
    }

    public static void SelectMenu(GameManager gameManager) //활동 선택
    {
        int act;
        Inventory inventory = new();
        Store store = new();
        Dungeon dungeon = new();
        Player player = new();

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
                    store.StoreScreen(gameManager, gameManager.itemList);
                    break;
                case 4:
                    dungeon.DoorDungeon(gameManager);
                    break;
                case 5:
                    RestScreen(player);
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
        Console.WriteLine($"체력: {gameManager.player.NowHP}\nGold: {gameManager.player.Gold} G");
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
        if (player.NowHP == player.MaxHP) Console.WriteLine("이미 체력이 가득찼습니다.");
        //플레이어의 체력이 가득찼을 경우 불필요하게 골드를 소모하지 못하게 막음
        else if (player.Gold < restNum) Console.WriteLine("골드가 부족합니다. \"썩 꺼져.\" 늙은이가 말합니다.");
        //골드가 부족하면 휴식하지 못하게 함
        else
        {
            int num = Utility.GetInput(0, 1);
            switch (num)
            {
                case 0:
                    break;
                case 1:
                    player.Gold -= restNum;
                    player.NowHP = player.MaxHP;
                    Console.WriteLine("체력이 회복되었습니다. \"또 오라고.\" 늙은이가 켈켈 웃습니다.");
                    break;
            }
        }
        RestScreen(player);
    }
}