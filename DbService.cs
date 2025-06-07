using System.Data;
using System.Data.SqlClient;


class Dbservice : DBRepo
{
    SqlConnection conn;
    public Dbservice()
    {
        conn = new SqlConnection("Data Source = LAPTOP-L172RIKO; Initial Catalog = massdb; Integrated Security = True; Encrypt=False; MultipleActiveResultSets = True");
        conn.Open();
    }
    public void SaveEmp()
    {
        string empname, empemail, empdept;
        double empsalary;

        Console.WriteLine("Enter Name : ");
        empname = Console.ReadLine();

        Console.WriteLine("Enter Email : ");
        empemail = Console.ReadLine();

        Console.WriteLine("Enter Dept : ");
        empdept = Console.ReadLine();

        Console.WriteLine("Enter Salary : ");
        empsalary =double.Parse( Console.ReadLine());

        try
        {
            string q = $"exec SaveEmp '{empname}','{empemail}','{empdept}','{empsalary}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Emp Added Successfully");


        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public void FetchEmpDetails()
    {
        string q = "exec FetchEmps";
        SqlCommand cmd = new SqlCommand(q, conn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.HasRows)
        {
            while (rdr.Read())
            {
                string s = $"Emp Id : {rdr["id"]}\n Emp Name : {rdr["name"]}\n Emp Email ID : {rdr["email"]}\n Emp DEPT : {rdr["dept"]}\n Emp Salary : {rdr["salary"]}\n================================";
                Console.WriteLine(s);
            }
        }
        else
        {
            Console.WriteLine("====================\nData Not Found\n====================");
        }
            

        
    }
    public void DeleteEmpDetails()
    {
        Console.WriteLine("Enter Employee ID :");
        int empid = int.Parse(Console.ReadLine());
        try
        {
            string q = $"exec DeleteEmp {empid}";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Emp Details Deleted Successfully");
        }
        catch (Exception e) 
        {
            throw e;
        }

        

    }
    public void SearchEmpDetails()
    {
        Console.WriteLine("Enter Employee ID :");
        int empid = int.Parse(Console.ReadLine());
        try
        {
            string q = $"exec SearchEmp {empid}";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    string s = $"Emp Id : {rdr["id"]}\n Emp Name : {rdr["name"]}\n Emp Email ID : {rdr["email"]}\n Emp DEPT : {rdr["dept"]}\n Emp Salary : {rdr["salary"]}\n================================";
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("====================\nData Not Found\n====================");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public void UpdateEmpDetail()
    {
        Console.WriteLine("Enter Employee ID : ");
        int empid = int.Parse(Console.ReadLine());

        string empname, empemail, empdept;
        double empsalary;

        Console.WriteLine("Enter Name : ");
        empname = Console.ReadLine();

        Console.WriteLine("Enter Email : ");
        empemail = Console.ReadLine();

        Console.WriteLine("Enter Dept : ");
        empdept = Console.ReadLine();

        Console.WriteLine("Enter Salary : ");
        empsalary = double.Parse(Console.ReadLine());
        try
        {
            string q = $"exec UpdateEmpDetails'{empid}','{empemail}','{empname}','{empdept}','{empsalary}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            //SqlDataReader rdr = cmd.ExecuteReader();
            
            cmd.ExecuteNonQuery();

            Console.WriteLine("Emp Details Updated Successfully");
        }
        catch (Exception e)
        {
            throw e;

        }
    }

}
