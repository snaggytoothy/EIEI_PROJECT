using System;
using System.Numerics;

namespace EIEIE_Project;





class Dungeon
{
    public void DoorDungeon()
    {
        Utility.Loading();

        Console.Clear();
        Console.WriteLine("던전에 들어왔다.");
        Console.WriteLine("3개의 통로가 눈앞에 보인다");
        Console.WriteLine("각 통로 마다 팻말이 박혀있다.");
        Console.WriteLine();
        Console.WriteLine("1. 쉬움");
        Console.WriteLine("2. 보통");
        Console.WriteLine("3. 어려움");

        int input = Utility.GetInput(1, 3);



        switch (input)
        {
            case 1:
                //EasyScreen();
                break;
            case 2:
                //NormalScreen();
                break;
            case 3:
                //HardScreen();
                break;
        }

    }
  
    public void EasyScreen()
    {
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1000); // 1초 시간지연
            Console.Write("뚜벅");
        }

        Console.Clear();
        // Utility(캐릭터 상태창);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();


        Console.WriteLine();
        Console.WriteLine("0. 도망가기");
        Console.WriteLine();

        Utility.GetInput(0, 0);
        DoorDungeon(); // 던전입구 입장
    }

    public void NormalScreen()
    {

    }

    public void HardScreen()
    {


    }



}










       