namespace PracticaNomina.Models
{
    public class EmpleadoPorComision : Empleado
    {
        private decimal _tarifaComision;
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision 
        { 
            get => _tarifaComision;
            set
            {
                if (value < 0.01m || value > 0.99m)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "El valor debe estar estrictamente entre 0.01 y 0.9."
                    );
                }
                _tarifaComision = value;
            }
        }

        public EmpleadoPorComision(string nombre, string apellido, string seguro, decimal ventas, decimal tarifa)
            : base(nombre, apellido, seguro)
        {
            VentasBrutas = ventas;
            TarifaComision = tarifa;
        }

        public override string Tipo => "Por comision";
        public override string AtributosExtra => $"""
            Ventas: RD${VentasBrutas}
            Tarifa por comision: {TarifaComision}
            """;
        public override string Calculo => $"""
            Calculo:
            {VentasBrutas} x {TarifaComision}
            """;

        public override decimal CalcularPago()
        {
            return VentasBrutas * TarifaComision;
        }

    }
}
