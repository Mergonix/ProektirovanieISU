using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PropertyService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void AddClients(string FirstName, string LastName, string Patronymic, DateTime DateBirth, string Telephone, string Adress, int Users_ID);

        [OperationContract]
        List<List<string>> SelectClients();

        [OperationContract]
        void AddRole(string Name);

        [OperationContract]
        List<List<string>> SelectRole();

        [OperationContract]
        void AddDeal(DateTime DateDeal, int Realty_ID, int Realtor_ID, int Services_ID);

        [OperationContract]
        List<List<string>> SelectDeal();

        [OperationContract]
        void AddHouseType(string DescriptionHouse);

        [OperationContract]
        List<List<string>> SelectHouseType();

        [OperationContract]
        void AddProperty_Type(string DescriptionType);

        [OperationContract]
        List<List<string>> SelectProperty_Type();

        [OperationContract]
        void AddRealtor(string FirstName, string LastName, string Telephone, string Patronymic, int Users_ID);

        [OperationContract]
        List<List<string>> SelectRealtor();

        [OperationContract]
        bool FindByEmailUsers(string Email);

        [OperationContract]
        Authentication Authentication(string Email, string Password);



    }

    [DataContract]
    public class Authentication
    {
        [DataMember]
        public bool error;
        [DataMember]
        public string error_message;
        [DataMember]
        public int id_user;
        [DataMember]
        public int role_id;

    }

}
