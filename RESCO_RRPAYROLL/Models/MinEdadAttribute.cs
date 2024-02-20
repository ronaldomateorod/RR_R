using System.ComponentModel.DataAnnotations;

namespace RESCO_RRPAYROLL.Models
{
    public class MinEdadAttribute : ValidationAttribute
    {
        private readonly int _edadMinima;

        public MinEdadAttribute(int edadMinima)
        {
            _edadMinima = edadMinima;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime fechaNacimiento)
            {
                var edad = DateTime.Today.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                return edad >= _edadMinima;
            }

            return false;
        }
    }
}