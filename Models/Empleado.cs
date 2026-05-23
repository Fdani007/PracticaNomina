namespace PracticaNomina.Models
{
    abstract public class Empleado
    {
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string NumeroSeguroSocial { get; set; }

        public Empleado(string nombre, string apellido, string seguro)
        {       
            PrimerNombre = nombre;
            ApellidoPaterno = apellido;
            NumeroSeguroSocial = seguro;

        }
        public abstract string Tipo { get; }
        public abstract string AtributosExtra { get; }
        public abstract string Calculo { get; }

        public abstract decimal CalcularPago();

        
    }
}
