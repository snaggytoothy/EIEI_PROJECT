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



}










       