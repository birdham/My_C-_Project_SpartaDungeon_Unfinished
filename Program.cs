using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using static SpartaDungeon.Program;
using static System.Collections.Specialized.BitVector32;

namespace SpartaDungeon
{
    
    internal class Program
    {

        public class Return //0번 누르면 뒤로 가기 로직---------------------------------------
        {
            public void ReturnButton()
            {
                
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                int action = int.Parse(Console.ReadLine());
                Console.Write("\n");
                switch (action)
                {
                    case 0:
                        Console.Clear();
                        Main();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("수를 잘못 눌렀습니다.다시 눌러주세요");
                        Console.WriteLine("");
                        Console.WriteLine("0. 나기기");
                        Console.WriteLine("");
                        ReturnButton();
                        break;

                }
            }
        }
        public class Store //상점------------------------------------------------------------------
        {
            Return Return = new Return();
            List<Item> items = new List<Item>();
            
            public void Selling()
            {
                status status = new status();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{status.gold} G");
                Console.WriteLine("");

                Console.WriteLine("[아이템 목록]");


                foreach (Item item in items)
                {
                    if (item.Buy == false)
                    {
                        string sold = "팔렸습니다.";
                    }
                    else
                    {
                        string sold = "지금 판매중!!";
                    }
                    Console.WriteLine($"{item.Name} | 방어력 : {item.Defense} | 공격력 : {item.Attack} | {item.Info} | 가격 : {item.Price} | 판매상태 : {item.Buy} | ");
                }

                Console.WriteLine("");
                Console.WriteLine("0. 나기기");
                Console.WriteLine("");
                Return.ReturnButton();
            }
            
        }
        public class inventory //인벤토리---------------------------------------------------------------
        {
            Return Return = new Return();
            public void Wear()
            {   

                Console.WriteLine("인벤토리 - 장착관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");

                Console.WriteLine("");
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나기기");
                Console.WriteLine("");
                
                Return.ReturnButton();
                
            }
            public void myItem()
            {
                Console.WriteLine("[인벤토리]");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("");
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");                
            }
        }
        public class Item//아이템----------------------------------------------------------------------------
        {
            List<Item> items = new List<Item>();
            public void Items()
            {
                

                items.Add(new Item("수련자 갑옷","수련에 도움을 주는 갑옷입니다.",0,5,1000,false ));
                items.Add(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 0, true));
                items.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 3500, false));
                items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0, 600, false));
                items.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, 1500, false));
                items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 3000, true));
                Console.WriteLine($"{Name}");

            }
            public string Name { get; }
            public string Info { get; }
            public int Attack { get; }
            public int Defense { get; }
            public int Price { get; }
            public bool Buy { get; }

            
            public Item(string name, string info, int attack, int defense, int price, bool buy)
            {
                Name = name;
                Info = info;
                Attack = attack;
                Defense = defense;
                Price = price;
                Buy = buy;
            }
        }
        
        public class status //능력치-------------------------------------------------------------------------
        {
            Return Return = new Return();
            public int Lv = 01;
            public string name = "Chad";
            public string job = "전사";
            public int attackpoint = 10;
            public int deffencepoint = 5;
            public int health= 100;
            public int gold = 1500;
            public void readstatus()
            {
                Console.WriteLine("상태보기\n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv. 0{Lv}");
                Console.WriteLine($"{name} ( {job} )");
                Console.WriteLine($"공격력 : {attackpoint}");
                Console.WriteLine($"방어력 : {deffencepoint}");
                Console.WriteLine($"체력 : {health}");
                Console.WriteLine($"Gold : {gold} G");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");

                Return.ReturnButton(); 
                    
                
            }
        }

        static void Main() //메인---------------------------------------------------------------------------------------------------------
        {
            
            Store store = new Store();
            inventory inventory = new inventory();
            status status = new status();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1.  상태보기\n2.  인벤토리\n3.  상점\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            int action = int.Parse(Console.ReadLine());
            Console.Write("\n");
            switch (action)
            {
                
                case 1:
                    status.readstatus();
                    break;
                case 2:
                    inventory.myItem();
                    break;
                case 3:
                    store.Selling();    
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("수를 잘못 눌렀습니다.다시 눌러주세요");
                    Console.WriteLine("");
                    Main();
                    break;


            }
        }
    }
}
