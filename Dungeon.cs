using System;
using System.Numerics;
namespace EIEIE_Project;

class Dungeon
{
    public void DoorDungeon()
    {
        Utility.Loading();

        Console.Clear();
        Console.WriteLine("������ ���Դ�.");
        Console.WriteLine("3���� ��ΰ� ���տ� ���δ�");
        Console.WriteLine("�� ��� ���� �ָ��� �����ִ�.");
        Console.WriteLine();
        Console.WriteLine("1. ����");
        Console.WriteLine("2. ����");
        Console.WriteLine("3. �����");

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
        Console.WriteLine("������ �ɾ�� �ֽ��ϴ�.");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1000); // 1�� �ð�����
            Console.Write("�ѹ�");
        }

        Console.Clear();
        // Utility(ĳ���� ����â);
        Console.WriteLine("ĳ������ ������ ǥ�õ˴ϴ�.");
        Console.WriteLine();


        Console.WriteLine();
        Console.WriteLine("0. ��������");
        Console.WriteLine();

        Utility.GetInput(0, 0);
        DoorDungeon(); // �����Ա� ����
    }

    public void NormalScreen()
    {

    }

    public void HardScreen()
    {


    }

    public void DungeonProgress(Player player, List<Item> inventory, List<Item> EntireItem,int level)
    {
        //�÷��̾��� ���Խ� ���¸� ����
        Player tempPlayer = new Player() { NowExp = player.NowExp, Gold = player.Gold, NowHP = player.NowHP, Level = player.Level };
        List<Monster> monsters = new List<Monster>();
        int input;
        if (level == 1)
        {
            while (true)
            {
                monsters.Add(new Monster(1));
                monsters.Add(new Monster(2));
                monsters.Add(new Monster(3));

                Console.WriteLine("Battle!!");
                Console.WriteLine();
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].IsDead == true)
                    {
                        Console.WriteLine("{0} Lv {1} {2}   HP {3} / {4}", i, monsters[i].Name, monsters[i].Level, monsters[i].NowHP, monsters[i].MaxHP);
                    }
                    else if (monsters[i].IsDead == false)
                    {
                        Console.WriteLine("{0} Lv {1} {2}   Dead", i, monsters[i].Name, monsters[i].Level);
                    }
                }
    
                Console.WriteLine("[������]");
                Console.WriteLine("Lv. {0}  {1}  ({2})", player.Level, player.Name, player.Job);
                Console.WriteLine("HP {0}/{1}", player.NowHP, player.MaxHP);
                Console.WriteLine();
                Console.WriteLine("0. ������");
                Console.WriteLine();
                Console.WriteLine("����� �������ּ���");
                Console.Write(">>>");
                input = Utility.GetInput(1, monsters.Count);


            }
                
        }
        else if (level == 2)
        {

        }
        else if (level == 3)
        {

        }
        else
        {
            //����ó��
        }
    }
}










       
