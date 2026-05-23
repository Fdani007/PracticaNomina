namespace PracticaNomina.Models
{
    public class EmpleadoPorHoras : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public override string Tipo => "Por horas";
        public override string AtributosExtra => $"""
            Horas trabajadas: {HorasTrabajadas}
            
            Sueldo por hora: {SueldoPorHora}
            """;

        public EmpleadoPorHoras(string nombre, string apellido, string seguro, decimal sueldo, decimal horas)
            : base(nombre, apellido, seguro)
        {
            SueldoPorHora = sueldo;
            HorasTrabajadas = horas;
        }
        public override string Calculo
        {
            get
            {
                if (HorasTrabajadas <= 40)
                {
                    return $"{SueldoPorHora} x {HorasTrabajadas}";
                }
                return $"""
                Pago comun:
                ({SueldoPorHora} x 40) = {SueldoPorHora * 40}
                MAS(+): 
                Horas extras:
                {SueldoPorHora} x ({HorasTrabajadas - 40} x 1.5)
                = {(SueldoPorHora * 1.5m * (HorasTrabajadas - 40))}
                """;
            }
        }
        public override decimal CalcularPago()
        {
            if (HorasTrabajadas <= 40)
            {
                return SueldoPorHora * HorasTrabajadas;
            }

            return (SueldoPorHora * 40) + (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
        }
                      
    }
}
