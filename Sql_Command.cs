using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace test
{

    public class Sql_Command
    {
        Ganeral_Variable GV = new Ganeral_Variable();

        public string Getting_Task(int id_task)
        {
            string task = null;
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Task FROM Practice WHERE ID_P = " + id_task, connection);
                    task = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                
            }
            return task;
        }

        public int Getting_Answer(int id_task)
        {
            int answer = 0;
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Answer FROM Practice WHERE ID_P = " + id_task, connection);
                    answer = (Int32)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return answer;
        }
        public string Getting_Solution(int id_task)
        {
            string solution =null;
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Solution FROM Practice WHERE ID_P = " + id_task, connection);
                    solution = Convert.ToString(command.ExecuteScalar());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return solution;
        }

        public string Getting_Theory(int ID_Theory)
        {
            string Content = null;
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Content FROM Theory WHERE ID_T = " + ID_Theory, connection);
                    Content = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return Content;
            }
        }

        public Boolean Add_User(string name, string password)
        {
            Boolean answ = false ;
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                if (name != null && password != null )
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into Users (UserName, UserPas) values(@UserName, @UserPas)", connection);
                        connection.Open();
                        cmd.Parameters.AddWithValue("@UserName", name);
                        cmd.Parameters.AddWithValue("@UserPas", password);
                        if (Find_User(name, password) == true)
                        {
                            MessageBox.Show("Такой пользователь уже существует ");
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            answ = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    } 
                }
                else
                {
                    MessageBox.Show("Введите логин или пароль");
                }
            }
            return answ;
        }
        public Boolean Find_User(string name, string password)
        {
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                Boolean answ = true;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT UserName FROM Users WHERE UserName = " + name, connection);
                    SqlCommand command_pas = new SqlCommand("SELECT UserPas FROM Users WHERE UserPas = " + password, connection);
                    if (name == Convert.ToString(command.ExecuteScalar()))
                    {
						if (password == Convert.ToString(command_pas.ExecuteScalar()))
						{
							answ = true;
						}
                        else
                        {
							answ = false;
						}
                    }
                    else answ = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return answ;
            }
        }

        public void Chapter(ListBox ListTheory)
        {
            using (SqlConnection connection = new SqlConnection(GV.ConnectionString))
            {
                connection.Open();
                ListBox lb = new ListBox();
                SqlCommand command = new SqlCommand("SELECT Name_Chapter FROM Chapter", connection);
                int i = 0;
                ListTheory.Items.Clear();
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ListTheory.Items.Add(dataReader.GetString(i));
                        i++;
                    }
                }

                connection.Close();
            }

        }
    }
}
