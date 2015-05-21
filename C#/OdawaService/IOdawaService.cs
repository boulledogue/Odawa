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
        List<Restaurant> GetAllRestaurant();

        [OperationContract]
        List<Restaurant> GetAllSnack();

        [OperationContract]
        List<Restaurant> GetRestaurantByRestaurateur(int id);

        [OperationContract]
        List<Restaurant> GetRestaurantByTypeCuisine(int id);

        [OperationContract]
        List<Comment> GetCommentByRestaurant(int id);

        [OperationContract]
        Reservation GetReservation(int id);

        [OperationContract]
        List<Reservation> GetReservationByRestaurant(int id);

        [OperationContract]
        List<Reservation> GetReservationsEnAttente(int id);

        [OperationContract]
        List<Reservation> GetReservationsAcceptees(int id);

        [OperationContract]
        List<Reservation> GetReservationsRefusees(int id);

        [OperationContract]
        Restaurant GetRestaurant(int id);

        [OperationContract]
        List<Restaurant> SearchRestaurant(string s);

        [OperationContract]
        Utilisateur GetUtilisateur(int id);

        [OperationContract]
        List<Restaurant> BestRestaurant();

        [OperationContract]
        Restaurant RandomRestaurant();

        [OperationContract]
        bool AcceptLoginRestaurateur(string username, string password);

        [OperationContract]
        Restaurateur GetRestaurateurByUsername(string username);

        [OperationContract]
        Restaurateur GetRestaurateurByRestaurant(int id);

        [OperationContract]
        bool AcceptLoginUtilisateur(string username, string password);

        [OperationContract]
        Utilisateur GetUtilisateurByUsername(string username);

        [OperationContract]
        bool CreateUtilisateur(Utilisateur u);

        [OperationContract]
        void UpdateUtilisateur(Utilisateur u);

        [OperationContract]
        void DeleteUtilisateur(int id);

        [OperationContract]
        void CreateComment(Comment c);

        [OperationContract]
        void UpdateComment(Comment c);

        [OperationContract]
        void DeleteComment(int id);

        [OperationContract]
        void CreateReservation(Reservation r);

        [OperationContract]
        void UpdateReservation(Reservation r);

        [OperationContract]
        void CreateRestaurant(Restaurant r);

        [OperationContract]
        void UpdateRestaurant(Restaurant r);

        [OperationContract]
        void DeleteRestaurant(int id);

        [OperationContract]
        void UpdateRestaurateur(Restaurateur r);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    
}
