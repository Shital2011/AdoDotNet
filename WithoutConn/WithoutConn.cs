using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AdoDotNet.WithoutConn
{
    static class DBconnect
    {
        public static SqlConnection getConnection()
        {
            string str = "server=DESKTOP-46PU1N7;Database=ThinkQutient;Integrated Security=True";
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand sqlc = new SqlCommand("select*from newemp2", con);
                SqlDataReader dr = sqlc.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("id==" + dr[0] + " " + "name==" + dr[1] + " " + "salary==" + dr[2] + " " + "city==" + dr[3] + "Email==" + dr[4]);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();

            }
            


            return con;
        }
    }

    class DisConnected
    {
        static SqlDataAdapter sda = null;
        static DataSet ds = null;
        public static DataSet getallstudent()
        {
            SqlConnection con = null;
            con = DBconnect.getConnection();
            sda = new SqlDataAdapter("select * from newemp2", con);
            //to assign primary key to col in dataset
            sda.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet();//collection of tables
            sda.Fill(ds);
            return ds;

        }
        static public void Addstudent()
        {
            Console.WriteLine("enter id,nm,sal,city,email");
            int id = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            int sal = int.Parse(Console.ReadLine());
            string city = Console.ReadLine();
            string email = Console.ReadLine();
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = id;
            dr[1] = name;
            dr[2] = sal;
            dr[3] = city;
            dr[4] = email;
            ds.Tables[0].Rows.Add(dr);


        }
        public static void showAllstudent()
        {
            getallstudent();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]+" "+dr[3]+" "+dr[4]);
            }
            
        }
        static public void Updatestudent()
        {
            Console.WriteLine("enter id to update");
            int id = int.Parse(Console.ReadLine());
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            DataRow dr = ds.Tables[0].Rows.Find(id);
            Console.WriteLine("Find   " + dr[0] + " " + dr[1] + " " + dr[2]);
            Console.WriteLine("Enter new name");
            dr[1] = Console.ReadLine();
            dr[2] = 12;
        }
        public static void deletestudent()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            Console.WriteLine("Enter id to delete");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = ds.Tables[0].Rows.Find(id);
            if (dr != null)
                dr.Delete();
        }
        static void Main(string[] args)
        {
            getallstudent();
            Addstudent();
            showAllstudent();
            getallstudent();
            Updatestudent();
            deletestudent();
           
            Console.ReadLine();
        }
        

     
    }
    
}
