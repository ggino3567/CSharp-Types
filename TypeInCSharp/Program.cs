using System.Numerics;

namespace TypeInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //容易搞錯:
            //static靜態方法: 不需實例化可直接調用、一運作就存在
            Student.GetStudent(); //這就是靜態方法
            Student student = new Student();
            student.GetStudentWithoutStatic(); //這就是非靜態方法

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

            /*
             * 宣告方法時，public void MethodName(Parameter形式參數)
             * 調用方法時，Object.Class.MethodName(Argument實際參數)
             */

            //Array & Array List<T> & Dictionary<TKey, TValue>
            //<T>等於參數類型
            int[] intArray = new int[10]; //Array在宣告時就把長度限制住了 長度為10
            string[] strArray = new string[] {"T1", "T2"}; //無法改變 長度為2
            List<string> foodSets = new List<string>
            {
                "炸雞",
                "炒麵",
                "烤串"
            };
            System.Console.WriteLine($"FoodSets[0]: {foodSets[0]}"); //炸雞
            System.Console.WriteLine($"FoodSets: {foodSets.Count}"); //3

            List<string> newFoodSets = new List<string>(foodSets); //建構子直接初始化一個副本
            //NewFoodSets = {...FoodSets}; c#不支援展開運算符
            newFoodSets.Add("大便");
            System.Console.WriteLine($"NewFoodSets: {newFoodSets.Count}");

            Dictionary<int, string> students = new Dictionary<int, string>
            {
                {1, "這是1" },
                {2, "這是2" },
                {3, "這是3" },
            };
            System.Console.WriteLine($"Students[2]: {students[2]}"); //這是2


            Dictionary<int, string> employees = new Dictionary<int, string> ();
            employees.Add(1, "Hello");

            //常數 & 變數 & 超大杯
            const double pi = 3.14159; //常數不可變
            int @int = 10; //32bit 佔據4個位元組 宣告變數後在記憶體中尋找空的位址存放 無論數值是否定義
            long @long = 20L; //64bit 真大
            sbyte sb = 100; //8bit, 011....00
            ushort st = 1000; //16bit, ("0符號位"0000011(高位)11101000(低位))
            short s = -1000; //16bit, (按位取反再加一(加一:進位，若為1則進位遇到0轉一停止進位) => "1符號位"1111100(高位)00011000(低位))
            string str = Convert.ToString(s, 2);
            //Console.WriteLine(str); //1111110000011000
            BigInteger result = BigInteger.One; //超大杯 無限記憶體空間

            //裝箱 & 拆箱(損失性能 貌似少用?)
            int SampleBox = 100; //根據int切4位元組 內容為100
            object obj; //引用類型先切4位元組出來 預設值為0
            obj = SampleBox; //裝箱: 此時SampleBox中的內容將被丟到Heap裡 並將該位址存入obj引用
            int SampleUnbox = (int)obj; //拆箱: 將obj引用的Heap中的內容複製進SampleUnbox裏頭
            //Console.WriteLine(SampleUnbox);

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

        public static void GetStudent()
        {
            Console.WriteLine("這是靜態方法");
        }

        public void GetStudentWithoutStatic()
        {
            Console.WriteLine("這不是靜態方法");
        }
    }
}
