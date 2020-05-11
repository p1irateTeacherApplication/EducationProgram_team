using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace test
{
    
    public class Ganeral_Variable
    {
        public String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlDataAdapter adapter;
        public SqlCommand cmd;
        public int id_task;
        public int id_Theory;
        public string UserName;
        public string UserPas;
        public float Сorrect_Answer;
        public float User_Answer;
        public string Theory;
        public string Task;
        public string Solution;
        public bool Login_Permission;
    }
}
