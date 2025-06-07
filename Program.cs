namespace Proje1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dbservice db = new Dbservice();

            int choice;


            while (true)
            {
                Console.WriteLine("Enter Your Choice \n 1 : Save Emp \n 2 : Fetch Emp Details \n 3 : Delete Data with Emp ID : \n 4 : Search Emp details \n 5 : Update Empployee Details By ID : \n 6 : Exit ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    db.SaveEmp();
                }
                else if (choice == 2)
                {
                    db.FetchEmpDetails();

                }
                else if (choice == 3)
                {
                    db.DeleteEmpDetails();
                }
                else if (choice == 4)
                {
                    db.SearchEmpDetails();
                }
                else if (choice == 5)
                {
                    db.UpdateEmpDetail();
                }
                else
                {
                    break;
                }

            }

        }
    }
}
