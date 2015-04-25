using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BU;
using BU.Entities;

namespace OdawaService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IOdawaService
    {

        [OperationContract]
        List<TypeCuisine> GetAllTypeCuisine();

        [OperationContract]
        TypeCuisine GetTypeCuisine(int id);

        [OperationContract]
        List<Restaurant> GetRestaurantByTypeCuisine(int id);

        [OperationContract]
        List<Comment> GetCommentByRestaurant(int id);

        [OperationContract]
        List<Reservation> GetReservationByRestaurant(int id);

        [OperationContract]
        Restaurant GetRestaurant(int id);

        [OperationContract]
        List<Restaurant> SearchRestaurant(string s);

        [OperationContract]
        bool AcceptLoginRestaurateur(string username, string password);

        [OperationContract]
        Restaurateur GetRestaurateur(string username);

        [OperationContract]
        bool AcceptLoginUtilisateur(string username, string password);

        [OperationContract]
        Utilisateur GetUtilisateur(string username);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    
}
