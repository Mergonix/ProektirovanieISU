using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PropertyService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        string connectionString = @"Data Source=DESKTOP-OG8OGQV\SQLEXPRESS;Initial Catalog=Nedviz;Integrated Security=True";
        

        public void AddClients(string FirstName, string LastName, string Patronymic, DateTime DateBirth, string Telephone, string Adress, int Users_ID)
        {
            string dateBirth = DateBirth.ToString("d");
            string sqlExpression = "AddClients";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter FirstNameParam = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = FirstName
                };
                command.Parameters.Add(FirstNameParam);


                SqlParameter LastNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = LastName
                };
                command.Parameters.Add(LastNameParam);

                SqlParameter PatronymicParam = new SqlParameter
                {
                    ParameterName = "@Patronymic",
                    Value = Patronymic
                };
                command.Parameters.Add(PatronymicParam);


                SqlParameter DateBirthParam = new SqlParameter
                {
                    ParameterName = "@DateBirth",
                    Value = dateBirth
                };
                command.Parameters.Add(DateBirthParam);

                SqlParameter TelephoneParam = new SqlParameter
                {
                    ParameterName = "@Telephone",
                    Value = Telephone
                };
                command.Parameters.Add(TelephoneParam);

                SqlParameter AdressParam = new SqlParameter
                {
                    ParameterName = "@Adress",
                    Value = Adress
                };
                command.Parameters.Add(AdressParam);

                SqlParameter Users_IDParam = new SqlParameter
                {
                    ParameterName = "@Users_ID",
                    Value = Users_ID
                };
                command.Parameters.Add(Users_IDParam);

                var result = command.ExecuteNonQuery();

                connection.Close();
            }

        }

        public List<List<string>> SelectClients()
        {
            string sqlExpression = "SelectClients";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> Clients = new List<List<string>>();
                    while (reader.Read())
                    {
                        List<string> client = new List<string>();

                        int id = reader.GetInt32(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        string Patronymic = reader.GetString(3);
                        DateTime DateBirth = reader.GetDateTime(4);
                        string Telephone = reader.GetString(5);
                        string Adress = reader.GetString(6);
                        int Users_ID = reader.GetInt32(7);

                        client.Add(id.ToString());
                        client.Add(FirstName);
                        client.Add(LastName);
                        client.Add(Patronymic);
                        client.Add(DateBirth.ToString());
                        client.Add(Telephone);
                        client.Add(Adress);
                        client.Add(Users_ID.ToString());

                        Clients.Add(client);
                    }
                    return Clients;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddRole(string Name)
        {
            string sqlExpression = "AddRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter NameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = Name
                };
                command.Parameters.Add(NameParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectRole()
        {
            string sqlExpression = "SelectRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> Roles = new List<List<string>>();
                    
                    while (reader.Read())
                    {
                        List<string> role = new List<string>();

                        int id = reader.GetInt32(0);
                        string Name = reader.GetString(1);

                        role.Add(id.ToString());
                        role.Add(Name);

                        Roles.Add(role);
                    }
                    return Roles;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddDeal(DateTime DateDeal, int Realty_ID, int Realtor_ID, int Services_ID)
        {
            string sqlExpression = "AddDeal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter DateDealParam = new SqlParameter
                {
                    ParameterName = "@DateDeal",
                    Value = DateDeal
                };
                command.Parameters.Add(DateDealParam);

                SqlParameter Realty_IDParam = new SqlParameter
                {
                    ParameterName = "@Realty_ID",
                    Value = Realty_ID
                };
                command.Parameters.Add(Realty_IDParam);

                SqlParameter Realtor_IDParam = new SqlParameter
                {
                    ParameterName = "@Realtor_ID",
                    Value = Realtor_ID
                };
                command.Parameters.Add(Realtor_IDParam);

                SqlParameter Services_IDParam = new SqlParameter
                {
                    ParameterName = "@Services_ID",
                    Value = Services_ID
                };
                command.Parameters.Add(Services_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectDeal()
        {
            string sqlExpression = "SelectDeal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> Deals = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> deal = new List<string>();

                        int id = reader.GetInt32(0);
                        DateTime DateDeal = reader.GetDateTime(1);
                        int Realty_ID = reader.GetInt32(2);
                        int Realtor_ID = reader.GetInt32(3);
                        int Services_ID = reader.GetInt32(4);

                        deal.Add(id.ToString());
                        deal.Add(DateDeal.ToString());
                        deal.Add(Realty_ID.ToString());
                        deal.Add(Realtor_ID.ToString());
                        deal.Add(Services_ID.ToString());

                        Deals.Add(deal);
                    }
                    return Deals;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddHouseType(string DescriptionHouse)
        {
            string sqlExpression = "AddHouseType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter DescriptionHouseParam = new SqlParameter
                {
                    ParameterName = "@DescriptionHouse",
                    Value = DescriptionHouse
                };
                command.Parameters.Add(DescriptionHouseParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectHouseType()
        {
            string sqlExpression = "SelectHouseType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> HouseTypes = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> house_type = new List<string>();

                        int id = reader.GetInt32(0);
                        string DescriptionHouse = reader.GetString(1);

                        house_type.Add(id.ToString());
                        house_type.Add(DescriptionHouse);

                        HouseTypes.Add(house_type);
                    }
                    return HouseTypes;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddProperty_Type(string DescriptionType)
        {
            string sqlExpression = "AddProperty_Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter DescriptionTypeParam = new SqlParameter
                {
                    ParameterName = "@DescriptionType",
                    Value = DescriptionType
                };
                command.Parameters.Add(DescriptionTypeParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectProperty_Type()
        {
            string sqlExpression = "SelectProperty_Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> PropertyTypes = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> property_type = new List<string>();

                        int id = reader.GetInt32(0);
                        string DescriptionType = reader.GetString(1);

                        property_type.Add(id.ToString());
                        property_type.Add(DescriptionType);

                        PropertyTypes.Add(property_type);
                    }
                    return PropertyTypes;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddRealtor(string FirstName, string LastName, string Telephone, string Patronymic, int Users_ID)
        {
            string sqlExpression = "AddRealtor";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter FirstNameParam = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = FirstName
                };
                command.Parameters.Add(FirstNameParam);

                SqlParameter LastNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = LastName
                };
                command.Parameters.Add(LastNameParam);

                SqlParameter TelephoneParam = new SqlParameter
                {
                    ParameterName = "@Telephone",
                    Value = Telephone
                };
                command.Parameters.Add(TelephoneParam);

                SqlParameter PatronymicParam = new SqlParameter
                {
                    ParameterName = "@Patronymic",
                    Value = Patronymic
                };
                command.Parameters.Add(PatronymicParam);

                SqlParameter Users_IDParam = new SqlParameter
                {
                    ParameterName = "@Users_ID",
                    Value = Users_ID
                };
                command.Parameters.Add(Users_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectRealtor()
        {
            string sqlExpression = "SelectRealtor";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> Realtors = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> realtor = new List<string>();

                        int id = reader.GetInt32(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        string Telephone = reader.GetString(3);
                        string Patronymic = reader.GetString(4);
                        int Users_ID = reader.GetInt32(5);


                        realtor.Add(id.ToString());
                        realtor.Add(FirstName);
                        realtor.Add(LastName);
                        realtor.Add(Telephone);
                        realtor.Add(Patronymic);
                        realtor.Add(Users_ID.ToString());

                        Realtors.Add(realtor);
                    }
                    return Realtors;
                }
                else
                {
                    return null;
                }

            }
        }

        public void AddUsers(string Email,string Password, int Role_ID)
        {
            string sqlExpression = "AddUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter PasswordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = Password
                };
                command.Parameters.Add(PasswordParam);

                SqlParameter Role_IDParam = new SqlParameter
                {
                    ParameterName = "@Role_ID",
                    Value = Role_ID
                };
                command.Parameters.Add(Role_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<List<string>> SelectUsers()
        {
            string sqlExpression = "SelectUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<List<string>> Users = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> user = new List<string>();

                        int id = reader.GetInt32(0);
                        string Email = reader.GetString(1);
                        string Password = reader.GetString(2);
                        int Role_ID = reader.GetInt32(3);


                        user.Add(id.ToString());
                        user.Add(Email);
                        user.Add(Password);
                        user.Add(Role_ID.ToString());

                        Users.Add(user);
                    }
                    return Users;
                }
                else
                {
                    return null;
                }

            }
        }

        public bool FindByEmailUsers(string Email)
        {
            string sqlFindByEmailUsers = "FindByEmailUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByEmailUsers, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = Email
                };
                command.Parameters.Add(EmailParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public Authentication Authentication(string Email, string Password)
        {
            Authentication auth = new Authentication();

            if (FindByEmailUsers(Email))
            {
                string sqlExpression = "Authentication";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter EmailParam = new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = Email
                    };
                    command.Parameters.Add(EmailParam);

                    SqlParameter PasswordParam = new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = Password
                    };
                    command.Parameters.Add(PasswordParam);

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id= reader.GetInt32(0);
                            int role_id = reader.GetInt32(1);
                            auth.error = false;
                            auth.error_message = null;
                            auth.id_user = id;
                            auth.role_id = role_id;
                           
                        }
                        return auth;
                    }
                    else
                    {
                        auth.error = true;
                        auth.error_message = "Неверное имя пользователя или пароль";
                        return auth;
                    }
                }
            }
            else
            {
                auth.error = true;
                auth.error_message = "Неверное имя пользователя или пароль";
                return auth;
            }
            
        }



    }
}
