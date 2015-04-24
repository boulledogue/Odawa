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

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    
}
