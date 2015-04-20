using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Odawa.BU;
using Odawa.BU.Entities;
using Odawa.DAL;

namespace OdawaService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class OdawaService : IOdawaService
    {        
        public OdawaService()
        {
            DatabaseConnection.FillDataSet();
        }


        public List<TypeCuisine> GetTypeCuisine(int id=0)
        {
            if (id == 0) return TypeCuisineManager.GetAll();
            else return TypeCuisineManager.GetOne(id);
        }
    }
}
