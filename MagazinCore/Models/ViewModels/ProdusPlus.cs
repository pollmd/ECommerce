using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models.ViewModels
{
    public class ProdusPlus : Produs
    {
        public float Pret
        {
            get { return CalculPret(); }
        }

        public float CalculPret()
        {
            var result = Cost + Tva * Cost / 100 + Acciz * Cost / 100;

            if(StartReducere <= DateTime.Now && EndReducere >= DateTime.Now)
            {
                result -= Reducere * Cost / 100;
            }

            return result;
        }
    }
}
