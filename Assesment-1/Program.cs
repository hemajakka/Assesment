namespace Assesment_1
{
    class ExpenseTracker
    {
        public string title { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public DateOnly date { get; set; }
    }
    class Transaction
    {
        List<ExpenseTracker> list=new List<ExpenseTracker>();

        public void AddTransaction()
        {
            Console.WriteLine("enter title");
            string title=Console.ReadLine();
            Console.WriteLine("enter the description");
            string description=Console.ReadLine();
            Console.WriteLine("enter amount");
            int amount=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter date");
            DateOnly date =DateOnly.Parse(Console.ReadLine());
            list.Add(new ExpenseTracker { title = title, description = description, amount = amount, date=date });

            Console.WriteLine("new transaction is aadded");
        }
      public void ViewExpenses()
      {
            Console.WriteLine("the expenses are:");
            Console.WriteLine("title\t\tdescription\t\tamount\t\tdate");
            var query = list.Where(c => c.amount < 0);
            foreach (var expense in query)
            {
                Console.WriteLine($"{expense.title}\t\t{expense.description}\t\t{expense.amount}\t\t{expense.date}");
            }
            
      }
      public void ViewIncome()
      {
            Console.WriteLine("the incomes are:");
            Console.WriteLine("title\t\tdescription\t\tamount\t\tdate");
            
            var query1=list.Where(c => c.amount > 0);
            foreach(var expense in query1)
            {
                Console.WriteLine($"{expense.title}\t\t{expense.description}\t\t{expense.amount}\t\t{expense.date}");

            }
      }
    
      public double CheckBalance()
        {
          return list.Sum(c => c.amount);
        }
       

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction obj= new Transaction();
            string ans = "";
           
            do
            {
                Console.WriteLine("expenses tracker app");
                Console.WriteLine("1.add transaction");
                Console.WriteLine("2.view expenses");
                Console.WriteLine("3.view income");
                Console.WriteLine("4.check balance");
                Console.WriteLine("enter choice");
                int ch = Convert.ToInt16(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {
                            obj.AddTransaction();
                            break;
                        }
                    case 2:
                        {
                            obj.ViewExpenses();
                            break;
                        }
                    case 3:
                        {
                            obj.ViewIncome();
                            break;
                        }
                    case 4:
                        {
                            double a=obj.CheckBalance();
                            Console.WriteLine($"the available balance is {a}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invalid choice");
                            break;
                        }
                }
                Console.WriteLine("do you want to continue");
                ans= Console.ReadLine();
            } while (ans.ToLower()=="y");

        }
    }
}