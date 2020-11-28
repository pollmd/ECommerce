namespace BusinessLogic.CalculTaxe
{
    public class CalculTaxe
    {
        public float Pret(float cost, float tva, float reducere) 
        {
            float result = 0;
            result = cost + cost * tva / 100 - cost * reducere / 100;

            return result;
        }

        public float Pret(float cost, float tva, float reducere, float acciz)
        {
            float result = 0;
            result = cost + cost * tva / 100 - cost * reducere / 100 + cost * acciz / 100;

            return result;
        }
    }
}
