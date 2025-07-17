namespace TypeInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * C#類型系統
             *                         -> class
             *              -> 引用類型 -> interface
             *                         -> delegate
             * Object物件 ->            
             * 
             *              -> 值類型   -> Struct
             *                         -> enum
             */

            //方法中宣告的區域變數有明確賦值原則 不能寫作int MyNumber; 會報錯
            //成員變數未賦值將給預設值如0, null
            /*
             * C# 的 Stack (Runtime Stack)與JS相同後進先出(他媽的這是廢話):
             * 儲存執行上下文： 這個框架包含了該函數執行所需的所有資訊，例如：
             * => 區域變數 (Local variables)(需要定義值)
             * => 參數 (Parameters)
             * => 傳回位址 (Return address)：函數執行完畢後應該回到哪裡繼續執行。
             * 
             * C# Stack： 主要用於儲存實值型別、方法參數和位址。
             * 參考型別 (Reference Types) 的實際資料則儲存在 Heap (堆積) 上，Stack 裡只儲存對 Heap 上資料的參考位址。
             */
            //null == empty

            //class
            Intro Intro = new Intro();
            Intro.SayHello();
            Intro.Name = "Gino";
            Console.WriteLine(Intro.Name);

            //Array
            int[] NewArray = new int[10]; //Array.length=10, [0, 0, 0, ...n+1]
            NewArray[0] = 10; //[10, 0, 0, ...n+1]

            int[] StaticArray = { 10, 20, 30 };
            Console.WriteLine(StaticArray.Length);

            //Struct(指結構體 不是struct關鍵字)
            const double pi = 3.14159; //常數不可變
            int @int = 10; //32bit 佔據4個位元組 宣告變數後在記憶體中尋找空的位址存放 無論數值是否定義
            long @long = 20L;
            sbyte sb = 100; //8bit, 011....00
            ushort st = 1000; //16bit, ("0符號位"0000011(高位)11101000(低位))
            short s = -1000; //16bit, (按位取反再加一(加一:進位，若為1則進位遇到0轉一停止進位) => "1符號位"1111100(高位)00011000(低位))
            string str = Convert.ToString(s, 2);
            Console.WriteLine(str); //1111110000011000

            //Boxing & Unboxing(損失性能 貌似少用?)
            int SampleBox = 100; //根據int切4位元組 內容為100
            object obj; //引用類型先切4位元組出來 預設值為0
            obj = SampleBox; //裝箱: 此時SampleBox中的內容將被丟到Heap裡 並將該位址存入obj引用
            int SampleUnbox = (int)obj; //拆箱: 將obj引用的Heap中的內容複製進SampleUnbox裏頭
            Console.WriteLine(SampleUnbox);

            //enum
            //{...}

            //class : reference type details
            Student stu; //根據Student這個類別在ram中切一塊32bit的大小擺放 內容為0 => 記憶體位址: 10000010
            stu = new Student(); //建立實例後 根據Student的內容分配大小 比如uint+ushort需要6個位元組 則分配6個位元組 => 記憶體位址: 30000001
            //stu(10000010)此時正在引用(30000001)
            //這就是為何可以讓兩個變數引用同一個實例 請看下述
            Student stu2; //根據Student這個類別在ram中切一塊32bit的大小擺放 內容為0 => 記憶體位址: 10000019
            stu2 = stu; //指向stu同一個記憶體位址: 30000001
        }
    }

    //Reference Type
    class Student
    {
        uint StudentId;
        ushort Score;
    }

    class Intro
    {
        public static int Amount;
        public int Age;
        public string Name;

        //Method
        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }

        //enum
        public enum WindowState
        {
            Nor = 0,
            Min = 1,
            Max = 2,
        }
    }
}
