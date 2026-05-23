namespace PracticaNomina.Models
{
    public class EmpleadoAsalariadoPorComision : EmpleadoPorComision
    {
        public decimal SalarioBase { get; set; }
        public override string Tipo => "Asalariado por comision";

        public EmpleadoAsalariadoPorComision(string nombre, string apellido, string seguro, decimal ventas, decimal tarifa, decimal salariobase)
            : base(nombre, apellido, seguro, ventas, tarifa)
        {
            SalarioBase = salariobase;
        }

        public override string AtributosExtra => $"""
            Salario base: {SalarioBase}
            Ventas: RD${VentasBrutas}
            Tarifa por comision: {TarifaComision}
            """;
        public override string Calculo => $"""
            Calculo:
            {VentasBrutas} x {TarifaComision}
            MAS(+):
            {SalarioBase} + {SalarioBase * 0.1m}
            """;
        public override decimal CalcularPago()
        {
            return base.CalcularPago() + SalarioBase + (SalarioBase*0.1m);
        }
        
    }
}
