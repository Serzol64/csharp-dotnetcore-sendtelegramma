using System;
using System.Threading;

namespace LearnApp
{
    class Program
    {
        public static void AutoExit()
        {
            Console.WriteLine("Неверно введены данные ;-( \n Через 5 секунд заново откройте программу и повторите попытку!");
            Thread.Sleep(5000);
            Environment.Exit( 0 );
        }
        public static void PaymentResult(string citizen, string t, string tocit, string fromad, string toad, string r, string m, double rp)
        {
            int messagecount = m.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            double mp = messagecount * rp;

            Console.WriteLine($"Телеграмма отправителя состоит из количества слов: {messagecount}");
            Console.WriteLine($"Для отправки телеграммы в страну {r} требуется оплатить {mp} RUR за количество слов и в зависимости от вида телеграммы;-)/n/n");
            
            Console.WriteLine($"{t} телеграмма(Предварительный просмотр): \n");

            Console.WriteLine($"Ф.И.О отправителя: {citizen} Адрес отправителя: {fromad} Ф.И.О получателя: {tocit} Адрес получателя: {toad} Текст телеграммы:  {m}");

        }
        static void Main(string[] args)
        {
            string title = "Виртуальный приём межсоюзной телеграммы";
            Console.WriteLine($"Добро пожаловать в {title} !");

            string[] tgtypes = new string[]{"Обыкновенная", "Срочная"};
            string[] regions = new string[]{"Россия","Белоруссия","Казахстан"};//Кроме нашей страны, отправитель может отправить телеграмму в ближайшие к нам страны, 
                                                                   //которые являются членами Евразийского союза.
            double[][] regprices = new double[][] {
                new double[]{3.75, 30.96, 46.44},
                new double[]{5.35, 61.92, 92.85}
            };

            string region = "",tgtype = "";
            double regprice = 0.00;

            Console.WriteLine("Введите фамилию отправителя: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("Введите имя отправителя: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Введите отчество отправителя: ");
            string middlename = Console.ReadLine();

            Console.WriteLine("Введите фамилию получателя: ");
            string inbox_lastname = Console.ReadLine();

            Console.WriteLine("Введите имя получателя: ");
            string inbox_firstname = Console.ReadLine();

            Console.WriteLine("Введите отчество получателя: ");
            string inbox_middlename = Console.ReadLine();

            Console.WriteLine("Введите адрес отправителя(с указанием страны, региона, населённого пункта, улицы, дома и прочих геоданных): ");
            string from = Console.ReadLine();

            Console.WriteLine("Введите адрес получателя(с указанием страны, региона, населённого пункта, улицы, дома и прочих геоданных): ");
            string to = Console.ReadLine();

            Console.WriteLine("Какую телеграмму хочет отправить отправитель(0 - обыконвенная или 1 - срочная): ");
            int gtype = Convert.ToInt32(Console.ReadLine());

            switch (gtype)
            {
                case 0:
                    tgtype = tgtypes[0];
                break;
                case 1:
                    tgtype = tgtypes[1];
                break;
                default:
                    AutoExit();
                break;
            }

            Console.WriteLine("Введите сообщение для телеграммы: ");
            string message = Console.ReadLine();

            

            
            for(var i = 0; i < regions.Length; i++)
            {
                if(message.Contains(regions[i]))
                {
                    if(tgtype == "Обыкновенная") regprice = regprices[0][i];
                    if(tgtype == "Срочная") regprice = regprices[0][i];

                    region = regions[i];
                }
            }

            string cit = lastname + " " + firstname + "" + middlename; 
            string tocit = inbox_lastname + " " + inbox_firstname + "" + inbox_middlename; 
            PaymentResult(cit, tgtype, tocit, from, to, region, message, regprice);


            



















        }
    }
}
