using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
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
                EasyScreen();
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
        //�� ����
        


        Console.WriteLine("������ �ɾ�� �ֽ��ϴ�.");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1000); // 1�� �ð�����
            Console.Write("�ѹ�");
        }

        Console.WriteLine();
        Console.WriteLine("�氡�� �Ҿƹ����� �����Ҽ��ִ�");
        Console.WriteLine("���̵� �����Դϴ�.");

        Console.WriteLine();
        // Utility(ĳ���� ����â);
        Console.WriteLine("ĳ������ ������ ǥ�õ˴ϴ�.");


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

    public void DungeonProgress(GameManager gameManager,int level)
    {
        //�÷��̾��� ���Խ� ���¸� ����
        Player tempPlayer = new Player() { NowExp = gameManager.player.NowExp, Gold = gameManager.player.Gold, NowHP = gameManager.player.NowHP, Level = gameManager.player.Level };
        List<Monster> monsters = new List<Monster>();
        //easy���� ����
        if (level == 1)
        {
            //���̵��� �´� ���� ����
            monsters.Add(new Monster(1));
            monsters.Add(new Monster(2));
            monsters.Add(new Monster(3));
            while (true)
            {
                Console.Clear();
                //�÷��̾� ��
                PlayerTurn(gameManager, monsters);
                //�� ���� ��
                EnemyTurn(gameManager, monsters);
                if (gameManager.player.NowHP <= 0)
                {
                    //�й�ȭ������
                    monsters.Clear();
                    break;
                }
                else if(monsters.FindAll(x=>x.IsDead).Count==monsters.Count)
                {
                    monsters.Clear();
                    //�¸�ȭ������
                    break;
                }
            }
                
        }
        //normal ���� ����
        else if (level == 2)
        {

        }
        //hard���� ����
        else if (level == 3)
        {

        }
        else
        {
            //����ó��
        }
    }

    public void PlayerTurn(GameManager gameManager,List<Monster> monsters)
    {
        int input;
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
        Console.WriteLine("Lv. {0}  {1}  ({2})", gameManager.player.Level, gameManager.player.Name, gameManager.player.Job);
        Console.WriteLine("HP {0}/{1}", gameManager.player.NowHP, gameManager.player.MaxHP);
        Console.WriteLine();
        Console.WriteLine("0. ������");
        Console.WriteLine();
        Console.WriteLine("����� �������ּ���");
        Console.Write(">>>");
        input = Utility.GetInput(1, monsters.FindAll(x=>x.IsDead==false).Count);
        float tempHP = monsters[input].NowHP;
        if (input == 0)
        {
            return;
        }
        else { 
            gameManager.player.Attack(gameManager.player, monsters[input]);
            if (monsters[input].NowHP <= 0)
            {
                monsters[input].IsDead = true;
                monsters[input].NowHP = 0;
                gameManager.killCount++;
            }

        }
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine();
        Console.WriteLine("{0} �� ����!",gameManager.player.Name);
        Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", monsters[input].Level, monsters[input].Name, tempHP - monsters[input].NowHP);
        Console.WriteLine();
        Console.WriteLine("Lv.{0} {1}", monsters[input].Level, monsters[input].Name);
        if(monsters[input].IsDead == true)
        {
            Console.WriteLine("HP {0} -> Dead", monsters[input].Level);
        }
        else
        {
            Console.WriteLine("HP {0} -> {1}", tempHP, monsters[input].NowHP);
        }

        Console.WriteLine();
        Console.WriteLine("�ƹ�Ű �Է�. ����");
        Console.WriteLine();
        Console.Write(">>");
        Console.ReadKey();
    }

    public void EnemyTurn(GameManager gameManager, List<Monster> monsters)
    {
        int input;
        float tempHP = 0;
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine();
        for (int i = 0; i < monsters.Count; i++)
        {
            tempHP = gameManager.player.NowHP;
            Console.WriteLine("{0} �� ����!", monsters[i].Name);
            monsters[i].Attack(monsters[i], gameManager.player);
            if (gameManager.player.NowHP <= 0)
            {
                gameManager.player.NowHP = 0;
            }
            Console.WriteLine("{1} ��(��) ������ϴ�. [������] : {2}", gameManager.player.Name,tempHP - gameManager.player.NowHP);
            Console.WriteLine();
            Console.WriteLine("Lv.{0} {1}", gameManager.player.Level,gameManager.player.Name);
            if (gameManager.player.NowHP<=0)
            {
                Console.WriteLine("HP {0} -> Dead", gameManager.player.NowHP);
            }
            else
            {
                Console.WriteLine("HP {0} -> {1}", tempHP,gameManager.player.NowHP);
            }

            Console.WriteLine("�ƹ�Ű �Է�. ����");
            Console.WriteLine();
            Console.Write(">>");
            Console.ReadKey();
        }
    }
}










       
