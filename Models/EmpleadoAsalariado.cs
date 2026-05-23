namespace PracticaNomina.Models
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SalarioSemanal { get; set; }
        public override string Tipo => "Asalariado";
        public override string AtributosExtra => $"Salario semanal: RD${SalarioSemanal}";
        public override string Calculo => "Calculo no necesario";

        public EmpleadoAsalariado(string nombre, string apellido, string seguro, decimal Salario) 
            :base(nombre, apellido, seguro)
        {
            SalarioSemanal = Salario;
        }
        
        public override decimal CalcularPago()
        { 
            return SalarioSemanal;
        }

    }
}
