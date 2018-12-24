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
        void AddRole(Role role);

        [OperationContract]
        List<Role> SelectRole();

        [OperationContract]
        void AddDeal(Deal deal);

        [OperationContract]
        List<Deal> SelectDeal();

        [OperationContract]
        void AddHouseType(HouseType house_type);

        [OperationContract]
        List<HouseType> SelectHouseType();

        [OperationContract]
        void AddProperty_Type(Property_Type property_type);

        [OperationContract]
        List<Property_Type> SelectProperty_Type();

        [OperationContract]
        List<Realty> SelectRealty();

        [OperationContract]
        bool FindByEmailUsers(string Email);

        [OperationContract]
        List<Users> SelectUsers();

        [OperationContract]
        Authentication Authentication(string Email, string Password);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void AddUsers(Users user);

        [OperationContract]
        Users FindByIDUsers(int id);

        [OperationContract]
        Property_Type FindByIDProperty_Type(int id);

        [OperationContract]
        Object FindByIDObject(int id);

        [OperationContract]
        HouseType FindByIDHouseType(int id);
        

        [OperationContract]
        Realty FindByIdRealty(int id);
        

        [OperationContract]
        Services FindByIDServices(int id);

        [OperationContract]
        Role FindByIDRole(int id);

        [OperationContract]
        List<Report> ReportCount();

        [OperationContract]
        List<Report> ReportPrice();

        [OperationContract]
        List<RealtyTable> SelectRealtyTable();

        [OperationContract]
        List<Object> SelectObject();

        [OperationContract]
        List<Services> SelectServices();

    }
    
    

}
