using System;
using System.Collections.Generic;
using System.Data;
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
        readonly string connectionString = @"Data Source=DESKTOP-OG8OGQV\SQLEXPRESS;Initial Catalog=Nedviz;Integrated Security=True";




        public void AddRole(Role role)
        {
            string sqlExpression = "AddRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter NameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = role.Name
                };
                command.Parameters.Add(NameParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<Role> SelectRole()
        {
            string sqlExpression = "SelectRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Role> Roles = new List<Role>();

                    while (reader.Read())
                    {
                        Role role = new Role
                        {
                            id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

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

        public void AddDeal(Deal deal)
        {
            string sqlExpression = "AddDeal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter DateDealParam = new SqlParameter
                {
                    ParameterName = "@DateDeal",
                    Value = deal.DateDeal
                };
                command.Parameters.Add(DateDealParam);

                SqlParameter Realty_IDParam = new SqlParameter
                {
                    ParameterName = "@Realty_ID",
                    Value = deal.Realty_ID
                };
                command.Parameters.Add(Realty_IDParam);

                SqlParameter Realtor_IDParam = new SqlParameter
                {
                    ParameterName = "@Realtor_ID",
                    Value = deal.Realtor_ID
                };
                command.Parameters.Add(Realtor_IDParam);

                SqlParameter Services_IDParam = new SqlParameter
                {
                    ParameterName = "@Services_ID",
                    Value = deal.Services_ID
                };
                command.Parameters.Add(Services_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<Deal> SelectDeal()
        {
            string sqlExpression = "SelectDeal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Deal> Deals = new List<Deal>();

                    while (reader.Read())
                    {
                        Deal deal = new Deal
                        {
                            id = reader.GetInt32(0),
                            DateDeal = reader.GetDateTime(1),
                            Realty_ID = reader.GetInt32(2),
                            Realtor_ID = reader.GetInt32(3),
                            Services_ID = reader.GetInt32(4)
                        };
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

        public void AddHouseType(HouseType house_type)
        {
            string sqlExpression = "AddHouseType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter DescriptionHouseParam = new SqlParameter
                {
                    ParameterName = "@DescriptionHouse",
                    Value = house_type.DescriptionHouse
                };
                command.Parameters.Add(DescriptionHouseParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<HouseType> SelectHouseType()
        {
            string sqlExpression = "SelectHouseType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<HouseType> HouseTypes = new List<HouseType>();

                    while (reader.Read())
                    {
                        HouseType house_type = new HouseType
                        {
                            id = reader.GetInt32(0),
                            DescriptionHouse = reader.GetString(1)
                        };

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

        public void AddProperty_Type(Property_Type property_type)
        {
            string sqlExpression = "AddProperty_Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter DescriptionTypeParam = new SqlParameter
                {
                    ParameterName = "@DescriptionType",
                    Value = property_type.DescriptionType
                };
                command.Parameters.Add(DescriptionTypeParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public List<Property_Type> SelectProperty_Type()
        {
            string sqlExpression = "SelectProperty_Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Property_Type> PropertyTypes = new List<Property_Type>();

                    while (reader.Read())
                    {
                        Property_Type property_type = new Property_Type
                        {
                            id = reader.GetInt32(0),
                            DescriptionType = reader.GetString(1)
                        };

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

        public List<Realtor> SelectRealtor()
        {
            string sqlExpression = "SelectRealtor";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Realtor> Realtors = new List<Realtor>();

                    while (reader.Read())
                    {
                        Realtor realtor = new Realtor
                        {
                            id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Telephone = reader.GetString(3),
                            Patronymic = reader.GetString(4),
                            Users_ID = reader.GetInt32(5)
                        };

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

        public List<Realty> SelectRealty()
        {
            string sqlExpression = "SelectRealty";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Realty> Realty = new List<Realty>();

                    while (reader.Read())
                    {
                        string status;
                        if (!reader.IsDBNull(11))
                            status = reader.GetString(11);
                        status = string.Empty;


                        Realty realty = new Realty
                        {
                            id = reader.GetInt32(0),
                            TotalArea = reader.GetDecimal(1),
                            Flor = reader.GetInt32(2),
                            Flors = reader.GetIntOrDefault(3),
                            Price = reader.GetDecimal(4),
                            Descript = reader.GetString(5),
                            City = reader.GetString(6),
                            Street = reader.GetString(7),
                            NumberRooms = reader.GetIntOrDefault(8),
                            NumberHouse = reader.GetString(9),
                            Apartment = reader.GetStringOrNull(10),
                            Status = reader.GetStringOrNull(11),
                            PropertyType_ID = reader.GetInt32(12),
                            Object_ID = reader.GetInt32(13),
                            HouseType_ID = reader.GetInt32(14),
                            Users_ID = reader.GetInt32(15)

                        };

                        Realty.Add(realty);
                    }
                    return Realty;
                }
                else
                {
                    return null;
                }

            }
        }

        public List<Users> SelectUsers()
        {
            string sqlExpression = "SelectUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Users> Users = new List<Users>();

                    while (reader.Read())
                    {
                        Users user = new Users
                        {
                            id = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            FirstName = reader.GetString(3),
                            LastName = reader.GetString(4),
                            Patronymic = reader.GetStringOrNull(5),
                            Telephone = reader.GetString(6),
                            DateBirth = reader.GetDateTimeOrDefault(7),
                            Adress = reader.GetStringOrNull(8),
                            Role_ID = reader.GetInt32(9)
                        };
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
                SqlCommand command = new SqlCommand(sqlFindByEmailUsers, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

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
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
                            int id = reader.GetInt32(0);
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

        public void AddUsers(Users user)
        {
            string sqlExpression = "AddUsers";
            string dateBirth = user.DateBirth.ToString("d");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter PasswordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                command.Parameters.Add(PasswordParam);

                SqlParameter FirstNameParam = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = user.FirstName
                };
                command.Parameters.Add(FirstNameParam);


                SqlParameter LastNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = user.LastName
                };
                command.Parameters.Add(LastNameParam);

                SqlParameter PatronymicParam = new SqlParameter
                {
                    ParameterName = "@Patronymic",
                    Value = user.Patronymic
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
                    Value = user.Telephone
                };
                command.Parameters.Add(TelephoneParam);

                SqlParameter AdressParam = new SqlParameter
                {
                    ParameterName = "@Adress",
                    Value = user.Adress
                };
                command.Parameters.Add(AdressParam);

                SqlParameter Role_IDParam = new SqlParameter
                {
                    ParameterName = "@Role_ID",
                    Value = user.Role_ID
                };
                command.Parameters.Add(Role_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public void UpdateUsers(Users user)
        {
            string sqlExpression = "UpdateUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter ID_UsersParam = new SqlParameter
                {
                    ParameterName = "@ID_Users",
                    Value = user.id
                };
                command.Parameters.Add(ID_UsersParam);

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter PasswordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                command.Parameters.Add(PasswordParam);

                SqlParameter Role_IDParam = new SqlParameter
                {
                    ParameterName = "@Role_ID",
                    Value = user.Role_ID
                };
                command.Parameters.Add(Role_IDParam);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }

        public Users FindByIDUsers(int id)
        {
            string sqlFindByID = "FindByIDUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Users user = new Users();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.id = id;
                        user.Email = reader.GetString(0);
                        user.Password = reader.GetString(1);
                        user.FirstName = reader.GetString(2);
                        user.LastName = reader.GetString(3);
                        user.Patronymic = reader.GetStringOrNull(4);
                        user.Telephone = reader.GetString(5);
                        user.DateBirth = reader.GetDateTimeOrDefault(6);
                        user.Adress = reader.GetStringOrNull(7);
                        user.Role_ID = reader.GetInt32(8);
                    }
                    return user;
                }
                else
                {
                    return null;
                }

            }
        }

        public Property_Type FindByIDProperty_Type(int id)
        {
            string sqlFindByID = "FindByIDPropertyType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Property_Type property_type = new Property_Type();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        property_type.id = id;
                        property_type.DescriptionType = reader.GetString(0);
                    }
                    return property_type;
                }
                else
                {
                    return null;
                }

            }
        }

        public Object FindByIDObject(int id)
        {
            string sqlFindByID = "FindByIDObject";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Object obj = new Object();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        obj.id = id;
                        obj.DescriptionObject = reader.GetString(0);
                    }
                    return obj;
                }
                else
                {
                    return null;
                }

            }
        }

        public HouseType FindByIDHouseType(int id)
        {
            string sqlFindByID = "FindByIDHouseType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                HouseType house_type = new HouseType();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        house_type.id = id;
                        house_type.DescriptionHouse = reader.GetString(0);
                    }
                    return house_type;
                }
                else
                {
                    return null;
                }

            }
        }

        public Realty FindByIdRealty(int id)
        {
            string sqlFindByID = "FindByIDRealty";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Realty realty = new Realty();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        realty.id = id;
                        realty.TotalArea = reader.GetDecimal(0);
                        realty.Flor = reader.GetInt32(1);
                        realty.Flors = reader.GetIntOrDefault(2);
                        realty.Price = reader.GetDecimal(3);
                        realty.Descript = reader.GetString(4);
                        realty.City = reader.GetString(5);
                        realty.Street = reader.GetString(6);
                        realty.NumberRooms = reader.GetIntOrDefault(7);
                        realty.NumberHouse = reader.GetString(8);
                        realty.Apartment = reader.GetStringOrNull(9);
                        realty.Status = reader.GetString(10);
                        realty.PropertyType_ID = reader.GetInt32(11);
                        realty.Object_ID = reader.GetInt32(12);
                        realty.HouseType_ID = reader.GetInt32(13);
                        realty.Users_ID = reader.GetInt32(14);

                    }
                    return realty;
                }
                else
                {
                    return null;
                }

            }
        }

        public Services FindByIDServices(int id)
        {
            string sqlFindByID = "FindByIDServices";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Services services = new Services();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        services.id = id;
                        services.Description = reader.GetStringOrNull(0);
                    }
                    return services;
                }
                else
                {
                    return null;
                }

            }
        }

        public Role FindByIDRole(int id)
        {
            string sqlFindByID = "FindByIDRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlFindByID, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(Param);

                var reader = command.ExecuteReader();

                Role role = new Role();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role.id = id;
                        role.Name = reader.GetString(0);
                    }
                    return role;
                }
                else
                {
                    return null;
                }

            }
        }



    }


    public static class DataReaderExtensions
    {
        public static string GetStringOrNull(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return null;
        }

        public static int GetIntOrDefault(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return default(int);
        }

        public static DateTime GetDateTimeOrDefault(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return default(DateTime);
        }
    }


    public class Authentication
    {
        public bool error;
        public string error_message;
        public int id_user;
        public int role_id;

    }

    public class Users
    {
        public int id;
        public string Email;
        public string Password;
        public string FirstName;
        public string LastName;
        public string Patronymic;
        public string Telephone;
        public DateTime DateBirth;
        public string Adress;
        public int Role_ID;
    }

    public class Client
    {
        public int id;
        public string FirstName;
        public string LastName;
        public string Patronymic;
        public DateTime DateBirth;
        public string Telephone;
        public string Adress;
        public int Users_ID;
    }

    public class Role
    {
        public int id;
        public string Name;
    }

    public class Deal
    {
        public int id;
        public DateTime DateDeal;
        public int Realty_ID;
        public int Realtor_ID;
        public int Services_ID;
    }

    public class Realtor
    {
        public int id;
        public string FirstName;
        public string LastName;
        public string Telephone;
        public string Patronymic;
        public int Users_ID;
    }

    public class Property_Type
    {
        public int id;
        public string DescriptionType;
    }

    public class HouseType
    {
        public int id;
        public string DescriptionHouse;
    }

    public class Object
    {
        public int id;
        public string DescriptionObject;
    }

    public class Realty
    {
        public int id;
        public decimal TotalArea;
        public int Flor;
        public int Flors;
        public decimal Price;
        public string Descript;
        public string City;
        public string Street;
        public int NumberRooms;
        public string NumberHouse;
        public string Apartment;
        public string Status;
       
        public int PropertyType_ID;
        public int Object_ID;
        public int HouseType_ID;
        public int Users_ID;

    }

    public class Services
    {
        public int id;
        public string Description;
    }
}



/* public List<List<string>> SelectClients()
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
        }*/
