using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
namespace EIEIE_Project;

public class Start()
{
    Information info = new Information();
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        Inventory inventory = new Inventory();
        StartGame(gameManager);
        inventory.InventoryScene(gameManager);
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
            string namesure = Console.ReadLine() ?? "기본값";

            if (namesure == "1")
            {
                Console.Clear();
                SelectMenu(gameManager);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("이름을 바꿀 수 있는 기회는 지금 밖에 없습니다. 신중히 입력해주세요!");
                continue; //다시 물어보기.
            }
        }
    }

    public static void SelectMenu(GameManager gameManager) //활동 선택
    {
        int act;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기 2. 인벤토리 3. 상점 4. 던전 입장 5. 휴식하기 | 0. 게임종료");
            act = Utility.GetInput(1, 5);
            if (act == 1)
            {
                Information.Status();
            }
            else if (act == 2)
            {
                //인벤토리
                //Bag.inventory(this);
            }
            else if (act == 3)
            {
                //상점
                //Shop.store(this);
            }
            else if (act == 4)
            {
                //던전
                //hell.dungeon(this);
            }
            else if (act == 5)
            {
                //휴식
                //-500 골드 && hp 100으로 회복
            }
            else
            {
                //예외처리
            }
        }
    }
}

public class Information()
{
    public static void Status()
    {
        GameManager gameManager = new GameManager();
        int act;
        Console.Clear();
        Console.WriteLine($"<상태 보기>\n{gameManager.player.Name}님의 캐릭터 정보가 표시됩니다.\r\n");
        Console.WriteLine($"Lv. {gameManager.player.Level}");
        Console.WriteLine($"{gameManager.player.Name} {gameManager.player.Job}");
        Console.WriteLine($"공격력: {gameManager.player.Atk}");
        Console.WriteLine($"방어력: {gameManager.player.Def}");
        Console.WriteLine($"체력: {gameManager.player.NowHP}\nGold: {gameManager.player.Gold} G");
        Console.WriteLine("\r\n0. 나가기\n원하시는 행동을 입력해주세요.");
        if (int.TryParse(Console.ReadLine(), out act))
        {
            if (act == 0)
            {

            }
            Console.Clear();
        }
        Console.Clear();
    }
}